using Solvers.Interfaces;

namespace Solvers.State;

public class IdleState : ISolverState
{
    public SolverStatus Status => SolverStatus.Idle;
    
    public SolverService Solver { get; }
    
    public IdleState(SolverService solver)
    {
        Solver = solver;
    }
}