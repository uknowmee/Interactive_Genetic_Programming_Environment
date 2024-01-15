using Configuration;
using Configuration.Solver;
using Generators.Program.Interfaces;
using Interpreter;
using Shared;
using Shared.Exceptions;
using Solvers.Interfaces;
using Strategies.Evolution.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Solvers.State;

internal abstract class SolvingState : ISolverState
{    
    protected int Epoch { get; private set; } = 0;
    protected readonly FitnessFunction FitnessFunction;
    protected readonly Shared.Task SolvingTask;
    
    protected int BasePopulationSize => Solver.SolverConfiguration.PopulationSize;
    protected int AdditionalPopulationSize
    {
        get => Solver.AdditionalPopulation;
        set
        {
            Solver.AdditionalPopulation = value;
            NotifyPopulationSize();
        }
    }
    protected int TotalPopulationSize => BasePopulationSize + AdditionalPopulationSize;
    protected List<Individual> Population
    {
        get => Solver.Population;
        set => Solver.Population = value;
    }

    protected Individual? BestIndividual
    {
        get => Solver.BestIndividual;
        set => Solver.BestIndividual = value;
    }
    protected List<Individual> BestIndividuals { get; } = [];
    
    protected ISolverConfiguration SolverConfiguration => Solver.SolverConfiguration;
    protected IProgramGeneratorService ProgramGeneratorService => Solver.ProgramGeneratorService;
    protected IInterpreterService InterpreterService => Solver.InterpreterService;
    protected ICrossingService CrossingService => Solver.CrossingService;
    protected IMutatorService MutatorService => Solver.MutatorService;
    protected IHorizontalMutatorService HorizontalMutatorService => Solver.HorizontalMutatorService;
    protected ITournamentHandlerService TournamentHandlerService => Solver.TournamentHandlerService;
    
    private bool _evolutionStarted = false;
    private bool _shouldStop = false;
    private bool _shouldReset = false;
    private readonly IModelConfiguration _initialModelConfiguration;
    private readonly ISolverConfiguration _initialSolverConfiguration;

    public SolverStatus Status => SolverStatus.Started;

    public IGeneticSolver Solver { get; }

    protected SolvingState(IGeneticSolver solver)
    {
        Solver = solver;
        FitnessFunction = Solver.FitnessService.GetFitnessFunction();
        SolvingTask = Solver.TasksService.GetTask();
        _initialModelConfiguration = Solver.ModelConfiguration.Copy();
        _initialSolverConfiguration = Solver.SolverConfiguration.Copy();
    }

    public void Start()
    {
        throw new CustomException("Solver is already running");
    }

    public void Stop()
    {
        if (_shouldStop)
        {
            throw new CustomException("Solver is already stopping");
        }
        
        if (_shouldReset)
        {
            throw new CustomException("Solver is already resetting");
        }
        
        _shouldStop = true;
        EmitLog("Solver stop has been queued up");
    }

    public void Reset()
    {
        if (_shouldStop)
        {
            throw new CustomException("Solver is already stopping");
        }
        
        if (_shouldReset)
        {
            throw new CustomException("Solver is already resetting");
        }
        
        _shouldReset = true;
        EmitLog("Solver reset has been queued up");
    }

    public async Task Process()
    {
        try
        {
            NotifyAll();
            await Task.Run(() =>
            {
                PreEvolution();
                Evolution();
            });
        }
        catch (ErrorDuringFitnessFunctionExecution e)
        {
            EmitLog($"Error during fitness function execution, finishing evolution: {e.Message}");
            Solver.State = new FinishedState(Solver);
            await Solver.State.Process();
        }
        catch (Exception e)
        {
            EmitLog($"Unexpected error, finishing evolution: {e}");
            Solver.State = new FinishedState(Solver);
            await Solver.State.Process();
        }
    }
    
    private void PreEvolution()
    {
        if (_evolutionStarted)
        {
            return;
        }
        
        _evolutionStarted = true;
        Epoch = 0;
        
        EmitLog("Pre-evolution step has been started");
        PreEvolutionStep();
    }
    
    private void Evolution()
    {
        while (true)
        {
            EmitLog($"Generation number: {Epoch} / {SolverConfiguration.MaxGenerations}, " +
                    $"population size: {BasePopulationSize} + {AdditionalPopulationSize}");
            EmitLog($"Best individual fitness: {Solver.BestIndividual?.FitnessValue ?? double.NegativeInfinity}");
            EmitLog($"Avg fitness: {Solver.AvgFitness}");
            NotifyAvgFitness();

            if (_shouldStop)
            {
                HandleStop();
                return;
            }

            if (_shouldReset)
            {
                HandleReset();
                return;
            }

            if (GotSolution())
            {
                HandleSolutionFound();
                return;
            }

            if (EpochLimitExceeded())
            {
                HandleEpochLimitExceeded();
                return;
            }
            
            EmitLog("Evolution step has been started");
            EvolutionStep();
            Epoch++;
            EmitLog($"Evolution step has been finished {Environment.NewLine}");
        }
    }
    
    private void HandleStop()
    {
        _shouldStop = false;
        EmitLog("Solver has been stopped");
        Solver.State = new StoppedState(Solver, this);
        Solver.State.Process();
    }
    
    private void HandleReset()
    {
        _shouldReset = false;
        Solver.State = new IdleState(Solver);
        Solver.State.Reset();
    }

    private void HandleSolutionFound()
    {
        EmitLog("Solution has been found");
        Solver.SolutionSaver.SaveSolution(
            _initialModelConfiguration,
            _initialSolverConfiguration,
            FitnessFunction,
            Solver.BestIndividual ?? throw new InvalidOperationException("Best individual is not known - this should not happen")
        );
        Solver.State = new FinishedState(Solver);
        Solver.State.Process();
    }
    
    private void HandleEpochLimitExceeded()
    {
        EmitLog("Epoch limit has been exceeded, solution not found, finishing evolution");
        Solver.State = new FinishedState(Solver);
        Solver.State.Process();
    }
    
    private void NotifyAll(int? proceededPercent = null)
    {
        NotifyPopulationSize();
        NotifyAvgFitness();
        NotifyProceeded(proceededPercent ?? 0);
    }

    private void NotifyPopulationSize() => Solver.Publisher.NotifyPopulationSize(TotalPopulationSize);
    private void NotifyAvgFitness() => Solver.Publisher.NotifyAvgFitness(Solver.AvgFitness);
    
    protected void NotifyProceeded(double proceededPercent) => Solver.Publisher.NotifyProceeded(proceededPercent);
    protected void EmitLog(string log) => Solver.EmitLog(log);
    
    protected virtual bool EpochLimitExceeded() => Epoch > SolverConfiguration.MaxGenerations;
    protected abstract bool GotSolution();
    protected abstract void PreEvolutionStep();
    protected abstract void EvolutionStep();
    protected abstract void GeneticOperationsStep();
}