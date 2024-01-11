namespace Solvers;

public enum SolverStatus
{
    Idle,
    Started,
    Stopped,
    GeneratingPopulation,
    Solving,
    RefreshingPopulation,
    Finished
}