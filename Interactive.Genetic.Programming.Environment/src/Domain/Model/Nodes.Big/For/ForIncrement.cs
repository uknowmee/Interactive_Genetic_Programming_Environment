using Model.Interfaces.Evolution;
using Model.Interfaces.Generation;
using Model.Nodes.Small.Constants;
using Model.Nodes.Small.Expressions.Standard;
using Model.Nodes.Small.Operators.Arithmetic;
using Utils;

namespace Model.Nodes.Big.For;

public sealed class ForIncrement : Node, ICrossable, ISubtreeMutable
{
    private AdditiveOperator _additiveOperator;
    private VarExpression? _variable;
    private Constant? _constant;

    public override List<Node> ChildrenAsNodes()
    {
        var nodes = new List<Node> { this };
        nodes.AddRange(_additiveOperator.ChildrenAsNodes());
        nodes.AddRange(_variable is null
            ? _constant?.ChildrenAsNodes() ?? throw new InvalidOperationException("Both variable and constant are null")
            : _variable.ChildrenAsNodes()
        );
        
        return nodes;
    }

    public void SubtreeMutate()
    {
        if (ParentNode is ForStatement forStatement)
        {
            forStatement.ForIncrement = new ForIncrement(forStatement);
        }
    }

    private void FromTokens(IList<Token> tokens)
    {
        switch (tokens[0].Name)
        {
            case "VarExpression":
                _variable = new VarExpression(this, tokens);
                break;
            case "AdditiveOperator":
                _additiveOperator = new AdditiveOperator(this, tokens);
                break;
            case "Constant":
                _constant = new Constant(this, ConstantType.Int, tokens);
                break;
        }
    }
    
    public ForIncrement(Node parentNode) : base(parentNode, "ForIncrement", true)
    {
        if (RandomService.RandomPercentage() < 50)
        {
            _variable = new VarExpression(this, true);
        }
        else
        {
            _constant = new Constant(this, ConstantType.Int);
        }
        _additiveOperator = new AdditiveOperator(this);
    }
    
    public ForIncrement(Node parentNode, List<Token> tokens) : base(parentNode, "ForIncrement", true)
    {
        tokens.RemoveAt(0);
        FromTokens(tokens);
        FromTokens(tokens);
    }

    public override string ToString()
        => _variable is null
            ? $"{_additiveOperator.OperatorValue}{_constant}"
            : $"{_additiveOperator.OperatorValue}{_variable}";
}