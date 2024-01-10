using Configuration;
using Configuration.App;
using Configuration.Solver;

namespace Solver.Configuration.Interfaces;

public interface ISolverConfigurationService
{
    public IModelConfiguration ModelConfiguration { get; set; }
    public ISolverConfiguration SolverConfiguration { get; set; }
    public IAppConfiguration AppConfiguration { get; set; }
}