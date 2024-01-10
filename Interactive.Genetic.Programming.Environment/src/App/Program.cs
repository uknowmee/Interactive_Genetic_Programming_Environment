using App.Services;
using App.Services.Interfaces;
using Autofac;

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
        return builder;
    }
}