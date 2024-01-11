using Solvers.Interfaces;

namespace Solvers;

public class SolverPublisher : ISolverPublisher
{
    private ISolverSubscriber? _subscriber;

    public void Subscribe(ISolverSubscriber subscriber)
    {
        _subscriber = subscriber;
    }

    public void Unsubscribe(ISolverSubscriber subscriber)
    {
        _subscriber = null;
    }

    public void NotifyStatus(SolverStatus status)
    {
        _subscriber?.OnSolverStatusUpdate(status);
    }

    public void NotifyPopulationSize(int size)
    {
        _subscriber?.OnPopulationSizeUpdate(size);
    }

    public void NotifyBestIndividual(string program)
    {
        _subscriber?.OnBestIndividualUpdate(program);
    }

    public void NotifyBestIndividualFitness(double fitness)
    {
        _subscriber?.BestIndividualFitnessUpdate(fitness);
    }

    public void NotifyAvgFitness(double avgFitness)
    {
        _subscriber?.OnAvgFitnessUpdate(avgFitness);
    }

    public void NotifyProceeded(int percent)
    {
        _subscriber?.OnProceededUpdate(percent);
    }
}