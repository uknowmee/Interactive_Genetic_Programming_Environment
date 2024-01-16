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
using Strategies.Evolution.Interfaces;
using Tasks.Interfaces;

namespace Solvers.Interfaces;

internal interface IGeneticSolver
{
    public List<Individual> Population { get; set; }
    public Individual? BestIndividual { get; set; }
    public int AdditionalPopulation { get; set; }
    public double AvgFitness { get; }
    
    public ILoggerFactory LoggerFactory { get; }
    public ISolverPublisher Publisher { get; }
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
    public ISolverState State { get; set; }
    public void EmitLog(string log);
}