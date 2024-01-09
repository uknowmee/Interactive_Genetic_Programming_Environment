using Autofac;

namespace App;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        var builder = new ContainerBuilder();
        builder.RegisterType<Home>().AsSelf().SingleInstance();
        builder.RegisterType<Service1>().AsSelf().SingleInstance();
        builder.RegisterType<Service2>().AsSelf().SingleInstance();
        var container = builder.Build();
        
        var form = container.Resolve<Home>() as Form ?? throw new Exception("Couldn't resolve form");
        Application.Run(form);
    }
}

public class Service1
{
    private readonly Service2 _service2;
    
    public string Service2Information => _service2.Information;
    
    public Service1(Service2 service2)
    {
        _service2 = service2;
    }
}

public class Service2
{
    public string Information => "Service2 information";
}