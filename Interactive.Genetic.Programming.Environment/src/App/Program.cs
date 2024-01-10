using App.Services;
using App.Services.Interfaces;
using Autofac;
using File;
using File.Interfaces;
using Fitness;
using Fitness.Interfaces;
using Generators.Program;
using Generators.Program.Interfaces;
using History;
using History.Interfaces;
using Serialization;
using Serialization.Interfaces;
using Solver.Configuration;
using Solver.Configuration.Interfaces;
using Solvers;
using Solvers.Interfaces;
using Strategies.Evolution;
using Strategies.Evolution.Interfaces;
using Tasks;
using Tasks.Interfaces;

namespace App;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var container = new ContainerBuilder()
            .RegisterServices()
            .RegisterViews()
            .Build();

        var windowSwitcher = container.Resolve<IWindowSwitcherService>() ?? throw new Exception("Couldn't resolve form");

        Application.Run(windowSwitcher.InitialView);
    }

    private static ContainerBuilder RegisterViews(this ContainerBuilder builder)
    {
        builder.RegisterType<WindowSwitcherService>().As<IWindowSwitcherService>().SingleInstance();
        return builder;
    }

    private static ContainerBuilder RegisterServices(this ContainerBuilder builder)
    {
        builder.RegisterType<FileService>().As<IFileService>().SingleInstance();
        builder.RegisterType<FitnessService>().As<IFitnessService>().SingleInstance();
        builder.RegisterType<ProgramGeneratorService>().As<IProgramGeneratorService>().SingleInstance();
        builder.RegisterType<SerializationService>().As<ISerializationService>().SingleInstance();
        builder.RegisterType<SolverConfigurationService>().As<ISolverConfigurationService>().SingleInstance();
        builder.RegisterType<SolverService>().As<ISolverService>().SingleInstance();
        builder.RegisterType<TournamentHandlerService>().As<ITournamentHandlerService>().SingleInstance();
        builder.RegisterType<CrossingService>().As<ICrossingService>().SingleInstance();
        builder.RegisterType<MutatorService>().As<IMutatorService>().SingleInstance();
        builder.RegisterType<HorizontalMutatorService>().As<IHorizontalMutatorService>().SingleInstance();
        builder.RegisterType<TasksService>().As<ITasksService>().SingleInstance();
        builder.RegisterType<HistoryService>().As<IHistoryService>().SingleInstance();
        return builder;
    }
}