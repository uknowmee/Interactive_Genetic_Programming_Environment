using System.Text.RegularExpressions;
using Model.Interfaces.Generation;
using Model.Nodes.Small.Expressions.Standard;

namespace Model.Nodes.Big.Program.Root;

public sealed partial class Program : BigNode
{
    public int Inputs { get; private set; }
    public override int Indent { get; protected set; } = 0;
    protected override int ParentIndent => Indent;
    public override double ParentNextDeepNodeChance => NextDeepNodeChance;
    public override List<VarExpression> ProgramVariables => _programVariables;
    public int Length => MyRegex().Split(AsString()).Length;

    [GeneratedRegex("\r\n|\r|\n")]
    private static partial Regex MyRegex();
}