namespace Model.Nodes.Small.Expressions.Standard;

public partial class StandardExpression
{
    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };

        if (_constant != null)
        {
            nodes.AddRange(_constant.ChildrenAsNodes());
        }
        else if (_varExpression != null)
        {
            nodes.AddRange(_varExpression.ChildrenAsNodes());
        }
        else if (_multiplicativeExpression != null)
        {
            nodes.AddRange(_multiplicativeExpression.ChildrenAsNodes());
        }
        else if (_additiveExpression != null)
        {
            nodes.AddRange(_additiveExpression.ChildrenAsNodes());
        }

        return nodes;
    }

    public override string ToString()
    {
        return _constant?.ToString()
               ?? _varExpression?.ToString()
               ?? _multiplicativeExpression?.ToString() 
               ?? _additiveExpression?.ToString() 
               ?? "";
    }
}