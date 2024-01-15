using Shared;
using Solvers.Interfaces;
using Solvers.State;
using Utils;

namespace Solvers.GeneticAlgorithms;

internal sealed class DefaultAlgorithm : SolvingState
{
    public DefaultAlgorithm(IGeneticSolver solver) : base(solver)
    {
    }

    protected override bool GotSolution()
    {
        var fitness = BestIndividual?.FitnessValue ?? double.NegativeInfinity;
        return fitness >= -SolverConfiguration.Error;
    }

    protected override void PreEvolutionStep()
    {
        EmitLog("Generating initial population...");
        ProgramGeneratorService.GeneratePopulation(Population, BasePopulationSize, SolvingTask);
        MakeAllRunnable();

        BestIndividual = GetBestIndividual();
        BestIndividuals.Add(BestIndividual);
    }

    protected override void EvolutionStep()
    {
        if (IsSolverStuck())
        {
            EmitLog("Refreshing population...");
            AdditionalPopulationSize = TotalPopulationSize / 2;
            MakeAllRunnable();
        }

        if (TotalPopulationSize != Population.Count)
        {
            MakeAllRunnable();
        }
        
        GeneticOperationsStep();
        BestIndividual = GetBestIndividual();
        BestIndividuals.Add(BestIndividual);
    }

    protected override void GeneticOperationsStep()
    {
        var crossover = SolverConfiguration.CrossoverProbability;
        var mutation = SolverConfiguration.MutationProbability;
        var horizontalModification = SolverConfiguration.HorizontalModificationProbability;

        for (var i = 0; i < Population.Count; i++)
        {
            Progress(i, Population.Count);

            var chance = RandomService.RandomPercentage();

            if (chance < crossover)
            {
                Cross();
            }
            else if (crossover <= chance && chance < crossover + mutation)
            {
                Mutate();
            }
            else if (crossover + mutation <= chance && chance < crossover + mutation + horizontalModification)
            {
                HorizontalMutate();
            }
        }
    }

    private void MakeAllRunnable()
    {
        RatePopulation();
        Population = Population.Where(individual => individual.FinishedAllCasesRun).ToList();

        while (Population.Count != TotalPopulationSize)
        {
            var addPopulationSize = TotalPopulationSize - Population.Count;

            EmitLog($"Runnable Individuals: {Population.Count}, " +
                    $"Generating additional population of size {addPopulationSize}..."
            );

            var addPopulation = ProgramGeneratorService.GenerateAdditionalPopulation(addPopulationSize, SolvingTask);
            Rate(addPopulation);
            addPopulation = addPopulation.Where(individual => individual.FinishedAllCasesRun).ToList();

            EmitLog($"Runnable Individuals in additional population: {addPopulation.Count}{Environment.NewLine}");

            Population.AddRange(addPopulation);
        }
    }

    private void RatePopulation()
    {
        Rate(Population);
    }

    private void Rate(IReadOnlyList<Individual> population)
    {
        var populationSize = population.Count;
        EmitLog($"Rating population of size {populationSize} {Environment.NewLine}");

        for (var i = 0; i < populationSize; i++)
        {
            Rate(population[i]);
            Progress(i, populationSize);
        }
    }

    private void Rate(Individual individual)
    {
        individual.FinishedAllCasesRun = true;

        InterpreterService.Feed(individual.Program.ToString());

        var testCases = individual.Task.TestCases.Take(SolverConfiguration.NumOfTestCases).AsEnumerable();
        foreach (var testCase in testCases)
        {
            try
            {
                InterpreterService.Run(testCase.Input.Values);
                if (InterpreterService.IsFinished)
                {
                    testCase.ProgramOutput.Values = InterpreterService.Outputs;
                }
                else
                {
                    individual.FinishedAllCasesRun = false;
                    break;
                }
            }
            catch (Exception e)
            {
                individual.FinishedAllCasesRun = false;
                break;
            }
        }

        if (individual.FinishedAllCasesRun is false)
        {
            individual.FitnessValue = double.NegativeInfinity;
            return;
        }

        var fitness = (double)(FitnessFunction.Run([individual]) ?? double.NegativeInfinity);
        individual.FitnessValue = fitness;
    }


