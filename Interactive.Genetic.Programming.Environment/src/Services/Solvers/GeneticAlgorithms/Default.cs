using Shared;
using Solvers.Interfaces;
using Solvers.State;

namespace Solvers.GeneticAlgorithms;

internal sealed class Default : SolvingState
{
    public Default(IGeneticSolver solver) : base(solver)
    {
    }

    protected override bool GotSolution()
    {
        // mock
        Solver.BestIndividual = new Individual { Task = SolvingTask, FitnessValue = 666 };
        return Solver.SolverConfiguration.PopulationSize == 10;
    }
    
    protected override void PreEvolutionStep()
    {
    }
    
    protected override void EvolutionStep()
    {
        Thread.Sleep(5000);
    }

    protected override void GeneticOperationsStep()
    {
    }
}