namespace Solvers.Interfaces;

public interface ISolverStatusSubscriber
{
    public void OnSolverStatusUpdate(SolverStatus status);
}

public interface ISolverSubscriber : ISolverStatusSubscriber
{
    public void OnPopulationSizeUpdate(int size);
    public void OnBestIndividualUpdate(string program);
    public void BestIndividualFitnessUpdate(double fitness);
    public void OnAvgFitnessUpdate(double avgFitness);
    public void OnProceededUpdate(int percent);
}

public interface ISolverPublisher
{
    public void Subscribe(ISolverStatusSubscriber subscriber);
    public void Unsubscribe(ISolverStatusSubscriber subscriber);
    
    public void Subscribe(ISolverSubscriber subscriber);
    public void Unsubscribe(ISolverSubscriber subscriber);
    
    public void NotifyStatus(SolverStatus status);
    public void NotifyPopulationSize(int size);
    public void NotifyBestIndividual(string program);
    public void NotifyBestIndividualFitness(double fitness);
    public void NotifyAvgFitness(double avgFitness);
    public void NotifyProceeded(int percent);
}