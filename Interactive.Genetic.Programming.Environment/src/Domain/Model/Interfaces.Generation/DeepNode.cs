using Model.Extensions;
using Model.Interfaces.Evolution;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Big.If;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Interfaces.Generation;

public abstract class DeepNode : Node, IBigNode, ICrossable, ISubtreeMutable
{
    protected readonly List<VarExpression> _programVariables = [];

    public int Indent { get; protected set; }

    public int ParentIndent
        => ParentNode is IBigNode bigNode
            ? bigNode.Indent
            : throw new InvalidOperationException("Parent is not IBigNode");

    public double NextChildChance { get; init; }
    public double NextDeepNodeChance { get; init; }

    public double ParentNextDeepNodeChance
        => ParentNode is IBigNode bigNode
            ? bigNode.NextDeepNodeChance
            : throw new InvalidOperationException("Parent is not IBigNode");

    public override List<VarExpression> ProgramVariables
    {
        get
        {
            var variables = new List<VarExpression>(
                ParentNode?.ProgramVariables
                ?? throw new NullReferenceException("ParentNode is null")
            );

            variables.AddRange(_programVariables);

            return variables;
        }
    }

    public void SetIndent(int toSet)
    {
        Indent = toSet;
    }

    public void ClearVariables()
    {
        _programVariables.Clear();
    }

    public void AddBigNode()
    {
        var bigNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
        switch (bigNodeType)
        {
            case BigNodeType.Assignment:
                AddNode(new Assignment(this));
                break;
            case BigNodeType.FunctionCallOut:
                if (RandomService.RandomPercentage() < 0.5)
                {
                    AddNode(new FunctionCallOut(this));
                }
                else
                {
                    AddNode(new Assignment(this));
                }
                break;
            case BigNodeType.IfStatement:
                if (RandomService.RandomPercentage() < NextDeepNodeChance)
                {
                    var ifStatement = new IfStatement(this);
                    AddNode(ifStatement);
                    ifStatement.AddBigNode();
                    ifStatement.AddBigNodes();
                }
                else
                {
                    AddAssignmentOrFunctionCallOut();
                }
                break;
            case BigNodeType.ForStatement:
                if (RandomService.RandomPercentage() < NextDeepNodeChance)
                {
                    var forStatement = new ForStatement(this);
                    AddNode(forStatement);
                    forStatement.AddBigNode();
                    forStatement.AddBigNodes();
                }
                else
                {
                    AddAssignmentOrFunctionCallOut();
                }
                break;
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
        var bigNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
        var idx = GetRandomLine();
        
        switch (bigNodeType)
        {
            case BigNodeType.Assignment:
                ChildrenNodes.Insert(idx, new Assignment(this));
                break;
            case BigNodeType.FunctionCallOut:
                if (RandomService.RandomPercentage() < 0.5)
                {
                    ChildrenNodes.Insert(idx, new FunctionCallOut(this));
                }
                else
                {
                    ChildrenNodes.Insert(idx, new Assignment(this));
                }
                break;
            case BigNodeType.IfStatement:
                if (RandomService.RandomPercentage() < NextDeepNodeChance)
                {
                    var ifStatement = new IfStatement(this);
                    ChildrenNodes.Insert(idx, ifStatement);
                    ifStatement.AddBigNode();
                    ifStatement.AddBigNodes();
                }
                else
                {
                    AddAssignmentOrFunctionCallOutInside(idx);
                }
                break;
            case BigNodeType.ForStatement:
                if (RandomService.RandomPercentage() < NextDeepNodeChance)
                {
                    var forStatement = new ForStatement(this);
                    ChildrenNodes.Insert(idx, forStatement);
                    forStatement.AddBigNode();
                    forStatement.AddBigNodes();
                }
                else
                {
                    AddAssignmentOrFunctionCallOutInside(idx);
                }
                break;
        }
    }

    public int GetRandomLine()
    {
        return ChildrenNodes.Count == 0
            ? 0
            : RandomService.RandomInt(0, ChildrenNodes.Count);
    }

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

    public void DeleteRandomLine()
    {
        ChildrenNodes.RemoveAt(GetRandomLine());
    }
    public abstract void SubtreeMutate();

    public abstract void AddNodes(List<Token> tokens);

    private void AddAssignmentOrFunctionCallOut()
    {
        if (RandomService.RandomPercentage() < 0.5)
        {
            AddNode(new Assignment(this));
        }
        else
        {
            AddNode(new FunctionCallOut(this));
        }
    }
    
    private void AddAssignmentOrFunctionCallOutInside(int idx)
    {
        if (RandomService.RandomPercentage() < 0.5)
        {
            ChildrenNodes.Insert(idx, new Assignment(this));
        }
        else
        {
            ChildrenNodes.Insert(idx, new FunctionCallOut(this));
        }
    }
    
    protected DeepNode(Node parentNode, string name, bool isLast) : base(parentNode, name, isLast)
    {
    }
}