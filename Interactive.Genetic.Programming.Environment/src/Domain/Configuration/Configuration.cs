using System.Text;

namespace Configuration;

public class Configuration : IConfiguration
{
    public int MaxInt { get; set; } = 100;

    public double NewChildOfProgramNodeChance { get; set; } = 0.8;
    public double NewDeepNodeGenerationChance { get; set; } = 0.3;
    public double NewDeepNodeGenerationFall { get; set; } = 0.05;

    public double NewChildOfForNodeChance { get; set; } = 0.5;
    public double NewExpressionInForComparisonChance { get; set; } = 0.35;

    public double NewChildOfIfNodeChance { get; set; } = 0.5;

    public double NewLogicExpressionChance { get; set; } = 0.4;
    public double NextTwoArgExpressionChance { get; set; } = 0.4;
    public double NewVarExpressionChance { get; set; } = 0.5;

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