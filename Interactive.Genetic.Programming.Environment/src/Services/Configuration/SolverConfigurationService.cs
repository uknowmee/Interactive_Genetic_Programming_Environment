using Configuration.App;
using Configuration.Interfaces;
using Configuration.Solver;

namespace Configuration;

public partial class SolverConfigurationService : ISolverConfigurationService
{
    public IModelConfiguration ModelConfiguration { get; set; } = ConfigurationResolver.Resolve<IModelConfiguration>();
    public ISolverConfiguration SolverConfiguration { get; set; } = new SolverConfiguration();
    public IAppConfiguration AppConfiguration { get; set; } = new AppConfiguration();
}