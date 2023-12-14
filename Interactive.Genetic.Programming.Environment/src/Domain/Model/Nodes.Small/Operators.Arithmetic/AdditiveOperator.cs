using Model.Interfaces.Evolution;
using Model.Nodes.Big.ForStatement;
using Utils;

namespace Model.Nodes.Small.Operators.Arithmetic;

public class AdditiveOperator : Operator
{
    public override void Mutate()
    {
        if (ParentNode is ForIncrement)
        {
            Value = Value switch
            {
                " + " => " - ",
                " - " => " + ",
                _ => throw new InvalidOperationException()
            };
        }
        else if (ParentNode is ITwoArgExpression twoArgExpression)
        {
            twoArgExpression.Mutate();
        }
    }
    
    public AdditiveOperator(Node parentNode) : base(parentNode, "AdditiveOperator")
    {
        Value = RandomService.RandomPercentage() < 50
            ? " + "
            : " - ";
    }
    
    public AdditiveOperator(Node parentNode, IList<Token> tokens) : base(parentNode, tokens)
    {
    }
}