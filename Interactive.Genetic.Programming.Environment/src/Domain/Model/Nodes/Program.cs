using Model.Interfaces.Generation;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes;

public class Program : Node, IBigNode
{
    public int Inputs { get; private set; }
    public int Indent { get; init; } = 0;
    public int ParentIndent => Indent;
    public double NextChildChance { get; init; }
    public double NextDeepNodeChance { get; init; }
    public double ParentNextDeepNodeChance { get; init; }
    public override List<VarExpression> ProgramVariables { get; } = [];

    public override List<Node>? ChildrenAsNodes()
    {
        throw new NotImplementedException();
    }

    public void AddBigNode()
    {
        throw new NotImplementedException();
    }

    public void AddBigNodes()
    {
        throw new NotImplementedException();
    }

    public void AddBigNodeInside()
    {
        throw new NotImplementedException();
    }

    public void GetRandomLine()
    {
        throw new NotImplementedException();
    }

    public void SwapTwoLines()
    {
        throw new NotImplementedException();
    }

    public void DeleteLine()
    {
        throw new NotImplementedException();
    }

    public void SetIndent(int toSet)
    {
        throw new NotImplementedException();
    }

    public void ClearVariables()
    {
        throw new NotImplementedException();
    }

    public Program(Node? parentNode, string name, bool isLast) : base(parentNode, name, isLast)
    {
    }
}