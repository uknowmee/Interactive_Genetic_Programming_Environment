using Configuration.Model;

namespace Configuration;

public partial class SolverConfigurationService
{
    public int MaxInt
    {
        get => ModelConfiguration.MaxInt;
        set
        {
            if (ModelConfiguration.MaxInt == value) FailWithValueAlreadySet();
            ModelConfiguration.MaxInt = value;
            ConfigurationChanged(nameof(MaxInt), value);
        }
    }

    public double NewDeepNodeGenerationFall
    {
        get => ModelConfiguration.NewDeepNodeGenerationFall;
        set
        {
            if (Math.Abs(ModelConfiguration.NewDeepNodeGenerationFall - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            ModelConfiguration.NewDeepNodeGenerationFall = value;
            ConfigurationChanged(nameof(NewDeepNodeGenerationFall), value);
        }
    }

    public double NewChildOfForNodeChance
    {
        get => ModelConfiguration.NewChildOfForNodeChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NewChildOfForNodeChance - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            ModelConfiguration.NewChildOfForNodeChance = value;
            ConfigurationChanged(nameof(NewChildOfForNodeChance), value);
        }
    }

    public double NewExpressionInForComparisonChance
    {
        get => ModelConfiguration.NewExpressionInForComparisonChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NewExpressionInForComparisonChance - value) < DoubleComparisonTolerance)
                FailWithValueAlreadySet();
            ModelConfiguration.NewExpressionInForComparisonChance = value;
            ConfigurationChanged(nameof(NewExpressionInForComparisonChance), value);
        }
    }

    public double NewChildOfIfNodeChance
    {
        get => ModelConfiguration.NewChildOfIfNodeChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NewChildOfIfNodeChance - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            ModelConfiguration.NewChildOfIfNodeChance = value;
            ConfigurationChanged(nameof(NewChildOfIfNodeChance), value);
        }
    }

    public double NewLogicExpressionChance
    {
        get => ModelConfiguration.NewLogicExpressionChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NewLogicExpressionChance - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            ModelConfiguration.NewLogicExpressionChance = value;
            ConfigurationChanged(nameof(NewLogicExpressionChance), value);
        }
    }

    public double NewChildOfProgramNodeChance
    {
        get => ModelConfiguration.NewChildOfProgramNodeChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NewChildOfProgramNodeChance - value) < DoubleComparisonTolerance)
                FailWithValueAlreadySet();
            ModelConfiguration.NewChildOfProgramNodeChance = value;
            ConfigurationChanged(nameof(NewChildOfProgramNodeChance), value);
        }
    }

    public double NewDeepNodeGenerationChance
    {
        get => ModelConfiguration.NewDeepNodeGenerationChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NewDeepNodeGenerationChance - value) < DoubleComparisonTolerance)
                FailWithValueAlreadySet();
            ModelConfiguration.NewDeepNodeGenerationChance = value;
            ConfigurationChanged(nameof(NewDeepNodeGenerationChance), value);
        }
    }

    public double NextTwoArgExpressionChance
    {
        get => ModelConfiguration.NextTwoArgExpressionChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NextTwoArgExpressionChance - value) < DoubleComparisonTolerance)
                FailWithValueAlreadySet();
            ModelConfiguration.NextTwoArgExpressionChance = value;
            ConfigurationChanged(nameof(NextTwoArgExpressionChance), value);
        }
    }

    public double NewVarExpressionChance
    {
        get => ModelConfiguration.NewVarExpressionChance;
        set
        {
            if (Math.Abs(ModelConfiguration.NewVarExpressionChance - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            ModelConfiguration.NewVarExpressionChance = value;
            ConfigurationChanged(nameof(NewVarExpressionChance), value);
        }
    }
    
    public IModelConfiguration Copy()
    {
        return ModelConfiguration.Copy();
    }

    void IModelConfiguration.Reset()
    {
        ModelConfiguration.Reset();
        ConfigurationReset<IModelConfiguration>();
    }

    string IModelConfiguration.ToString()
    {
        return ModelConfiguration.ToString();
    }
}