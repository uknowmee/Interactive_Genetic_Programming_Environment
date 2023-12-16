using Model.Abstract;
using Model.Interfaces;
using Model.Nodes.Small.Constants;

namespace Model.Nodes.Small.Expressions.Standard;

public sealed partial class StandardExpression : Node, IStandardExpression, ICrossable, ISubtreeMutable
{
    private Constant? _constant;
    private VarExpression? _varExpression;
    private MultiplicativeExpression? _multiplicativeExpression;
    private AdditiveExpression? _additiveExpression;

    public AdditiveExpression AdditiveExpression
    {
        set
        {
            _multiplicativeExpression = null;
            _additiveExpression = value;
        }
    }

    public MultiplicativeExpression MultiplicativeExpression
    {
        set
        {
            _additiveExpression = null;
            _multiplicativeExpression = value;
        }
    }
    
    public double NextTwoArgExpressionChance { get; init; }
}