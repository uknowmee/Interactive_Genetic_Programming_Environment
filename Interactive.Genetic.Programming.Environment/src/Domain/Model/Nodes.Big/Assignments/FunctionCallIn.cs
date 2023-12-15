﻿using Model.Extensions;
using Model.Interfaces;

namespace Model.Nodes.Big.Assignments;

public class FunctionCallIn : Node, ITerminal
{
    public string Value { get; }

    public override List<Node> ChildrenAsNodes() => [this];

    public FunctionCallIn(Node parentNode) : base(parentNode, "FunctionCallIn", true)
    {
        Value = "read()";
    }
    
    public FunctionCallIn(Node parentNode, IList<Token> tokens) : base(parentNode, "FunctionCallIn", true)
    {
        Value = tokens.PopFront().Value ?? throw new Exception("Token value cannot be null");
    }
}