namespace Solvers.Interfaces;

internal interface ISolverState
{
    public IGeneticSolver Solver { get; }
    public SolverStatus Status { get; }
    public void Start();
    public void Stop();
    public void Reset();
    protected internal void Process();
}