using Model.Abstract;

namespace Model.Nodes.Small.Expressions.Logic;

public partial class LogicExpression
{
    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };

        if (_comparisonExpression != null)
        {
            nodes.AddRange(_comparisonExpression.ChildrenAsNodes());
        }
        else if (_booleanExpression != null)
        {
            nodes.AddRange(_booleanExpression.ChildrenAsNodes());
        }

        return nodes;
    }

    public override string ToString()
    {
        return _comparisonExpression?.ToString()
               ?? _booleanExpression?.ToString()
               ?? "";
    }
}