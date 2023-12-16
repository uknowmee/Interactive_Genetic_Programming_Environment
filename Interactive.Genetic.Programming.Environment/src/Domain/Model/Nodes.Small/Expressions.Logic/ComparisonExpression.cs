using Model.Abstract;
using Model.Interfaces;
using Model.Nodes.Big.For;
using Model.Nodes.Small.Expressions.Standard;
using Model.Nodes.Small.Operators.Logic;

namespace Model.Nodes.Small.Expressions.Logic;

public class ComparisonExpression : Node, ICrossable, ISubtreeMutable
{
    private StandardExpression Left { get; set; }
    private CompareOperator Operator { get; set; }
    private StandardExpression Right { get; set; }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(Left.ChildrenAsNodes());
        nodes.AddRange(Operator.ChildrenAsNodes());
        nodes.AddRange(Right.ChildrenAsNodes());

        return nodes;
    }

    public void SetExpression(Node oldExpression, StandardExpression newExpression)
    {
        if (Left == oldExpression)
        {
            Left = newExpression;
        }
        else
        {
            Right = newExpression;
        }
    }

    public void SubtreeMutate()
    {
        if (ParentNode is ForStatement forStatement)
        {
            forStatement.ComparisonExpression = new ComparisonExpression(forStatement, forStatement.NextComparisonExpressionChance);
        }
        else if (ParentNode is LogicExpression logicExpression)
        {
            logicExpression.ComparisonExpression = new ComparisonExpression(logicExpression);
        }
    }

    public ComparisonExpression(Node parentNode)
        : base(parentNode, "ComparisonExpression", true)
    {
        var lastNextLogicExpressionChance = ParentNode is LogicExpression logicExpression
            ? logicExpression.NextLogicBooleanExpressionChance
            : throw new InvalidOperationException("Parent node is not a LogicExpression");
        
        Left = new StandardExpression(this, lastNextLogicExpressionChance);
        Operator = new CompareOperator(this);
        Right = new StandardExpression(this, lastNextLogicExpressionChance);
    }
    
    public ComparisonExpression(Node parentNode, double newExpressionInForComparisonChance)
        : base(parentNode, "ComparisonExpression", true)
    {
        Left = new StandardExpression(this, newExpressionInForComparisonChance);
        Operator = new CompareOperator(this);
        Right = new StandardExpression(this, newExpressionInForComparisonChance);
    }
    
    public ComparisonExpression(Node parentNode, List<Token> tokens)
        : base(parentNode, "ComparisonExpression", true)
    {
        tokens.RemoveAt(0);
        
        var lastNextLogicExpressionChance = ParentNode is LogicExpression logicExpression
            ? logicExpression.NextLogicBooleanExpressionChance
            : throw new InvalidOperationException("Parent node is not a LogicExpression");
        
        Left = new StandardExpression(this, tokens, lastNextLogicExpressionChance);
        Operator = new CompareOperator(this, tokens);
        Right = new StandardExpression(this, tokens, lastNextLogicExpressionChance);
    }
    
    public ComparisonExpression(Node parentNode, List<Token> tokens, double newExpressionInForComparisonChance)
        : base(parentNode, "ComparisonExpression", true)
    {
        tokens.RemoveAt(0);
        
        Left = new StandardExpression(this, tokens, newExpressionInForComparisonChance);
        Operator = new CompareOperator(this, tokens);
        Right = new StandardExpression(this, tokens, newExpressionInForComparisonChance);
    }

    public override string ToString() => $"{Left} {Operator} {Right}";
}