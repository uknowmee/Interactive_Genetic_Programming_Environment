using Model.Interfaces.Evolution;
using Model.Interfaces.Generation;

namespace Model.Nodes.Small.Expressions.Logic;

public partial class LogicExpression : Node, ILogicExpression, ICrossable, ISubtreeMutable
{
    private ComparisonExpression? _comparisonExpression;
    private BooleanExpression? _booleanExpression;

    public double NextLogicBooleanExpressionChance { get; init; }

    public ComparisonExpression ComparisonExpression
    {
        set => _comparisonExpression = value;
    }

    public BooleanExpression BooleanExpression
    {
        set => _booleanExpression = value;
    }
}