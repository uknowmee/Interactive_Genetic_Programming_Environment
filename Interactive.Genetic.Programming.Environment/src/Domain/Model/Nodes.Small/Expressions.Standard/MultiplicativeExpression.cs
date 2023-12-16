using Model.Abstract;
using Model.Interfaces;
using Model.Nodes.Small.Operators.Arithmetic;

namespace Model.Nodes.Small.Expressions.Standard;

public sealed class MultiplicativeExpression : TwoArgExpression, ICrossable, ISubtreeMutable
{
    public override StandardExpression Left { get; protected set; }
    public override Operator Operator { get; protected set; }
    public override StandardExpression Right { get; protected set; }
    
    public MultiplicativeExpression(Node parentNode) : base(parentNode, "MultiplicativeExpression", true)
    {
        var lastNextTwoArgExpressionChance = parentNode is StandardExpression expression
            ? expression.NextTwoArgExpressionChance
            : throw new InvalidOperationException("Parent node is not an expression");

        Left = new StandardExpression(this, lastNextTwoArgExpressionChance);
        Operator = new MultiplicativeOperator(this);
        Right = new StandardExpression(this, lastNextTwoArgExpressionChance);
    }

    public MultiplicativeExpression(Node parentNode, StandardExpression left, StandardExpression right, string op)
        : base(parentNode, "MultiplicativeExpression", true)
    {
        Left = left;

        Operator = new MultiplicativeOperator(this);
        while (Operator.Value == op)
        {
            Operator = new MultiplicativeOperator(this);
        }

        Right = right;
    }

    public MultiplicativeExpression(Node parentNode, List<Token> tokens) : base(parentNode, "MultiplicativeExpression", true)
    {
        tokens.RemoveAt(0);

        var lastNextTwoArgExpressionChance = parentNode is StandardExpression expression
            ? expression.NextTwoArgExpressionChance
            : throw new InvalidOperationException("Parent node is not an expression");

        Left = new StandardExpression(this, tokens, lastNextTwoArgExpressionChance);
        Operator = new MultiplicativeOperator(this, tokens);
        Right = new StandardExpression(this, tokens, lastNextTwoArgExpressionChance);
    }

    public override string ToString() => $"({Left} {Operator} {Right})";
}