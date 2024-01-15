using Configuration.Solver;
using Shared;
using Strategies.Evolution.Interfaces;
using Utils;

namespace Strategies.Evolution;

public class TournamentHandlerService : ITournamentHandlerService
{
    private readonly ISolverConfiguration _solverConfiguration;
    
    public TournamentHandlerService(ISolverConfiguration solverConfiguration)
    {
        _solverConfiguration = solverConfiguration;
    }
    
    public Individual Tournament(List<Individual> population)
    {
        var tournamentSize = _solverConfiguration.TournamentSize;
        var best = population[RandomService.RandomInt(population.Count)];

        for (var i = 0; i < tournamentSize; i++)
        {
            var competitor = population[RandomService.RandomInt(population.Count)];
            if (competitor.FitnessValue > best.FitnessValue && double.IsNaN(competitor.FitnessValue) is false)
            {
                best = competitor;
            }
        }
        
        return best;
    }

    public void NegativeTournament(List<Individual> population, Individual offspring)
    {
        var tournamentSize = _solverConfiguration.TournamentSize;
        var worst = population[RandomService.RandomInt(population.Count)];

        for (var i = 0; i < tournamentSize; i++)
        {
            var competitor = population[RandomService.RandomInt(population.Count)];
            if (competitor.FitnessValue < worst.FitnessValue && double.IsNaN(competitor.FitnessValue) is false)
            {
                worst = competitor;
            }
        }

        population.Set(worst, offspring);
    }
}