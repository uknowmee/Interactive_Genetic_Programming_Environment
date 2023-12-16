using Model.Abstract;
using Utils;

namespace Model.Nodes.Small.Operators.Arithmetic;

public sealed class MultiplicativeOperator : Operator
{
    public override void Mutate()
    {
        if (ParentNode is TwoArgExpression twoArgExpression)
        {
            twoArgExpression.Mutate();
        }
    }

    public MultiplicativeOperator(Node parentNode) : base(parentNode, "MultiplicativeOperator")
    {
        Value = RandomService.RandomPercentage() < 50
            ? " * "
            : " / ";
    }

    public MultiplicativeOperator(Node parentNode, IList<Token> tokens) : base(parentNode, tokens)
    {
    }
}