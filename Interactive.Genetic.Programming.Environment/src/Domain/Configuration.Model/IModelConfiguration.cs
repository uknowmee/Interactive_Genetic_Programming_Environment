namespace Configuration;

public interface IConstantConfiguration
{
    public int MaxInt { get; }
}

public interface IDeepNodeConfiguration
{
    public double NewDeepNodeGenerationFall { get; }
}

public interface IForStatementConfiguration : IDeepNodeConfiguration
{
    public double NewChildOfForNodeChance { get; }
    public double NewExpressionInForComparisonChance { get; }
}

public interface IIfStatementConfiguration : IDeepNodeConfiguration
{
    public double NewChildOfIfNodeChance { get; }
}

public interface ILogicExpressionConfiguration
{
    public double NewLogicExpressionChance { get; }
}

public interface IProgramConfiguration
{
    public double NewChildOfProgramNodeChance { get; }
    public double NewDeepNodeGenerationChance { get; }
}

public interface IStandardExpressionConfiguration
{
    public double NextTwoArgExpressionChance { get; }
}

public interface IVariablesConfiguration
{
    public double NewVarExpressionChance { get; }
}

public interface IModelConfiguration : IConstantConfiguration, IForStatementConfiguration, IIfStatementConfiguration,
    ILogicExpressionConfiguration, IProgramConfiguration, IStandardExpressionConfiguration, IVariablesConfiguration
{
    public new int MaxInt { get; set; }
    public new double NewDeepNodeGenerationFall { get; set; }
    public new double NewChildOfForNodeChance { get; set; }
    public new double NewExpressionInForComparisonChance { get; set; }
    public new double NewChildOfIfNodeChance { get; set; }
    public new double NewLogicExpressionChance { get; set; }
    public new double NewChildOfProgramNodeChance { get; set; }
    public new double NewDeepNodeGenerationChance { get; set; }
    public new double NextTwoArgExpressionChance { get; set; }
    public new double NewVarExpressionChance { get; set; }
    IModelConfiguration Copy();
    public string ToString();
}