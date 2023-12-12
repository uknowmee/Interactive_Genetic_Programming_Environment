﻿using Model.Extensions;
using Model.Nodes;
using Model.Nodes.Big.Assignment;
using Model.Nodes.Big.ForStatement;
using Model.Nodes.Big.FunctionCallOut;
using Model.Nodes.Big.IfStatement;
using Utils;

namespace Model.Interfaces.Generation;

public enum BigNodeType
{
    Assignment,
    FunctionCallOut,
    IfStatement,
    ForStatement,
}

public interface IBigNode
{
    public void AddBigNode();
    public void AddBigNodes();
    public void AddBigNodeInside();

    public void GetRandomLine();
    public void SwapTwoLines();
    public void DeleteLine();

    protected abstract int Indent { get; set; }
    protected abstract int ParentIndent { get; set; }
    protected abstract double NextChildChance { get; set; }

    protected abstract double NextDeepNodeChance { get; set; }
    protected abstract double ParentNextDeepNodeChance { get; set; }

    protected void SetIndent(int toSet);
    private void ReCalculateIndent() => SetIndent(ParentIndent + 1);

    public void ClearVariables();

    public static sealed Node GetRandomNode(Node parent, double nextDeepNodeChance)
    {
        var randomNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
        
        return randomNodeType switch
        {
            BigNodeType.Assignment => new Assignment(parent),
            BigNodeType.FunctionCallOut => PercentagesService.RandomPercentage() < 0.5
                ? new Assignment(parent)
                : new FunctionCallOut(parent),
            BigNodeType.IfStatement => PercentagesService.RandomPercentage() < nextDeepNodeChance
                ? new IfStatement(parent)
                : PercentagesService.RandomPercentage() < 0.5
                    ? new Assignment(parent)
                    : new FunctionCallOut(parent),
            BigNodeType.ForStatement => PercentagesService.RandomPercentage() < nextDeepNodeChance
                ? new ForStatement(parent)
                : PercentagesService.RandomPercentage() < 0.5
                    ? new Assignment(parent)
                    : new FunctionCallOut(parent),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public sealed void ReAttachSubtree(Node oldNode, Node newNode)
    {
        SetChildNode(oldNode, newNode);

        if (newNode is not (ForStatement or IfStatement)) return;
        
        var bigNode = newNode as IBigNode ?? throw new NullReferenceException();
        bigNode.AddBigNode();
        bigNode.AddBigNodes();
    }

    private void SetChildNode(Node oldNode, Node newNode)
    {
        var current = this as Node ?? throw new NullReferenceException();
        var childrenNodes = current.ChildrenNodes ?? throw new NullReferenceException();
        var nodeIdx = childrenNodes.IndexOf(oldNode);

        childrenNodes.Remove(oldNode);
        childrenNodes.Insert(nodeIdx, newNode);
    }
}