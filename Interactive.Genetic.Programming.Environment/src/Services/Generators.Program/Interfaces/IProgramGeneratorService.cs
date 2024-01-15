using Shared;
using Task = Shared.Task;

namespace Generators.Program.Interfaces;

public interface IProgramGeneratorService
{
    void GeneratePopulation(List<Individual> population, int basePopulationSize, Task solvingTask);
    List<Individual> GenerateAdditionalPopulation(int addPopulationSize, Task solvingTask);
}