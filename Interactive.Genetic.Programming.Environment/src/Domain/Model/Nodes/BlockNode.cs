namespace Model.Nodes;

public class BlockNode : Node
{
    public override List<Node>? ChildrenAsNodes() => null;

    public BlockNode(string name) : base(null, name, false)
    {
    }

    public override string ToString() => Name;
}