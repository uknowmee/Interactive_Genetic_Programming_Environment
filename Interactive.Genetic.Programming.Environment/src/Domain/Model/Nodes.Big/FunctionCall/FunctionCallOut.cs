﻿using System.Collections;
using Model.Interfaces.Evolution;
using Model.Interfaces.Generation;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes.Big.FunctionCall;

public class FunctionCallOut : Node, ICrossable, ISubtreeMutable
{
    private readonly VarExpression _varExpression;

    public override List<Node> ChildrenAsNodes() => [this, _varExpression];

    public void SubtreeMutate()
    {
        var parent = ParentNode as IBigNode ?? throw new InvalidOperationException("Parent is not a big node");

        var nextDeepNodeChance = parent.NextDeepNodeChance;
        var node = parent.GetRandomNode(this, nextDeepNodeChance);
        parent.ReAttachSubtree(this, node);
    }

    public FunctionCallOut(Node parentNode) : base(parentNode, "FunctionCallOut", true)
    {
        _varExpression = new VarExpression(this, true);
    }
    
    public FunctionCallOut(Node parentNode, IList tokens) : base(parentNode, "FunctionCallOut", true)
    {
        tokens.RemoveAt(0);
        _varExpression = new VarExpression(this, true);
    }

    public override string ToString() => $"write({Name});";
}