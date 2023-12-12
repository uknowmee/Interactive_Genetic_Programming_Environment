using Model.Nodes;
using Model.Nodes.Small;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Interfaces.Evolution;

public interface ITwoArgExpression
{
    public void Mutate()
    {
        StandartExpression left;
        StandartExpression right;
        string op;

        if (this is AdditiveExpression additiveExpression)
        {
            left = additiveExpression.Left;
            right = additiveExpression.Right;
            op = additiveExpression.Operator;
        } else if (this is MultiplicativeExpression multiplicativeExpression)
        {
            left = multiplicativeExpression.Left;
            right = multiplicativeExpression.Right;
            op = multiplicativeExpression.Operator;
        }
        
        MutateOperator(left, right, op);
    }

    private void MutateOperator(StandartExpression left, StandartExpression right, String op)
    {
        var current = this as Node ?? throw new NullReferenceException();
        var parent = current.Parent;
        var parentAsExpression = parent as StandartExpression ?? throw new NullReferenceException();
        
        if (PercentagesService.RandomPercentage() < 0.5)
        {
            var additiveExpression = new AdditiveExpression(parent, left, right, op);
            parentAsExpression.AdditiveExpression = additiveExpression;
        }
        else
        {
            var multiplicativeExpression = new MultiplicativeExpression(parent, left, right, op);
            parentAsExpression.MultiplicativeExpression = multiplicativeExpression;
        }
    }
}