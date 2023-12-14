using Model.Extensions;
using Model.Interfaces.Evolution;
using Model.Interfaces.Generation;
using Model.Nodes.Small.Constants;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes.Small;

public partial class StandardExpression : Node, IStandardExpression, ICrossable, ISubtreeMutable
{
    private Constant? _constant;
    private VarExpression? _varExpression;
    private MultiplicativeExpression? _multiplicativeExpression;
    private AdditiveExpression? _additiveExpression;

    public double NextTwoArgExpressionChance { get; init; }
}