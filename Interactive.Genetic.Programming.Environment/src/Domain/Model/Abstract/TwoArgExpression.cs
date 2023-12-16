using Model.Nodes.Small;
using Model.Nodes.Small.Expressions.Standard;
using Utils;

namespace Model.Abstract;

public abstract class TwoArgExpression : Node
{
    public abstract StandardExpression Left { get; protected set; }
    public abstract Operator Operator { get; protected set; }
    public abstract StandardExpression Right { get; protected set; }

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
        if (ParentNode is StandardExpression expression)
        {
            expression.SubtreeMutateTwoArgExpression();
        }
    }

    public void Mutate()
    {
        var (left, right, op) = this switch
        {
            AdditiveExpression additiveExpression
                => (additiveExpression.Left, additiveExpression.Right, additiveExpression.Operator.Value),
            MultiplicativeExpression multiplicativeExpression
                => (multiplicativeExpression.Left, multiplicativeExpression.Right, multiplicativeExpression.Operator.Value),
            _ => throw new InvalidOperationException("Expression not found")
        };

        MutateOperator(left, right, op);
    }

    private void MutateOperator(StandardExpression left, StandardExpression right, string op)
    {
        var current = this as Node ?? throw new NullReferenceException();
        var parent = current.ParentNode;
        var parentAsExpression = parent as StandardExpression ?? throw new NullReferenceException();

        if (RandomService.RandomPercentage() < 0.5)
        {
            var additiveExpression = new AdditiveExpression(parent, left, right, op);
            parentAsExpression.AdditiveExpression = additiveExpression;
        }
        else
        {
            var multiplicativeExpression = new MultiplicativeExpression(parent, left, right, op);
            parentAsExpression.MultiplicativeExpression = multiplicativeExpression;
        }
    }

    public TwoArgExpression(Node parentNode, string name, bool isLast) : base(parentNode, name, isLast)
    {
    }
}