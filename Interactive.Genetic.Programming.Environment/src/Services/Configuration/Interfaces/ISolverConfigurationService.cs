using Configuration.App;
using Configuration.Solver;

namespace Configuration.Interfaces;

public interface ISolverConfigurationService : IModelConfiguration, ISolverConfiguration, IAppConfiguration
{
    public IModelConfiguration ModelConfiguration { get; set; }
    public ISolverConfiguration SolverConfiguration { get; set; }
    public IAppConfiguration AppConfiguration { get; set; }
}