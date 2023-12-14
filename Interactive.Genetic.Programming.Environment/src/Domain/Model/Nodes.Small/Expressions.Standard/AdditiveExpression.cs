using Model.Interfaces.Evolution;
using Model.Nodes.Small.Operators.Arithmetic;

namespace Model.Nodes.Small.Expressions.Standard;

public sealed class AdditiveExpression : TwoArgExpression, ICrossable, ISubtreeMutable
{
    public override StandardExpression Left { get; protected set; }
    public override Operator Operator { get; protected set; }
    public override StandardExpression Right { get; protected set; }

    public AdditiveExpression(Node parentNode) : base(parentNode, "AdditiveExpression", true)
    {
        var lastNextTwoArgExpressionChance = parentNode is StandardExpression expression
            ? expression.NextTwoArgExpressionChance
            : throw new InvalidOperationException("Parent node is not an expression");

        Left = new StandardExpression(this, lastNextTwoArgExpressionChance);
        Operator = new AdditiveOperator(this);
        Right = new StandardExpression(this, lastNextTwoArgExpressionChance);
    }

    public AdditiveExpression(Node parentNode, StandardExpression left, StandardExpression right, string op)
        : base(parentNode, "AdditiveExpression", true)
    {
        Left = left;

        Operator = new AdditiveOperator(this);
        while (Operator.Value == op)
        {
            Operator = new AdditiveOperator(this);
        }

        Right = right;
    }

    public AdditiveExpression(Node parentNode, List<Token> tokens) : base(parentNode, "AdditiveExpression", true)
    {
        tokens.RemoveAt(0);

        var lastNextTwoArgExpressionChance = parentNode is StandardExpression expression
            ? expression.NextTwoArgExpressionChance
            : throw new InvalidOperationException("Parent node is not an expression");

        Left = new StandardExpression(this, tokens, lastNextTwoArgExpressionChance);
        Operator = new AdditiveOperator(this, tokens);
        Right = new StandardExpression(this, tokens, lastNextTwoArgExpressionChance);
    }

    public override string ToString() => $"({Left} {Operator} {Right})";
}