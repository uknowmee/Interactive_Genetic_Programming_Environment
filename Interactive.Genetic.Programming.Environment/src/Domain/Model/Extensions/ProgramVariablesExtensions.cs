using Model.Nodes.Small.Expressions.Standard;

namespace Model.Extensions;

public static class ProgramVariablesExtensions
{
    public static List<int> GetIndexes(this IEnumerable<VarExpression> variables)
    {
        return variables.Select(var => var.Value.Split("_")[1]).Select(int.Parse).ToList();
    }
}