namespace Solvers.Interfaces;

public interface ISolverState
{
    public IGeneticSolver Solver { get; }
    public SolverStatus Status { get; }
}