using Shared.Exceptions;
using Solvers.GeneticAlgorithms;
using Solvers.Interfaces;

namespace Solvers.State;

internal class IdleState : ISolverState
{
    public SolverStatus Status => SolverStatus.Idle;

    public IGeneticSolver Solver { get; }
    
    public IdleState(IGeneticSolver solver)
    {
        Solver = solver;
        Solver.Population.Clear();
        Solver.BestIndividual = null;
        Solver.AdditionalPopulation = 0;
    }
    
    public void Start()
    {
        if (Solver.FitnessService.IsFitnessActive() is false)
        {
            throw new CustomException("Fitness is not active, cannot start solver");
        }
        
        if (Solver.TasksService.IsTaskActive() is false)
        {
            throw new CustomException("Task is not active, cannot start solver");
        }
        
        Solver.EmitLog("Solver is starting");
        Solver.State = CreateSolverBasedOnConfiguration();
        Solver.State.Process();
    }

    public void Stop()
    {
        throw new CustomException("Solver is not running, cannot stop it");
    }

    public void Reset()
    {
        Solver.HistoryService.Clear();
        Solver.ModelConfiguration.Reset();
        Solver.SolverConfiguration.Reset();
        Solver.FitnessService.ResetFitness();
        Solver.TasksService.ResetTask();
        NotifyAll();
        
        Solver.EmitLog("Solver has been reset");
    }

    public void Process()
    {
    }

    private void NotifyAll()
    {
        Solver.Publisher.NotifyPopulationSize(0);
        Solver.Publisher.NotifyBestIndividual("");
        Solver.Publisher.NotifyBestIndividualFitness(0.0);
        Solver.Publisher.NotifyAvgFitness(0.0);
        Solver.Publisher.NotifyProceeded(0);
    }

    private ISolverState CreateSolverBasedOnConfiguration()
    {
        return new Default(Solver);
    }
}