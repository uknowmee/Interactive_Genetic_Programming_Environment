package Tournaments;

import Utils.Config.BigGpConfig;
import Evaluators.Evaluator;
import Solver.Individual;

import java.util.List;
import java.util.Random;

public class TournamentHandler {
    private static final Random RANDOM = new Random();

    public static Individual tournament(List<Individual> population, BigGpConfig config) {
        Individual best = population.get(RANDOM.nextInt(population.size()));
        Individual competitor;

        for (int i = 0; i < config.getTournamentSize(); i++) {
            competitor = population.get(RANDOM.nextInt(population.size()));
            if (competitor.getFitnessValue() > best.getFitnessValue() &&
                    !Double.isNaN(competitor.getFitnessValue())) {
                best = competitor;
            }
        }

        return best;
    }

    public static void negativeTournament(List<Individual> population, Individual individual, BigGpConfig config, int epoch) {
        Evaluator.run(individual, epoch);

        Individual worst = population.get(RANDOM.nextInt(population.size()));
        Individual competitor;

        for (int i = 0; i < config.getTournamentSize(); i++) {
            competitor = population.get(RANDOM.nextInt(population.size()));
            if (competitor.getFitnessValue() < worst.getFitnessValue() &&
                    !Double.isNaN(competitor.getFitnessValue())) {
                worst = competitor;
            }
        }

        population.set(population.indexOf(worst), individual);
    }
}
