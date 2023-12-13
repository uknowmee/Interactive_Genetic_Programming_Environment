using System.Text.RegularExpressions;
using Model.Interfaces.Generation;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes;

public partial class Program : Node, IBigNode
{
    private readonly List<VarExpression> _programVariables = [];
    
    public int Inputs { get; private set; }
    public int Indent { get; init; } = 0;
    public int ParentIndent => Indent;
    public double NextChildChance { get; init; }
    public double NextDeepNodeChance { get; init; }
    public double ParentNextDeepNodeChance => NextDeepNodeChance;
    public override List<VarExpression> ProgramVariables => _programVariables;
    public int Length => MyRegex().Split(AsString()).Length;

    [GeneratedRegex("\r\n|\r|\n")]
    private static partial Regex MyRegex();
}