    private void Cross()
    {
        var parent1 = TournamentHandlerService.Tournament(Population);
        var parent2 = TournamentHandlerService.Tournament(Population);

        if (parent1.Program.ChildrenNodes.Count == 1 || parent2.Program.ChildrenNodes.Count == 1)
        {
            return;
        }

        var childProgram = CrossingService.Cross(parent1.Program, parent2.Program);

        if (childProgram is null)
        {
            return;
        }

        var offspring = new Individual(childProgram, SolvingTask.Copy());

        Rate(offspring);
        TournamentHandlerService.NegativeTournament(Population, offspring);
    }

    private void Mutate()
    {
        var parent = TournamentHandlerService.Tournament(Population);
        var offspring = new Individual(parent.Program.Copy(), SolvingTask.Copy());

        var chance = RandomService.RandomPercentage();
        var pointMutation = SolverConfiguration.PointMutationProbability;
        var subtreeMutation = SolverConfiguration.SubtreeMutationProbability;

        if (offspring.Program.ChildrenNodes.Count == 1)
        {
            return;
        }

        if (chance < pointMutation)
        {
            MutatorService.PointMutate(offspring.Program);
        }
        else if (pointMutation <= chance && chance < pointMutation + subtreeMutation)
        {
            MutatorService.SubtreeMutate(offspring.Program);
        }

        Rate(offspring);
        TournamentHandlerService.NegativeTournament(Population, offspring);
    }

    private void HorizontalMutate()
    {
        var parent = TournamentHandlerService.Tournament(Population);
        var offspring = new Individual(parent.Program.Copy(), SolvingTask.Copy());

        var chance = RandomService.RandomPercentage();
        var newLine = SolverConfiguration.NewLineProbability;
        var deleteLine = SolverConfiguration.DeleteLineProbability;
        var swapLines = SolverConfiguration.SwapLinesProbability;

        if (chance < newLine)
        {
            HorizontalMutatorService.GrowOnceInsideBlock(offspring.Program);
        }
        else if (newLine <= chance && chance < newLine + deleteLine)
        {
            HorizontalMutatorService.DeleteLine(offspring.Program);
        }
        else if (newLine + deleteLine <= chance && chance < newLine + deleteLine + swapLines)
        {
            HorizontalMutatorService.SwapTwoLines(offspring.Program);
        }

        Rate(offspring);
        TournamentHandlerService.NegativeTournament(Population, offspring);
    }

    private bool IsSolverStuck()
    {
        const int limit = 15;

        if (BestIndividuals.Count < limit)
        {
            return false;
        }

        var diff = Math.Abs(GetBestIndividual(BestIndividuals).FitnessValue - BestIndividuals[^limit].FitnessValue);

        if (!(Math.Abs(BestIndividuals[^limit].FitnessValue) * 0.05 > diff)) return false;

        var best = GetBestIndividual(BestIndividuals);
        BestIndividuals.Clear();
        BestIndividuals.Add(best);

        EmitLog("Solver is stuck.");
        return true;
    }

    private Individual GetBestIndividual()
    {
        return Population
            .Where(individual => !double.IsNaN(individual.FitnessValue))
            .OrderByDescending(individual => individual.FitnessValue)
            .ThenBy(individual => individual.ProgramLength)
            .First();
    }

    private static Individual GetBestIndividual(List<Individual> bestIndividuals)
    {
        return bestIndividuals[^1];
    }

    private void Progress(int i, int max)
    {
        if ((i + 1) % 10 != 0) return;
        
        if (i + 1 != max)
        {
            var percent = (i + 1) / (double)max * 100;
            NotifyProceeded(Math.Round(percent, 2));
        }
        else
        {
            NotifyProceeded(100);
        }
    }
}