using Model.Abstract;
using Utils;

namespace Model.Nodes.Small.Operators.Logic;

public sealed class CompareOperator : Operator
{
    private const int Bound = 6;

    public override void Mutate()
    {
        var newOperator = GetSpecifiedOperator();

        while (newOperator == Value)
        {
            newOperator = GetSpecifiedOperator();
        }

        Value = newOperator;
    }

    private static string GetSpecifiedOperator()
    {
        var operatorId = RandomService.RandomInt(Bound);

        return operatorId switch
        {
            0 => " == ",
            1 => " != ",
            2 => " > ",
            3 => " < ",
            4 => " >= ",
            5 => " <= ",
            _ => throw new InvalidOperationException()
        };
    }

    public CompareOperator(Node parentNode) : base(parentNode, "CompareOperator")
    {
        Value = GetSpecifiedOperator();
    }

    public CompareOperator(Node parentNode, IList<Token> tokens) : base(parentNode, tokens)
    {
    }
}