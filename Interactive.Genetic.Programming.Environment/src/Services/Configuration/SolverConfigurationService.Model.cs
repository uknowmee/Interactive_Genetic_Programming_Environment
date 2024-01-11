namespace Configuration;

public partial class SolverConfigurationService
{
    public int MaxInt
    {
        get => ModelConfiguration.MaxInt;
        set => ModelConfiguration.MaxInt = value;
    }

    public double NewDeepNodeGenerationFall
    {
        get => ModelConfiguration.NewDeepNodeGenerationFall;
        set => ModelConfiguration.NewDeepNodeGenerationFall = value;
    }

    public double NewChildOfForNodeChance
    {
        get => ModelConfiguration.NewChildOfForNodeChance;
        set => ModelConfiguration.NewChildOfForNodeChance = value;
    }

    public double NewExpressionInForComparisonChance
    {
        get => ModelConfiguration.NewExpressionInForComparisonChance;
        set => ModelConfiguration.NewExpressionInForComparisonChance = value;
    }

    public double NewChildOfIfNodeChance
    {
        get => ModelConfiguration.NewChildOfIfNodeChance;
        set => ModelConfiguration.NewChildOfIfNodeChance = value;
    }

    public double NewLogicExpressionChance
    {
        get => ModelConfiguration.NewLogicExpressionChance;
        set => ModelConfiguration.NewLogicExpressionChance = value;
    }

    public double NewChildOfProgramNodeChance
    {
        get => ModelConfiguration.NewChildOfProgramNodeChance;
        set => ModelConfiguration.NewChildOfProgramNodeChance = value;
    }

    public double NewDeepNodeGenerationChance
    {
        get => ModelConfiguration.NewDeepNodeGenerationChance;
        set => ModelConfiguration.NewDeepNodeGenerationChance = value;
    }

    public double NextTwoArgExpressionChance
    {
        get => ModelConfiguration.NextTwoArgExpressionChance;
        set => ModelConfiguration.NextTwoArgExpressionChance = value;
    }

    public double NewVarExpressionChance
    {
        get => ModelConfiguration.NewVarExpressionChance;
        set => ModelConfiguration.NewVarExpressionChance = value;
    }
}