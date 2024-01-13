using Configuration;
using Configuration.App;
using Configuration.Solver;
using Fitness.Interfaces;
using History.Interfaces;
using Shared;
using Solution.Interfaces;
using Solvers.Interfaces;
using Solvers.State;
using Tasks.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Solvers;

public class SolverService : ISolverService, IGeneticSolver
{
    private readonly ISolverState _state;
    
    private ISolverPublisher Publisher { get;  } = new SolverPublisher();
    private ISolutionSaver SolutionSaver { get; }
    private IAppConfiguration AppConfiguration { get; }
    private IModelConfiguration ModelConfiguration { get; }
    private ISolverConfiguration SolverConfiguration { get; }
    private IHistoryService HistoryService { get; }
    private IFitnessService FitnessService { get; }
    private ITasksService TasksService { get; }
    
    internal Individual? BestIndividual {get; set;}
    internal double AvgFitness => 0.0;

    public SolverService(
        IAppConfiguration appConfiguration,
        IModelConfiguration modelConfiguration,
        ISolverConfiguration solverConfiguration,
        IHistoryService historyService,
        ISolutionSaver solutionSaver,
        IFitnessService fitnessService,
        ITasksService taskService
    )
    {
        AppConfiguration = appConfiguration;
        ModelConfiguration = modelConfiguration;
        SolverConfiguration = solverConfiguration;
        HistoryService = historyService;
        SolutionSaver = solutionSaver;
        FitnessService = fitnessService;
        TasksService = taskService;
        
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
                : SolverConfiguration.PopulationSize
        );
        Publisher.NotifyBestIndividual(BestIndividual?.ProgramString ?? "");
        Publisher.NotifyBestIndividualFitness(BestIndividual?.FitnessValue ?? 0.0);
        Publisher.NotifyAvgFitness(AvgFitness);
        Publisher.NotifyProceeded(0);
    }

    public async void Start()
    {

        await Task.Run(() =>
        {
            HistoryService.Clear();
            
            var initModelConfig = ModelConfiguration.Copy();
            var initSolverConfig = SolverConfiguration.Copy();
            var initFitness = FitnessService.GetFitnessFunction();
            
            Thread.Sleep(10000);
            
            var bestIndividual = new Individual
            {
                Task = TasksService.GetTask()
            };
            
            SolutionSaver.SaveSolution(initModelConfig, initSolverConfig, initFitness, bestIndividual);
        });
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