using App.Solver;
using Autofac;
using Configuration;
using Configuration.Model;
using Configuration.Solver;
using Database;
using Database.Interfaces;
using File;
using File.Interfaces;
using Fitness;
using Fitness.Interfaces;
using Generators.Program;
using Generators.Program.Interfaces;
using History;
using Interpreter;
using Microsoft.Extensions.Logging;
using Serialization;
using Serialization.Interfaces;
using Solution;
using Solvers;
using Solvers.Interfaces;
using Strategies.Evolution;
using Strategies.Evolution.Interfaces;
using Tasks;
using Tasks.Interfaces;

var container = new ContainerBuilder()
    .AddLogging()
    .RegisterServices()
    .Build();

var modelConfiguration = container.Resolve<IModelConfiguration>();
var solverConfiguration = container.Resolve<ISolverConfiguration>();
var taskDatabase = container.Resolve<ITaskDatabaseService>();
var fitnessDatabase = container.Resolve<IFitnessDatabaseService>();
var tasksService = container.Resolve<ITasksService>();
var fitnessService = container.Resolve<IFitnessService>();
var solver = container.Resolve<ISolverService>();

tasksService.ActivateTask(taskDatabase.FetchAll().Single(t => t.Name == "1_3_B"));
fitnessService.ActivateFitness(fitnessDatabase.FetchAll().Single(f => f.Name == "1_3_B"));

try
{
    Task.Run(() => solver.Start()).Wait();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
Task.Delay(1000 * 60 * 60 * 10).Wait();
Console.Out.WriteLine("Finished");

namespace App.Solver
{
    public static class Application
    {
        public static ContainerBuilder AddLogging(this ContainerBuilder builder)
        {
            builder.RegisterInstance(LoggingConfiguration.Factory).As<ILoggerFactory>();
            return builder;
        }
    
        public static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<FileService>().As<IFileService>().SingleInstance();
            builder.RegisterType<FitnessService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<ProgramGeneratorService>().As<IProgramGeneratorService>().SingleInstance();
            builder.RegisterType<InterpreterService>().As<IInterpreterService>().SingleInstance();
            builder.RegisterType<SerializationService>().As<ISerializationService>().SingleInstance();
            builder.RegisterType<SolverConfigurationService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<SolverService>().As<ISolverService>().SingleInstance();
            builder.RegisterType<TournamentHandlerService>().As<ITournamentHandlerService>().SingleInstance();
            builder.RegisterType<CrossingService>().As<ICrossingService>().SingleInstance();
            builder.RegisterType<MutatorService>().As<IMutatorService>().SingleInstance();
            builder.RegisterType<HorizontalMutatorService>().As<IHorizontalMutatorService>().SingleInstance();
            builder.RegisterType<TasksService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<HistoryService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<SolutionService>().AsImplementedInterfaces().SingleInstance();
        
            return builder;
        }
    }
}