namespace Configuration;

public interface IIfStatementConfiguration : IDeepNodeConfiguration
{
    public double NewChildOfIfNodeChance { get; set; }
}