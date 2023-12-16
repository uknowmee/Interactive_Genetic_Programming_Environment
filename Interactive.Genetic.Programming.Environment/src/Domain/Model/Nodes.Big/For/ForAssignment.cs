using Model.Abstract;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes.Big.For;

public sealed class ForAssignment : Node
{
    public VarExpression Variable { get; }
    public StandardExpression Expression { private get; set; }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(Variable.ChildrenAsNodes());
        nodes.AddRange(Expression.ChildrenAsNodes());
        
        return nodes;
    }

    public ForAssignment(Node parentNode) : base(parentNode, "ForAssignment", true)
    {
        Expression = new StandardExpression(this);
        Variable = new VarExpression(this);
    }
    
    public ForAssignment(Node parentNode, List<Token> tokens) : base(parentNode, "ForAssignment", true)
    {
        tokens.RemoveAt(0);
        Variable = new VarExpression(this, tokens);
        Expression = new StandardExpression(this, tokens);
    }

    public override string ToString() => $"{Variable} = {Expression}";
}