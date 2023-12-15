using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes.Big.For;

public class ForAssignment : Node
{
    public VarExpression VarExpression { get; set; }
    public StandardExpression Expression { private get; set; }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(VarExpression.ChildrenAsNodes());
        nodes.AddRange(Expression.ChildrenAsNodes());
        
        return nodes;
    }

    public ForAssignment(Node parentNode) : base(parentNode, "ForAssignment", true)
    {
        Expression = new StandardExpression(this);
        VarExpression = new VarExpression(this);
    }
    
    public ForAssignment(Node parentNode, List<Token> tokens) : base(parentNode, "ForAssignment", true)
    {
        tokens.RemoveAt(0);
        VarExpression = new VarExpression(this, tokens);
        Expression = new StandardExpression(this, tokens);
    }

    public override string ToString() => $"{VarExpression} = {Expression}";
}