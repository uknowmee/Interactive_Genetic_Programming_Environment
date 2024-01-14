using App.Forms;
using App.Services;
using App.Services.Interfaces;
using Autofac;
using Configuration;
using Configuration.Logging;
using Database;
using Database.Interfaces;
using File;
using File.Interfaces;
using Fitness;
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

namespace App;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.ThreadException += ExceptionsHandler.HandleMainThreadException;
        ApplicationConfiguration.Initialize();

        var container = new ContainerBuilder()
            .AddLogging()
            .RegisterServices()
            .RegisterViews()
            .Build();

        container.AddExceptionHandling().StartAppServices().StartApp();
    }

    private static ContainerBuilder AddLogging(this ContainerBuilder builder)
    {
        builder.RegisterInstance(LoggingConfiguration.Factory).As<ILoggerFactory>();
        return builder;
    }

    private static ContainerBuilder RegisterServices(this ContainerBuilder builder)
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

    private static ContainerBuilder RegisterViews(this ContainerBuilder builder)
    {
        builder.RegisterType<WindowSwitcherService>().As<IWindowSwitcherService>().SingleInstance();
        
        builder.RegisterType<HomeForm>().AsSelf().SingleInstance();
        builder.RegisterType<ConfigurationForm>().AsSelf().SingleInstance();
        builder.RegisterType<FitnessForm>().AsSelf().SingleInstance();
        builder.RegisterType<TaskForm>().AsSelf().SingleInstance();
        builder.RegisterType<SavedForm>().AsSelf().SingleInstance();
        
        return builder;
    }

    private static IContainer AddExceptionHandling(this IContainer container)
    {
        ExceptionsHandler.Logger = container.Resolve<ILoggerFactory>().CreateLogger<ExceptionsHandler>();
        return container;
    }

    private static IContainer StartAppServices(this IContainer container)
    {
        var databaseCreator = container.Resolve<IDatabaseCreator>() ?? throw new Exception("Couldn't resolve database creator");
        databaseCreator.EnsureCreated();
        return container;
    }

    private static void StartApp(this IComponentContext container)
    {
        var windowSwitcher = container.Resolve<IWindowSwitcherService>() ?? throw new Exception("Couldn't resolve form");
        
        windowSwitcher.InitializeWithWindows(
            container.Resolve<HomeForm>(),
            container.Resolve<ConfigurationForm>(),
            container.Resolve<FitnessForm>(),
            container.Resolve<TaskForm>(),
            container.Resolve<SavedForm>()
        );
        
        Application.Run(windowSwitcher.InitialView);
    }
}