using Configuration;
using Configuration.Solver;
using Shared;

namespace Solution.Interfaces;

public interface ISolutionSaver
{
    public void SaveSolution(
        IModelConfiguration initialModelConfiguration,
        ISolverConfiguration initialSolverConfiguration,
        IEnumerable<FitnessFunction> fitnessFunctions,
        Individual bestIndividual
    );
}