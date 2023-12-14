using Model.Extensions;
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
    protected int Indent { get; init; }
    protected int ParentIndent { get; }
    protected double NextChildChance { get; init; }
    protected double NextDeepNodeChance { get; init; }
    protected double ParentNextDeepNodeChance { get; }
    
    public void AddBigNode();
    public void AddBigNodes();
    public void AddBigNodeInside();

    public int GetRandomLine();
    public void SwapTwoLines();
    public void DeleteRandomLine();

    protected void SetIndent(int toSet);
    public void ReCalculateIndent() => SetIndent(ParentIndent + 1);

    public void ClearVariables();

    public static sealed Node GetRandomNode(Node parent, double nextDeepNodeChance)
    {
        var randomNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
        
        return randomNodeType switch
        {
            BigNodeType.Assignment => new Assignment(parent),
            BigNodeType.FunctionCallOut => RandomService.RandomPercentage() < 0.5
                ? new Assignment(parent)
                : new FunctionCallOut(parent),
            BigNodeType.IfStatement => RandomService.RandomPercentage() < nextDeepNodeChance
                ? new IfStatement(parent)
                : RandomService.RandomPercentage() < 0.5
                    ? new Assignment(parent)
                    : new FunctionCallOut(parent),
            BigNodeType.ForStatement => RandomService.RandomPercentage() < nextDeepNodeChance
                ? new ForStatement(parent)
                : RandomService.RandomPercentage() < 0.5
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