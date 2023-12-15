namespace Configuration;

public interface IForStatementConfiguration : IDeepNodeConfiguration
{
    public double NewChildOfForNodeChance { get; set; }
    public double NewExpressionInForComparisonChance { get; set; }
}