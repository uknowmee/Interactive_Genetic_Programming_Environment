﻿using Model.Interfaces;
using Model.Interfaces.Evolution;

namespace Model.Nodes.Small;

public abstract class Operator : Node, IPointMutable, ITerminal
{
    public string Value { get; set; } = string.Empty;

    public string OperatorValue => Value.Replace(" ", "");

    public override List<Node> ChildrenAsNodes() => [this];

    public abstract void Mutate();

    public Operator(Node parentNode, string name) : base(parentNode, name, true)
    {
    }

    public Operator(Node parentNode, IList<Token> tokens) : base(parentNode, tokens[0].Name, true)
    {
        var token = tokens[0];
        tokens.RemoveAt(0);
        Value = token.Value ?? throw new NullReferenceException();
    }

    public override string ToString() => Value;
}