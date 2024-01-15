using Solvers.Interfaces;

namespace Solvers;

public class SolverPublisher : ISolverPublisher
{
    private ISolverSubscriber? _subscriber;
    private readonly List<ISolverStatusSubscriber> _statusSubscribers = new();

    public void Subscribe(ISolverStatusSubscriber subscriber)
    {
        _statusSubscribers.Add(subscriber);
    }

    public void Unsubscribe(ISolverStatusSubscriber subscriber)
    {
        _statusSubscribers.Remove(subscriber);
    }
    
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
        foreach (var subscriber in _statusSubscribers)
        {
            subscriber.OnSolverStatusUpdate(status);
        }
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

    public void NotifyProceeded(double percent)
    {
        _subscriber?.OnProceededUpdate(percent);
    }
}