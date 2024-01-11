namespace Configuration;

public partial class SolverConfigurationService
{
    public int NumOfTestCases
    {
        get => SolverConfiguration.NumOfTestCases;
        set => SolverConfiguration.NumOfTestCases = value;
    }

    public int InputLength
    {
        get => SolverConfiguration.InputLength;
        set => SolverConfiguration.InputLength = value;
    }

    public int ExecutionTime
    {
        get => SolverConfiguration.ExecutionTime;
        set => SolverConfiguration.ExecutionTime = value;
    }

    public double Error
    {
        get => SolverConfiguration.Error;
        set => SolverConfiguration.Error = value;
    }

    public int PopulationSize
    {
        get => SolverConfiguration.PopulationSize;
        set => SolverConfiguration.PopulationSize = value;
    }

    public int MaxGenerations
    {
        get => SolverConfiguration.MaxGenerations;
        set => SolverConfiguration.MaxGenerations = value;
    }

    public int TournamentSize
    {
        get => SolverConfiguration.TournamentSize;
        set => SolverConfiguration.TournamentSize = value;
    }

    public double CrossoverProbability
    {
        get => SolverConfiguration.CrossoverProbability;
        set => SolverConfiguration.CrossoverProbability = value;
    }

    public double MutationProbability
    {
        get => SolverConfiguration.MutationProbability;
        set => SolverConfiguration.MutationProbability = value;
    }

    public double PointMutationProbability
    {
        get => SolverConfiguration.PointMutationProbability;
        set => SolverConfiguration.PointMutationProbability = value;
    }

    public double SubtreeMutationProbability
    {
        get => SolverConfiguration.SubtreeMutationProbability;
        set => SolverConfiguration.SubtreeMutationProbability = value;
    }

    public double HorizontalModificationProbability
    {
        get => SolverConfiguration.HorizontalModificationProbability;
        set => SolverConfiguration.HorizontalModificationProbability = value;
    }

    public double NewLineProbability
    {
        get => SolverConfiguration.NewLineProbability;
        set => SolverConfiguration.NewLineProbability = value;
    }

    public double DeleteLineProbability
    {
        get => SolverConfiguration.DeleteLineProbability;
        set => SolverConfiguration.DeleteLineProbability = value;
    }

    public double SwapLinesProbability
    {
        get => SolverConfiguration.SwapLinesProbability;
        set => SolverConfiguration.SwapLinesProbability = value;
    }
}