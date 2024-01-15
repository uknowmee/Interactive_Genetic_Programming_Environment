using Model.Abstract;
using Model.Nodes.Big.For;
using Utils;

namespace Model.Nodes.Small.Operators.Arithmetic;

public sealed class AdditiveOperator : Operator
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
        else if (ParentNode is TwoArgExpression twoArgExpression)
        {
            twoArgExpression.Mutate();
        }
    }
    
    public AdditiveOperator(Node parentNode) : base(parentNode, "AdditiveOperator")
    {
        Value = RandomService.RandomPercentage() < 0.5
            ? " + "
            : " - ";
    }
    
    public AdditiveOperator(Node parentNode, IList<Token> tokens) : base(parentNode, tokens)
    {
    }
}