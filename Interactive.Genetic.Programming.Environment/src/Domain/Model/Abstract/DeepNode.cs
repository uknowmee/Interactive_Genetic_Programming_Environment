using Model.Extensions;
using Model.Interfaces;
using Model.Nodes.Big.Assignments;
using Model.Nodes.Big.For;
using Model.Nodes.Big.FunctionCall;
using Model.Nodes.Big.If;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Abstract;

public abstract class DeepNode : BigNode, ICrossable, ISubtreeMutable
{
    public override int Indent { get; protected set; }

    protected override int ParentIndent
        => ParentNode is BigNode bigNode
            ? bigNode.Indent
            : throw new InvalidOperationException("Parent is not IBigNode");

    public override double ParentNextDeepNodeChance
        => ParentNode is BigNode bigNode
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

            variables.AddRange(Variables);

            return variables;
        }
    }

    public override void AddBigNode()
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

    public override void AddBigNodeInside()
    {
        var bigNodeType = EnumExtensions.GetRandomValue<BigNodeType>();
        var idx = GetRandomLine();
        
        switch (bigNodeType)
        {
            case BigNodeType.Assignment:
                ChildrenNodes.Insert(idx, new Assignment(this));
                break;
            case BigNodeType.FunctionCallOut:
                if (RandomService.RandomPercentage() < 0.50)
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

    public override int GetRandomLine()
    {
        return ChildrenNodes.Count == 0
            ? 0
            : RandomService.RandomInt(0, ChildrenNodes.Count);
    }

    public void SubtreeMutate()
    {
        var parent = ParentNode as BigNode ?? throw new InvalidOperationException("Parent is not IBigNode");
        var node = parent.GetRandomNode();
        parent.ReAttachSubtree(this, node);
    }
    
    public abstract void AddNodes(List<Token> tokens);

    private void AddAssignmentOrFunctionCallOut()
    {
        if (RandomService.RandomPercentage() < 0.50)
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
        if (RandomService.RandomPercentage() < 0.50)
        {
            ChildrenNodes.Insert(idx, new Assignment(this));
        }
        else
        {
            ChildrenNodes.Insert(idx, new FunctionCallOut(this));
        }
    }

    protected override bool AddToProgramVariables(VarExpression varExpression)
    {
        var parentVariables = ParentNode?.ProgramVariables
                              ?? throw new NullReferenceException("ParentNode is null");

        if (Variables.Any(variable => variable.Value == varExpression.Value))
        {
            return false;
        }
        
        if (parentVariables.Any(variable => variable.Value == varExpression.Value))
        {
            return false;
        }
        
        Variables.Add(varExpression);
        return true;
    }

    protected DeepNode(Node parentNode, string name, bool isLast) : base(parentNode, name, isLast)
    {
    }
}