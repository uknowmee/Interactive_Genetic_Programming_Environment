using Configuration;
using Configuration.Solver;
using Shared;

namespace Solution.Interfaces;

public interface ISolutionSaver
{
    public void SaveSolution(
        IModelConfiguration initialModelConfiguration,
        ISolverConfiguration initialSolverConfiguration,
        FitnessFunction initialFitness,
        Individual bestIndividual
    );
}