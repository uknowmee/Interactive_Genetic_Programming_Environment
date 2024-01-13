using System.Text;

namespace Configuration;

public class ModelConfiguration : IModelConfiguration
{
    public int MaxInt { get; set; } = 100;

    public double NewChildOfProgramNodeChance { get; set; } = 0.80;
    public double NewDeepNodeGenerationChance { get; set; } = 0.30;
    public double NewDeepNodeGenerationFall { get; set; } = 0.05;

    public double NewChildOfForNodeChance { get; set; } = 0.50;
    public double NewExpressionInForComparisonChance { get; set; } = 0.35;

    public double NewChildOfIfNodeChance { get; set; } = 0.50;

    public double NewLogicExpressionChance { get; set; } = 0.40;
    public double NextTwoArgExpressionChance { get; set; } = 0.40;
    public double NewVarExpressionChance { get; set; } = 0.50;
    public IModelConfiguration Copy()
    {
        return new ModelConfiguration
        {
            MaxInt = MaxInt,
            NewChildOfProgramNodeChance = NewChildOfProgramNodeChance,
            NewDeepNodeGenerationChance = NewDeepNodeGenerationChance,
            NewDeepNodeGenerationFall = NewDeepNodeGenerationFall,
            NewChildOfForNodeChance = NewChildOfForNodeChance,
            NewExpressionInForComparisonChance = NewExpressionInForComparisonChance,
            NewChildOfIfNodeChance = NewChildOfIfNodeChance,
            NewLogicExpressionChance = NewLogicExpressionChance,
            NextTwoArgExpressionChance = NextTwoArgExpressionChance,
            NewVarExpressionChance = NewVarExpressionChance
        };
    }

    public override string ToString()
    {
        var properties = GetType().GetProperties();
        var sb = new StringBuilder();
        foreach (var property in properties)
        {
            var value = property.GetValue(this);
            sb.AppendLine($"{property.Name}: {value}");
        }

        return sb.ToString();
    }
}