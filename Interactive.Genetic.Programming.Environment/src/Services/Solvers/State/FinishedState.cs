using Shared.Exceptions;
using Solvers.Interfaces;

namespace Solvers.State;

internal class FinishedState : ISolverState
{
    public SolverStatus Status => SolverStatus.Finished;

    public IGeneticSolver Solver { get; }
    
    public FinishedState(IGeneticSolver solver)
    {
        Solver = solver;
    }
    
    public void Start()
    {
        throw new CustomException("Solver is already finished, cannot start it - reset it first");
    }

    public void Stop()
    {
        throw new CustomException("Solver is not running, cannot stop it - reset it first");
    }

    public void Reset()
    {
        Solver.State = new IdleState(Solver);
        Solver.State.Reset();
    }

    public Task Process()
    {
        return Task.CompletedTask;
    }
}