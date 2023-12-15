using Model.Interfaces.Evolution;
using Model.Nodes.Small.Operators.Logic;

namespace Model.Nodes.Small.Expressions.Logic;

public class BooleanExpression : Node, ICrossable, ISubtreeMutable
{
    private LogicExpression Left { get; set; }
    private BoolOperator Operator { get; set; }
    private LogicExpression Right { get; set; }

    public void SetLogicExpression(Node oldExpression, LogicExpression newExpression)
    {
        if (Left == oldExpression)
        {
            Left = newExpression;
        }
        else if (Right == oldExpression)
        {
            Right = newExpression;
        }
        else
        {
            throw new InvalidOperationException("Expression not found");
        }
    }

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(Left.ChildrenAsNodes());
        nodes.AddRange(Operator.ChildrenAsNodes());
        nodes.AddRange(Right.ChildrenAsNodes());

        return nodes;
    }

    public void SubtreeMutate()
    {
        if (ParentNode is LogicExpression expression)
        {
            expression.BooleanExpression = new BooleanExpression(expression);
        }
    }

    public BooleanExpression(Node parentNode) : base(parentNode, "BooleanExpression", true)
    {
        var lastNextLogicExpressionChance = ParentNode is LogicExpression logicExpression
            ? logicExpression.NextLogicBooleanExpressionChance
            : throw new InvalidOperationException("Parent node is not a logic expression");

        Left = new LogicExpression(this, lastNextLogicExpressionChance);
        Operator = new BoolOperator(this);
        Right = new LogicExpression(this, lastNextLogicExpressionChance);
    }

    public BooleanExpression(Node parentNode, List<Token> tokens) : base(parentNode, "BooleanExpression", true)
    {
        tokens.RemoveAt(0);

        var lastNextLogicExpressionChance = ParentNode is LogicExpression logicExpression
            ? logicExpression.NextLogicBooleanExpressionChance
            : throw new InvalidOperationException("Parent node is not a logic expression");

        Left = new LogicExpression(this, tokens, lastNextLogicExpressionChance);
        Operator = new BoolOperator(this, tokens);
        Right = new LogicExpression(this, tokens, lastNextLogicExpressionChance);
    }

    public override string ToString() => $"({Left} {Operator} {Right})";
}