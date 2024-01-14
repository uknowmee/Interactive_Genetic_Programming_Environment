using Solvers.Interfaces;

namespace Solvers.State;

internal class FinishedState : ISolverState
{
    public SolverStatus Status => SolverStatus.Idle;

    public IGeneticSolver Solver { get; }
    
    public FinishedState(IGeneticSolver solver)
    {
        Solver = solver;
    }
    
    public void Start()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Process()
    {
        throw new NotImplementedException();
    }
}