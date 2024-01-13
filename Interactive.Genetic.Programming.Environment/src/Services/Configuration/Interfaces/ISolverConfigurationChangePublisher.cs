using Configuration.Solver;

namespace Configuration.Interfaces;

public interface IConfigurationSubscriber;

public interface IConfigurationChangeSubscriber : IConfigurationSubscriber
{
    public void OnSolverConfigurationChanged(string configurationChange);
}

public interface IConfigurationChangeFullSubscriber : IConfigurationSubscriber
{
    public void OnSolverConfigurationChanged(IModelConfiguration modelConfiguration, ISolverConfiguration solverConfiguration);
}

public interface ISolverConfigurationChangePublisher
{
    public void Subscribe<T>(T subscriber) where T : IConfigurationSubscriber;
    public void UnSubscribe<T>(T subscriber) where T : IConfigurationSubscriber;
    public void FetchAllSubscribed<TSubscriber>(TSubscriber subscriber) where TSubscriber : IConfigurationChangeFullSubscriber;
}
