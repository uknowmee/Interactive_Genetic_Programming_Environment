using Configuration.Interfaces;
using History.Interfaces;
using Solver;
using Solvers.Interfaces;
using Solvers.State;

namespace Solvers;

public class SolverService : ISolverService
{
    private readonly ISolverState _state;
    
    internal ISolverPublisher Publisher { get;  } = new SolverPublisher();
    internal ISolverConfigurationService ConfigurationService { get; }
    internal IHistoryService HistoryService { get; }
    
    internal Individual? BestIndividual {get; set;}
    internal double AvgFitness => 0.0;

    public SolverService(ISolverConfigurationService configurationService, IHistoryService historyService)
    {
        ConfigurationService = configurationService;
        HistoryService = historyService;
        _state = new IdleState(this);
    }

    public void Subscribe(ISolverSubscriber subscriber)
    {
        Publisher.Subscribe(subscriber);
    }

    public void Unsubscribe(ISolverSubscriber subscriber)
    {
        Publisher.Unsubscribe(subscriber);
    }

    public void FetchAllSubscribed()
    {
        Publisher.NotifyStatus(_state.Status);
        Publisher.NotifyPopulationSize(
            _state.Status == SolverStatus.Idle
                ? 0
                : ConfigurationService.SolverConfiguration.PopulationSize
        );
        Publisher.NotifyBestIndividual(BestIndividual?.ProgramString ?? "");
        Publisher.NotifyBestIndividualFitness(BestIndividual?.FitnessValue ?? 0.0);
        Publisher.NotifyAvgFitness(AvgFitness);
        Publisher.NotifyProceeded(0);
    }

    public void Start()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void Finish()
    {
        throw new NotImplementedException();
    }
}