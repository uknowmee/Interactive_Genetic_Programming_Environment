using Model.Extensions;
using Model.Interfaces;
using Model.Nodes.Big.If;
using Utils;

namespace Model.Nodes.Small.Expressions.Logic;

public partial class LogicExpression
{
    public void AddLogicExpression()
    {
        var logicExpressionChild = EnumExtensions.GetRandomValue<LogicExpressionChild>();

        switch (logicExpressionChild)
        {
            case LogicExpressionChild.CompExpression:
                _comparisonExpression = new ComparisonExpression(this);
                break;
            case LogicExpressionChild.BoolExpression:
                if (RandomService.RandomPercentage() < NextLogicBooleanExpressionChance)
                {
                    _booleanExpression = new BooleanExpression(this);
                }
                else
                {
                    _comparisonExpression = new ComparisonExpression(this);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void SubtreeMutate()
    {
        switch (ParentNode)
        {
            case IfStatement ifStatement:
                ifStatement.LogicExpression = new LogicExpression(ifStatement);
                break;
            case BooleanExpression booleanExpression:
                booleanExpression.SetLogicExpression(
                    this,
                    new LogicExpression(booleanExpression, NextLogicBooleanExpressionChance)
                );
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}