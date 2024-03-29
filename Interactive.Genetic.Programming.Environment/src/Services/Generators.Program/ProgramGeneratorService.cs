﻿using Configuration.Solver;
using Generators.Program.Interfaces;
using Shared;
using Task = Shared.Task;

namespace Generators.Program;

public class ProgramGeneratorService : IProgramGeneratorService
{
    private ISolverConfiguration SolverConfiguration { get; }

    public ProgramGeneratorService(ISolverConfiguration solverConfiguration)
    {
        SolverConfiguration = solverConfiguration;
    }

    public void GeneratePopulation(List<Individual> population, int basePopulationSize, Task solvingTask)
    {
        var individuals = GenerateAdditionalPopulation(basePopulationSize, solvingTask);
        population.AddRange(individuals);
    }

    public List<Individual> GenerateAdditionalPopulation(int addPopulationSize, Task solvingTask)
    {
        var population = new List<Individual>();

        for (var i = 0; i < addPopulationSize; i++)
        {
            var program = new Model.Nodes.Big.Program.Root.Program(
                SolverConfiguration.InputLength > solvingTask.InputLength
                    ? SolverConfiguration.InputLength
                    : solvingTask.InputLength
            );
            program.AddBigNodes();
            var individual = new Individual(program, solvingTask.Copy());
            population.Add(individual);
        }

        return population;
    }
}