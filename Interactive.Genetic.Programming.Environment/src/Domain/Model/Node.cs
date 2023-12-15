using Model.Nodes.Small.Expressions.Standard;

namespace Model;

public abstract class Node
{
    public string Name { get; init; }
    public Node? ParentNode { get; set; }
    public bool IsLast { get; init; }


    public abstract List<Node>? ChildrenAsNodes();
    public virtual List<Node>? ChildrenAsNodesWithBlocks() => ChildrenAsNodes();
    public void DeleteParent() => ParentNode = null;

    public virtual List<VarExpression> ProgramVariables
        => ParentNode?.ProgramVariables
           ?? throw new InvalidOperationException("Tried to get program variables from a node without a parent");

    public virtual bool AddToProgramVariables(VarExpression varExpression)
        => ParentNode?.AddToProgramVariables(varExpression)
           ?? throw new InvalidOperationException("Tried to add a variable to a node without a parent");

    protected Node(Node? parentNode, string name, bool isLast)
        => (ParentNode, Name, IsLast) = (parentNode, name, isLast);
}