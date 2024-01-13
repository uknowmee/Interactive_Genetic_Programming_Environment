using Solvers.Interfaces;

namespace Solvers.State;

public class IdleState : ISolverState
{
    public SolverStatus Status => SolverStatus.Idle;
    
    public IGeneticSolver Solver { get; }
    
    public IdleState(IGeneticSolver solver)
    {
        Solver = solver;
    }
}