using Model.Extensions;
using Model.Interfaces.Generation;
using Model.Nodes.Big.Assignment;
using Model.Nodes.Big.ForStatement;
using Model.Nodes.Small.Constants;
using Model.Nodes.Small.Expressions.Logic;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Nodes.Small;

public partial class StandardExpression
{
    public void AddStandardExpression()
    {
        var expressionChild = EnumExtensions.GetRandomValue<ExpressionChild>();

        expressionChild switch
        {
            ExpressionChild.Constant => _constant = new Constant(this),
            ExpressionChild.VarExpression => () =>
            {
                try
                {
                    _varExpression = new VarExpression(this, true);
                }
                catch (Exception e)
                {
                    // happens when no var exists (almost never) and u want to use it. it's fine; just generate constant instead of variable.
                    _constant = new Constant(this);
                }
            },
            ExpressionChild.MulExpression => () =>
            {
                if (RandomService.RandomPercentage() < NextTwoArgExpressionChance)
                {
                    _multiplicativeExpression = new MultiplicativeExpression(this);
                }
                else
                {
                    AddConstOrVar();
                }
            },
            ExpressionChild.AddExpression => () =>
            {
                if (RandomService.RandomPercentage() < NextTwoArgExpressionChance)
                {
                    _additiveExpression = new AdditiveExpression(this);
                }
                else
                {
                    AddConstOrVar();
                }
            },
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void AddConstOrVar()
    {
        if (RandomService.RandomPercentage() < 50)
        {
            _constant = new Constant(this);
        }
        else
        {
            try
            {
                _varExpression = new VarExpression(this, true);
            }
            catch (Exception e)
            {
                // happens when no var exists (almost never) and u want to use it. it's fine; just generate constant instead of variable.
                _constant = new Constant(this);
            }
        }
    }

    public void SubtreeMutateTwoArgExpression()
    {
        _multiplicativeExpression = null;
        _additiveExpression = null;
        
        if (RandomService.RandomPercentage() < 50)
        {
            _multiplicativeExpression = new MultiplicativeExpression(this);
        }
        else
        {
            _additiveExpression = new AdditiveExpression(this);
        }
    }
    
    public void SubtreeMutate()
    {
        ParentNode switch
        {
            Assignment assignment => assignment.SetExpression(new StandardExpression(assignment)),
            ForAssignment forAssignment => forAssignment.SetExpression(new StandardExpression(forAssignment)),
            ComparisonExpression comparisonExpression => comparisonExpression.SetExpression(
                this,
                new StandardExpression(comparisonExpression, NextTwoArgExpressionChance)
            ),
            AdditiveExpression additiveExpression => additiveExpression.SetExpression(
                this,
                new StandardExpression(additiveExpression, NextTwoArgExpressionChance)
            ),
            MultiplicativeExpression multiplicativeExpression => multiplicativeExpression.SetExpression(
                this,
                new StandardExpression(multiplicativeExpression, NextTwoArgExpressionChance)
            ),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public void MutateConstOrVar()
    {
        var oldConstant = _constant;
        var oldVarExpression = _varExpression;

        while (true)
        {
            _constant = null;
            _varExpression = null;
            AddConstOrVar();

            if (_constant != null && oldConstant != null)
            {
                if (oldConstant.Value != _constant.Value && _varExpression == null)
                {
                    break;
                }
            }
            else if (_varExpression != null && oldVarExpression != null)
            {
                if (oldVarExpression.Value != _varExpression.Value && _constant == null)
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }

    private void SetAdditiveExpression(AdditiveExpression additiveExpression)
    {
        _multiplicativeExpression = null;
        _additiveExpression = additiveExpression;
    }

    private void SetMultiplicativeExpression(MultiplicativeExpression multiplicativeExpression)
    {
        _additiveExpression = null;
        _multiplicativeExpression = multiplicativeExpression;
    }
}