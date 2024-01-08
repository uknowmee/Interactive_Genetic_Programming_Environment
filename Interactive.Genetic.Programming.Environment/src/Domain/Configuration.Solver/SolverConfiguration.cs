﻿namespace Configuration.Solver;

public class SolverConfiguration : ISolverConfiguration
{
    public int NumOfTestCases { get; set; } = 1000;
    
    public int InputLength { get; set; } = 1;
    public int ExecutionTime { get; set; } = 3;
    
    public double Error { get; set; } = 1;
    public int PopulationSize { get; set; } = 1000;
    public int MaxGenerations { get; set; } = 200;
    public int TournamentSize { get; set; } = 10;
    
    public double CrossoverProbability { get; set; } = 0.85;
    
    public double MutationProbability { get; set; } = 0.05;
    public double PointMutationProbability { get; set; } = 0.5;
    public double SubtreeMutationProbability { get; set; } = 0.5;
    
    public double HorizontalModificationProbability { get; set; } = 0.10;
    public double NewLineProbability { get; set; } = 0.34;
    public double DeleteLineProbability { get; set; } = 0.33;
    public double SwapLinesProbability { get; set; } = 0.33;
}