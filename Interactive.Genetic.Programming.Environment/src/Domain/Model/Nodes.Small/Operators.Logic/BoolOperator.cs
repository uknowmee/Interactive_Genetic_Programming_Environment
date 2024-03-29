﻿using Model.Abstract;
using Utils;

namespace Model.Nodes.Small.Operators.Logic;

public sealed class BoolOperator : Operator
{
    public override void Mutate()
    {
        Value = Value switch
        {
            " and " => " or ",
            " or " => " and ",
            _ => throw new InvalidOperationException()
        };
    }

    public BoolOperator(Node parentNode) : base(parentNode, "BoolOperator")
    {
        Value = RandomService.RandomPercentage() < 0.5
            ? " and "
            : " or ";
    }
    
    public BoolOperator(Node parentNode, IList<Token> tokens) : base(parentNode, tokens)
    {
    }
}