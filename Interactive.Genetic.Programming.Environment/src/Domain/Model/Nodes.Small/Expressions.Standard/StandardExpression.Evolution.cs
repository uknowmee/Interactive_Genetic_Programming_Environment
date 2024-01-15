using Model.Extensions;
using Model.Interfaces;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Small.Constants;
using Model.Nodes.Small.Expressions.Logic;
using Utils;

namespace Model.Nodes.Small.Expressions.Standard;

public partial class StandardExpression
{
    public void AddStandardExpression()
    {
        var expressionChild = EnumExtensions.GetRandomValue<ExpressionChild>();

        switch (expressionChild)
        {
            case ExpressionChild.Constant:
                _constant = new Constant(this);
                break;
            case ExpressionChild.VarExpression:
                try
                {
                    _varExpression = new VarExpression(this, true);
                }
                catch (Exception e)
                {
                    // happens when no var exists (almost never) and u want to use it. it's fine; just generate constant instead of variable.
                    _constant = new Constant(this);
                }
                break;
            case ExpressionChild.MulExpression:
                if (RandomService.RandomPercentage() < NextTwoArgExpressionChance)
                {
                    _multiplicativeExpression = new MultiplicativeExpression(this);
                }
                else
                {
                    AddConstOrVar();
                }
                break;
            case ExpressionChild.AddExpression:
                if (RandomService.RandomPercentage() < NextTwoArgExpressionChance)
                {
                    _additiveExpression = new AdditiveExpression(this);
                }
                else
                {
                    AddConstOrVar();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void AddConstOrVar()
    {
        if (RandomService.RandomPercentage() < 0.5)
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
        
        if (RandomService.RandomPercentage() < 0.5)
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
        switch (ParentNode)
        {
            case Assignment assignment:
                assignment.Expression = new StandardExpression(assignment);
                break;
            case ForAssignment forAssignment:
                forAssignment.Expression = new StandardExpression(forAssignment);
                break;
            case ComparisonExpression comparisonExpression:
                comparisonExpression.SetExpression(
                    this,
                    new StandardExpression(comparisonExpression, NextTwoArgExpressionChance)
                );
                break;
            case AdditiveExpression additiveExpression:
                additiveExpression.SetExpression(
                    this,
                    new StandardExpression(additiveExpression, NextTwoArgExpressionChance)
                );
                break;
            case MultiplicativeExpression multiplicativeExpression:
                multiplicativeExpression.SetExpression(
                    this,
                    new StandardExpression(multiplicativeExpression, NextTwoArgExpressionChance)
                );
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
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
}