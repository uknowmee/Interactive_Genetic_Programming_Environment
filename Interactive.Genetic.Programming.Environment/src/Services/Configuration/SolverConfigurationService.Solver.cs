using Configuration.Solver;

namespace Configuration;

public partial class SolverConfigurationService
{
    public int NumOfTestCases
    {
        get => SolverConfiguration.NumOfTestCases;
        set
        {
            if (SolverConfiguration.NumOfTestCases == value) FailWithValueAlreadySet();
            SolverConfiguration.NumOfTestCases = value;
            ConfigurationChanged(nameof(NumOfTestCases), value);
        }
    }

    public int InputLength
    {
        get => SolverConfiguration.InputLength;
        set
        {
            if (SolverConfiguration.InputLength == value) FailWithValueAlreadySet();
            SolverConfiguration.InputLength = value;
            ConfigurationChanged(nameof(InputLength), value);
        }
    }

    public int ExecutionTime
    {
        get => SolverConfiguration.ExecutionTime;
        set
        {
            if (SolverConfiguration.ExecutionTime == value) FailWithValueAlreadySet();
            SolverConfiguration.ExecutionTime = value;
            ConfigurationChanged(nameof(ExecutionTime), value);
        }
    }

    public double Error
    {
        get => SolverConfiguration.Error;
        set
        {
            if (Math.Abs(SolverConfiguration.Error - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            SolverConfiguration.Error = value;
            ConfigurationChanged(nameof(Error), value);
        }
    }

    public int PopulationSize
    {
        get => SolverConfiguration.PopulationSize;
        set
        {
            if (SolverConfiguration.PopulationSize == value) FailWithValueAlreadySet();
            SolverConfiguration.PopulationSize = value;
            ConfigurationChanged(nameof(PopulationSize), value);
        }
    }

    public int MaxGenerations
    {
        get => SolverConfiguration.MaxGenerations;
        set
        {
            if (SolverConfiguration.MaxGenerations == value) FailWithValueAlreadySet();
            SolverConfiguration.MaxGenerations = value;
            ConfigurationChanged(nameof(MaxGenerations), value);
        }
    }

    public int TournamentSize
    {
        get => SolverConfiguration.TournamentSize;
        set
        {
            if (SolverConfiguration.TournamentSize == value) FailWithValueAlreadySet();
            SolverConfiguration.TournamentSize = value;
            ConfigurationChanged(nameof(TournamentSize), value);
        }
    }

    public double CrossoverProbability
    {
        get => SolverConfiguration.CrossoverProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.CrossoverProbability - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            SolverConfiguration.CrossoverProbability = value;
            ConfigurationChanged(nameof(CrossoverProbability), value);
        }
    }

    public double MutationProbability
    {
        get => SolverConfiguration.MutationProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.MutationProbability - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            SolverConfiguration.MutationProbability = value;
            ConfigurationChanged(nameof(MutationProbability), value);
        }
    }

    public double PointMutationProbability
    {
        get => SolverConfiguration.PointMutationProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.PointMutationProbability - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            SolverConfiguration.PointMutationProbability = value;
            ConfigurationChanged(nameof(PointMutationProbability), value);
        }
    }

    public double SubtreeMutationProbability
    {
        get => SolverConfiguration.SubtreeMutationProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.SubtreeMutationProbability - value) < DoubleComparisonTolerance)
                FailWithValueAlreadySet();
            SolverConfiguration.SubtreeMutationProbability = value;
            ConfigurationChanged(nameof(SubtreeMutationProbability), value);
        }
    }

    public double HorizontalModificationProbability
    {
        get => SolverConfiguration.HorizontalModificationProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.HorizontalModificationProbability - value) < DoubleComparisonTolerance)
                FailWithValueAlreadySet();
            SolverConfiguration.HorizontalModificationProbability = value;
            ConfigurationChanged(nameof(HorizontalModificationProbability), value);
        }
    }

    public double NewLineProbability
    {
        get => SolverConfiguration.NewLineProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.NewLineProbability - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            SolverConfiguration.NewLineProbability = value;
            ConfigurationChanged(nameof(NewLineProbability), value);
        }
    }

    public double DeleteLineProbability
    {
        get => SolverConfiguration.DeleteLineProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.DeleteLineProbability - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            SolverConfiguration.DeleteLineProbability = value;
            ConfigurationChanged(nameof(DeleteLineProbability), value);
        }
    }

    public double SwapLinesProbability
    {
        get => SolverConfiguration.SwapLinesProbability;
        set
        {
            if (Math.Abs(SolverConfiguration.SwapLinesProbability - value) < DoubleComparisonTolerance) FailWithValueAlreadySet();
            SolverConfiguration.SwapLinesProbability = value;
            ConfigurationChanged(nameof(SwapLinesProbability), value);
        }
    }

    ISolverConfiguration ISolverConfiguration.Copy()
    {
        return SolverConfiguration.Copy();
    }
    
    string ISolverConfiguration.ToString()
    {
        return SolverConfiguration.ToString();
    }
}