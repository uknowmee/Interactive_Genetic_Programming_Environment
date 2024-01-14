using Shared;
using Shared.Exceptions;
using Solvers.Interfaces;

namespace Solvers.State;

internal class IdleState : ISolverState
{
    public SolverStatus Status => SolverStatus.Idle;

    public IGeneticSolver Solver { get; }
    
    public IdleState(IGeneticSolver solver)
    {
        Solver = solver;
    }
    
    public void Start()
    {
        throw new CustomException("test exception");
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