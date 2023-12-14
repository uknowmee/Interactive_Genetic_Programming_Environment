using Model.Extensions;
using Model.Interfaces.Evolution;
using Model.Interfaces.Generation;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Big.If;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Nodes.Big.Program.Root;

public partial class Program
{
    public void ClearVariables() => ProgramVariables.Clear();

    public void UpdateVariables()
    {
        var nodes = ChildrenAsNodes() ?? [];
        ClearVariables();

        foreach (var node in nodes)
        {
            if (node is IBigNode addRandomBaseNode)
            {
                addRandomBaseNode.ClearVariables();
            }
        }

        foreach (var node in nodes)
        {
            if (node is VarExpression varExpression)
            {
                AddToProgramVariables(varExpression);
            }
        }
    }

    public override bool AddToProgramVariables(VarExpression varExpression)
    {
        if (ProgramVariables.Any(variable => variable.Name == varExpression.Name))
        {
            return false;
        }

        ProgramVariables.Add(varExpression);
        return true;
    }

    public List<Node>? PointMutableNodes()
    {
        var nodes = ChildrenAsNodes() ?? [];
        nodes.RemoveAll(node => node is not IPointMutable);
        nodes.RemoveAll(node => node is IPointMutable pointMutable && pointMutable.IsMutable() is false);
        return nodes;
    }

    public List<Node>? SubtreeMutableNodes()
    {
        var nodes = ChildrenAsNodes() ?? [];
        nodes.RemoveAll(node => node is not ISubtreeMutable);
        nodes.RemoveAll(node => node is ISubtreeMutable subtreeMutable && subtreeMutable.IsMutable() is false);
        return nodes;
    }

    public void AddBigNode()
    {
        var probCounter = 0;

        while (true)
        {
            var bigNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
            switch (bigNodeType)
            {
                case BigNodeType.Assignment:
                    AddNode(new Assignment(this);
                    return;
                case BigNodeType.FunctionCallOut when probCounter++ > 0:
                    AddNode(new FunctionCallOut(this));
                    return;
                case BigNodeType.IfStatement:
                    var ifStatement = new IfStatement(this);
                    AddNode(ifStatement);
                    ifStatement.AddBigNode();
                    ifStatement.AddBigNodes();
                    return;
                case BigNodeType.ForStatement:
                    var forStatement = new ForStatement(this);
                    AddNode(forStatement);
                    forStatement.AddBigNode();
                    forStatement.AddBigNodes();
                    return;
            }
        }
    }

    public void AddBigNodes()
    {
        while (RandomService.RandomPercentage() < NextChildChance)
        {
            AddBigNode();
        }
    }

    public void AddBigNodeInside()
    {
        var probCounter = 0;
        var idx = GetRandomLine();

        while (true)
        {
            var bigNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
            switch (bigNodeType)
            {
                case BigNodeType.Assignment:
                    ChildrenNodes.Insert(idx, new Assignment(this));
                    return;
                case BigNodeType.FunctionCallOut when probCounter++ > 0:
                    ChildrenNodes.Insert(idx, new FunctionCallOut(this));
                    return;
                case BigNodeType.IfStatement:
                    var ifStatement = new IfStatement(this);
                    ChildrenNodes.Insert(idx, ifStatement);
                    ifStatement.AddRandomNode();
                    ifStatement.AddRandomNodes();
                    return;
                case BigNodeType.ForStatement:
                    var forStatement = new ForStatement(this);
                    ChildrenNodes.Insert(idx, forStatement);
                    forStatement.AddRandomNode();
                    forStatement.AddRandomNodes();
                    return;
            }
        }
    }

    public int GetRandomLine()
    {
        return ChildrenNodes?.Count == Inputs
            ? Inputs
            : new Random().Next(Inputs, ChildrenNodes?.Count ?? 0);
    }

    public void SwapTwoLines()
    {
        var node1Idx = GetRandomLine();
        var node2Idx = GetRandomLine();

        while (node1Idx == node2Idx)
        {
            node2Idx = GetRandomLine();
        }

        ChildrenNodes?.Swap(node1Idx, node2Idx);
    }

    public void DeleteRandomLine() => ChildrenNodes?.RemoveAt(GetRandomLine());
}