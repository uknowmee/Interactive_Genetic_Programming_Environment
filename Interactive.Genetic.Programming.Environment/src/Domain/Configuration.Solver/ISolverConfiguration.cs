namespace Configuration.Solver;

public interface ISolverConfiguration
{
    public int NumOfTestCases { get; set; }
    public int InputLength { get; set; }

    public int ExecutionTime { get; set; }
    
    public double Error { get; set; }
    public int PopulationSize { get; set; }
    public int MaxGenerations { get; set; }
    
    public int TournamentSize { get; set; }

    public double CrossoverProbability { get; set; }
    
    public double MutationProbability { get; set; }
    public double PointMutationProbability { get; set; }
    public double SubtreeMutationProbability { get; set; }
    
    public double HorizontalModificationProbability { get; set; }
    public double NewLineProbability { get; set; }
    public double DeleteLineProbability { get; set; }
    public double SwapLinesProbability { get; set; }
}