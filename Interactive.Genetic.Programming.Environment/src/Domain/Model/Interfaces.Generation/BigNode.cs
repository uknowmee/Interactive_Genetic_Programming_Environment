using Model.Extensions;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Big.If;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Interfaces.Generation;

public enum BigNodeType
{
    Assignment,
    FunctionCallOut,
    IfStatement,
    ForStatement,
}

public abstract class BigNode : Node
{
    protected readonly List<VarExpression> _programVariables = [];

    protected List<Node> ChildrenNodes { get; } = new();
    public abstract int Indent { get; protected set; }
    protected abstract int ParentIndent { get; }
    protected double NextChildChance { get; init; }
    public double NextDeepNodeChance { get; protected init; }
    public abstract double ParentNextDeepNodeChance { get; }
    
    public abstract void AddBigNode();
    
    public void AddBigNodes()
    {
        while (RandomService.RandomPercentage() < NextChildChance)
        {
            AddBigNode();
        }
    }
    public abstract void AddBigNodeInside();

    public abstract int GetRandomLine();
    
    public void SwapTwoLines()
    {
        var node1Idx = GetRandomLine();
        var node2Idx = GetRandomLine();

        while (node1Idx == node2Idx)
        {
            node2Idx = GetRandomLine();
        }

        ChildrenNodes.Swap(node1Idx, node2Idx);
    }
    public void DeleteRandomLine() => ChildrenNodes.RemoveAt(GetRandomLine());

    protected virtual void SetIndent(int toSet)
    {
        Indent = toSet;
    }
    
    public void ReCalculateIndent() => SetIndent(ParentIndent + 1);

    public void ClearVariables() => _programVariables.Clear();

    protected Node AddNode(Node child)
    {
        ChildrenNodes.Add(child);
        return child;
    }
    
    public Node GetRandomNode()
    {
        var randomNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
        
        return randomNodeType switch
        {
            BigNodeType.Assignment => new Assignment(this),
            BigNodeType.FunctionCallOut => RandomService.RandomPercentage() < 0.5
                ? new Assignment(this)
                : new FunctionCallOut(this),
            BigNodeType.IfStatement => RandomService.RandomPercentage() < NextDeepNodeChance
                ? new IfStatement(this)
                : RandomService.RandomPercentage() < 0.5
                    ? new Assignment(this)
                    : new FunctionCallOut(this),
            BigNodeType.ForStatement => RandomService.RandomPercentage() < NextDeepNodeChance
                ? new ForStatement(this)
                : RandomService.RandomPercentage() < 0.5
                    ? new Assignment(this)
                    : new FunctionCallOut(this),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public void ReAttachSubtree(Node oldNode, Node newNode)
    {
        SetChildNode(oldNode, newNode);

        if (newNode is not (ForStatement or IfStatement)) return;
        
        var bigNode = newNode as BigNode ?? throw new NullReferenceException();
        bigNode.AddBigNode();
        bigNode.AddBigNodes();
    }

    private void SetChildNode(Node oldNode, Node newNode)
    {
        var nodeIdx = ChildrenNodes.IndexOf(oldNode);

        ChildrenNodes.Remove(oldNode);
        ChildrenNodes.Insert(nodeIdx, newNode);
    }

    protected BigNode(Node? parentNode, string name, bool isLast) : base(parentNode, name, isLast)
    {
    }
}