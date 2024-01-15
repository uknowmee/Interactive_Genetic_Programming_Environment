using Shared;

namespace Strategies.Evolution.Interfaces;

public interface ITournamentHandlerService
{
    Individual Tournament(List<Individual> population);
    void NegativeTournament(List<Individual> population, Individual offspring);
}