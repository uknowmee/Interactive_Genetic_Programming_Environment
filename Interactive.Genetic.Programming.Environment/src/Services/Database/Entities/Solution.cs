namespace Database.Entities;

public class Solution
{
    public int SolutionId { get; set; }
    
    public string ModelConfiguration { get; set; }
    public string SolverConfiguration { get; set; }
    public string History { get; set; }

    public int FitnessFunctionId { get; set; }
    public FitnessFunction FitnessFunction { get; set; }
    
    public int TaskId { get; set; }
    public Task Task { get; set; }
}