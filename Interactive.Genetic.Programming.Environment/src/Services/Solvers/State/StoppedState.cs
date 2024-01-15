using Shared.Exceptions;
using Solvers.Interfaces;

namespace Solvers.State;

internal class StoppedState : ISolverState
{
    public SolverStatus Status => SolverStatus.Stopped;
    
    private readonly SolvingState _solvingState;

    public IGeneticSolver Solver { get; }
    
    public StoppedState(IGeneticSolver solver, SolvingState solvingState)
    {
        Solver = solver;
        _solvingState = solvingState;
    }
    
    public void Start()
    {
        Solver.EmitLog("Solver is starting again");
        Solver.State = _solvingState;
        Solver.State.Process();
    }

    public void Stop()
    {
        throw new CustomException("Solver is already stopped");
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