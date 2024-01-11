namespace Solvers.Interfaces;

public interface ISolverState
{
    public SolverService Solver { get; }
    public SolverStatus Status { get; }
}