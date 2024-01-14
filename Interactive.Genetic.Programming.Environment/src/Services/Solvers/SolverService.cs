using Configuration;
using Configuration.App;
using Configuration.Solver;
using Fitness.Interfaces;
using Generators.Program.Interfaces;
using History.Interfaces;
using Interpreter;
using Microsoft.Extensions.Logging;
using Shared;
using Solution.Interfaces;
using Solvers.Interfaces;
using Solvers.State;
using Strategies.Evolution.Interfaces;
using Tasks.Interfaces;

namespace Solvers;

public class SolverService : ISolverService, IGeneticSolver, ILogEmitter
{
    private readonly ILogger<SolverService> _logger;

    private ISolverState _state;

    private Individual? _bestIndividual;
    public int AdditionalPopulation { get; set; }

    public ISolverPublisher Publisher { get; } = new SolverPublisher();
    public IAppConfiguration AppConfiguration { get; }
    public IModelConfiguration ModelConfiguration { get; }
    public ISolverConfiguration SolverConfiguration { get; }
    public IHistoryService HistoryService { get; }
    public ISolutionSaver SolutionSaver { get; }
    public IFitnessService FitnessService { get; }
    public ITasksService TasksService { get; }
    public IProgramGeneratorService ProgramGeneratorService { get; }
    public IInterpreterService InterpreterService { get; }
    public ICrossingService CrossingService { get; }
    public IMutatorService MutatorService { get; }
    public IHorizontalMutatorService HorizontalMutatorService { get; }
    public ITournamentHandlerService TournamentHandlerService { get; }

    ISolverState IGeneticSolver.State
    {
        get => _state;
        set
        {
            _state = value;
            Publisher.NotifyStatus(_state.Status);
        }
    }

    public List<Individual> Population { get; } = [];

    public Individual? BestIndividual
    {
        get => _bestIndividual;
        set
        {
            _bestIndividual = value;
            Publisher.NotifyBestIndividual(_bestIndividual?.ProgramString ?? "");
            Publisher.NotifyBestIndividualFitness(_bestIndividual?.FitnessValue ?? 0.0);
        }
    }

    public double AvgFitness
        => Population.Count == 0
            ? double.NegativeInfinity
            : Population.Average(i => i.FitnessValue);

    public SolverService(
        IAppConfiguration appConfiguration,
        IModelConfiguration modelConfiguration,
        ISolverConfiguration solverConfiguration,
        IHistoryService historyService,
        ISolutionSaver solutionSaver,
        IFitnessService fitnessService,
        ITasksService taskService,
        IProgramGeneratorService programGeneratorService,
        IInterpreterService interpreterService,
        ICrossingService crossingService,
        IMutatorService mutatorService,
        IHorizontalMutatorService horizontalMutatorService,
        ITournamentHandlerService tournamentHandlerService,
        ILoggerFactory loggerFactory
    )
    {
        _logger = loggerFactory.CreateLogger<SolverService>();

        AppConfiguration = appConfiguration;
        ModelConfiguration = modelConfiguration;
        SolverConfiguration = solverConfiguration;
        HistoryService = historyService;
        SolutionSaver = solutionSaver;
        FitnessService = fitnessService;
        TasksService = taskService;
        ProgramGeneratorService = programGeneratorService;
        InterpreterService = interpreterService;
        CrossingService = crossingService;
        MutatorService = mutatorService;
        HorizontalMutatorService = horizontalMutatorService;
        TournamentHandlerService = tournamentHandlerService;

        _state = new IdleState(this);
    }

    public void Subscribe(ISolverStatusSubscriber subscriber)
    {
        Publisher.Subscribe(subscriber);
    }
    
    public void Unsubscribe(ISolverStatusSubscriber subscriber)
    {
        Publisher.Unsubscribe(subscriber);
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
                : SolverConfiguration.PopulationSize + AdditionalPopulation
        );
        Publisher.NotifyBestIndividual(BestIndividual?.ProgramString ?? "");
        Publisher.NotifyBestIndividualFitness(
            _state.Status == SolverStatus.Idle
                ? 0.0
                : BestIndividual?.FitnessValue ?? double.NegativeInfinity
        );
        Publisher.NotifyAvgFitness(_state.Status == SolverStatus.Idle ? 0.0 : AvgFitness);
        if (_state.Status == SolverStatus.Idle)
        {
            Publisher.NotifyProceeded(0);
        }
    }

    public void Start()
    {
        _state.Start();
    }

    public void Stop()
    {
        _state.Stop();
    }

    public void Reset()
    {
        _state.Reset();
    }

    public void EmitLog(string log)
    {
        _logger.LogInformation("SolverService: emitted log: {log}", log);
        HistoryService.PushEntry(log);
    }
}