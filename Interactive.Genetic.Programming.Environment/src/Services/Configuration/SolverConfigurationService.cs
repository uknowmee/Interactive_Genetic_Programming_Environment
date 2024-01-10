using Configuration;
using Configuration.App;
using Configuration.Solver;
using Solver.Configuration.Interfaces;

namespace Solver.Configuration;

public class SolverConfigurationService : ISolverConfigurationService
{
    public IModelConfiguration ModelConfiguration { get; set; } = ConfigurationResolver.Resolve<IModelConfiguration>();
    public ISolverConfiguration SolverConfiguration { get; set; } = new SolverConfiguration();
    public IAppConfiguration AppConfiguration { get; set; } = new AppConfiguration();
}