using Configuration;
using Configuration.Model;
using Configuration.Solver;
using Shared;

namespace Solution.Interfaces;

public interface ISolutionSaver
{
    public void SaveSolution(
        IModelConfiguration initialModelConfiguration,
        ISolverConfiguration initialSolverConfiguration,
        IEnumerable<FitnessFunction> fitnessFunctions,
        IEnumerable<double> fitnessHistory,
        Individual bestIndividual
    );
}