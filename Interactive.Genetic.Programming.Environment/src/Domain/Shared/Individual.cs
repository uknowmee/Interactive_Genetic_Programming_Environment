using Model.Nodes.Big.Program.Root;
using Shared.Interfaces;

namespace Shared;

public class Individual : IEvaluable
{
    public bool FinishedAllCasesRun { get; set; }
    public double FitnessValue { get; set; } = double.NegativeInfinity;

    public string ProgramString => Program.ToString();
    public int ProgramLength => Program.Length;
    public int NumberOfVariables => Program.ProgramVariables.Count;
    public int NumberOfNodes => Program.ChildrenAsNodes().Count;
    
    public Task Task { get; }
    
    public Program Program { get; }

    public List<ITestCase> TestCases => [..Task.TestCases];
    
    public Individual(Program program, Task solvingTask)
    {
        Program = program;
        Task = solvingTask;
    }

    public override string ToString()
    {
        return $"Fitness: {FitnessValue},{Environment.NewLine}" +
               $"Program: {ProgramString}";
    }
}