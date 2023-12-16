using System.Text;
using Model.Abstract;

namespace Model.Nodes.Big.Program.Root;

public partial class Program
{
    protected override void SetIndent(int toSet)
    {
    }

    public override string ToString()
    {
        var program = new StringBuilder();

        foreach (var node in ChildrenNodes)
        {
            if (node is BigNode addRandomNode)
            {
                addRandomNode.ReCalculateIndent();
            }
        }

        foreach (var node in ChildrenNodes)
        {
            program.Append(node);
            if (!node.Equals(ChildrenNodes[^1]))
            {
                program.Append('\n');
            }
        }

        return program.ToString();
    }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node>();
        foreach (var node in ChildrenNodes)
        {
            nodes.AddRange(node.ChildrenAsNodes() ?? []);
        }

        return nodes;
    }

    public override List<Node> ChildrenAsNodesWithBlocks()
    {
        var nodes = new List<Node>();
        foreach (var node in ChildrenNodes)
        {
            nodes.AddRange(node.ChildrenAsNodesWithBlocks() ?? []);
        }

        return nodes;
    }
}