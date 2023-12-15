﻿using System.Text;
using Model.Interfaces.Generation;

namespace Model.Nodes.Big.Program.Root;

public partial class Program
{
    public void SetIndent(int toSet)
    {
    }

    public string AsString()
    {
        var program = new StringBuilder();
        var nodes = ChildrenNodes ?? [];

        foreach (var node in nodes)
        {
            if (node is IBigNode addRandomNode)
            {
                addRandomNode.ReCalculateIndent();
            }
        }

        foreach (var node in nodes)
        {
            program.Append(node);
            if (!node.Equals(nodes[^1]))
            {
                program.Append('\n');
            }
        }

        return program.ToString();
    }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node>();
        foreach (var node in ChildrenNodes ?? [])
        {
            nodes.AddRange(node.ChildrenAsNodes() ?? []);
        }

        return nodes;
    }

    public override List<Node> ChildrenAsNodesWithBlocks()
    {
        var nodes = new List<Node>();
        foreach (var node in ChildrenNodes ?? [])
        {
            nodes.AddRange(node.ChildrenAsNodesWithBlocks() ?? []);
        }

        return nodes;
    }
}