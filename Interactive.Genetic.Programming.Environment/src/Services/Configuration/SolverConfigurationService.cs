using Configuration.App;
using Configuration.Interfaces;
using Configuration.Solver;
using Shared;
using Shared.Exceptions;

namespace Configuration;

public partial class SolverConfigurationService :  IModelConfiguration, ISolverConfiguration, IAppConfiguration, ISolverConfigurationChangePublisher
{
    private const double DoubleComparisonTolerance = 0.0001;

    private IModelConfiguration ModelConfiguration { get; } = ConfigurationResolver.Resolve<IModelConfiguration>();
    private ISolverConfiguration SolverConfiguration { get; } = new SolverConfiguration();
    private IAppConfiguration AppConfiguration { get; } = new AppConfiguration();
    
    private IConfigurationChangeSubscriber? _singleSubscriber;
    private IConfigurationChangeFullSubscriber? _fullSubscriber;
    
    public void Subscribe<T>(T subscriber) where T : IConfigurationSubscriber
    {
        switch (subscriber)
        {
            case IConfigurationChangeSubscriber singleSubscriber:
                _singleSubscriber = singleSubscriber;
                break;
            case IConfigurationChangeFullSubscriber fullSubscriber:
                _fullSubscriber = fullSubscriber;
                break;
        }
    }

    public void UnSubscribe<T>(T subscriber) where T : IConfigurationSubscriber
    {
        switch (subscriber)
        {
            case IConfigurationChangeSubscriber singleSubscriber when _singleSubscriber == singleSubscriber:
                _singleSubscriber = null;
                break;
            case IConfigurationChangeFullSubscriber fullSubscriber when _fullSubscriber == fullSubscriber:
                _fullSubscriber = null;
                break;
        }
    }

    public void FetchAllSubscribed<TSubscriber>(TSubscriber subscriber) where TSubscriber : IConfigurationChangeFullSubscriber
    {
        _fullSubscriber?.OnSolverConfigurationChanged(ModelConfiguration, SolverConfiguration);
    }

    private void ConfigurationChanged<T>(string propertyName, T newValue)
    {
        _singleSubscriber?.OnSolverConfigurationChanged($"Configuration has changed: {propertyName} {newValue}");
        _fullSubscriber?.OnSolverConfigurationChanged(ModelConfiguration, SolverConfiguration);
    }

    private static void FailWithValueAlreadySet()
    {
        throw new CustomException("Value already set");
    }
}