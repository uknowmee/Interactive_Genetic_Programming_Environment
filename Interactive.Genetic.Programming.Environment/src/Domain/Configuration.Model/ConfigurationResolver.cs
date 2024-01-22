using Autofac;

namespace Configuration.Model;

public static class ConfigurationResolver
{
    private static readonly IContainer Container;

    public static T Resolve<T>() => (T)Container.Resolve(typeof(T));

    static ConfigurationResolver()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ModelConfiguration>().AsImplementedInterfaces().SingleInstance();
        Container = builder.Build();
    }
}