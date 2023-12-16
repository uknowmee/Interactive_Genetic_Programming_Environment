using CommunityToolkit.Diagnostics;
using Model.Abstract;
using Model.Interfaces;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes.Big.Assignments;

public enum AssignmentChild
{
    Expression,
    FunctionCallIn
}

public sealed class Assignment : Node, ISubtreeMutable
{
    public VarExpression Variable { get; set; }
    public StandardExpression? Expression { get; set; }
    public FunctionCallIn? Read { get; set; }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(Variable.ChildrenAsNodes());
        nodes.AddRange(
            Expression?.ChildrenAsNodes()
            ?? Read?.ChildrenAsNodes()
            ?? throw new InvalidOperationException("Both expression and read are null")
        );
        return nodes;
    }

    public void SubtreeMutate()
    {
        var parent = ParentNode as BigNode ?? throw new InvalidOperationException("Parent is not a big node");
        var node = parent.GetRandomNode();
        parent.ReAttachSubtree(this, node);
    }

    private void FromTokens(List<Token> tokens)
    {
        switch (tokens[0].Name)
        {
            case "VarExpression":
                Variable = new VarExpression(this, tokens);
                break;
            case "Expression":
                Expression = new StandardExpression(this, tokens);
                break;
            case "FunctionCallIn":
                Read = new FunctionCallIn(this, tokens);
                break;
        }
    }

    // hardcoded for expression
    public Assignment(Node parentNode) : base(parentNode, "Assignment", true)
    {
        Expression = new StandardExpression(this);
        Variable = new VarExpression(this, true);
    }

    // only during program input declaration
    public Assignment(Node parentNode, bool shouldVarAlreadyExist) : base(parentNode, "Assignment", true)
    {
        Guard.IsFalse(shouldVarAlreadyExist);
        Variable = new VarExpression(this, shouldVarAlreadyExist);
        Read = new FunctionCallIn(this);
    }

    public Assignment(Node parentNode, List<Token> tokens) : base(parentNode, "Assignment", true)
    {
        tokens.RemoveAt(0);
        FromTokens(tokens);
        FromTokens(tokens);
    }

    public override string ToString()
        => Read is null
            ? $"{Variable.Name} = {Expression}"
            : $"{Variable.Name} = {Read}";
}