using App.Forms;
using App.Services;
using App.Services.Interfaces;
using Autofac;
using Configuration;
using Database;
using Database.Interfaces;
using File;
using File.Interfaces;
using Fitness;
using Generators.Program;
using Generators.Program.Interfaces;
using History;
using Serialization;
using Serialization.Interfaces;
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
        ApplicationConfiguration.Initialize();

        var container = new ContainerBuilder()
            .RegisterServices()
            .RegisterViews()
            .Build();

        container.StartAppServices().StartApp();
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

    private static ContainerBuilder RegisterServices(this ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseService>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<FileService>().As<IFileService>().SingleInstance();
        builder.RegisterType<FitnessService>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<ProgramGeneratorService>().As<IProgramGeneratorService>().SingleInstance();
        builder.RegisterType<SerializationService>().As<ISerializationService>().SingleInstance();
        builder.RegisterType<SolverConfigurationService>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<SolverService>().As<ISolverService>().SingleInstance();
        builder.RegisterType<TournamentHandlerService>().As<ITournamentHandlerService>().SingleInstance();
        builder.RegisterType<CrossingService>().As<ICrossingService>().SingleInstance();
        builder.RegisterType<MutatorService>().As<IMutatorService>().SingleInstance();
        builder.RegisterType<HorizontalMutatorService>().As<IHorizontalMutatorService>().SingleInstance();
        builder.RegisterType<TasksService>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<HistoryService>().AsImplementedInterfaces().SingleInstance();
        
        return builder;
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