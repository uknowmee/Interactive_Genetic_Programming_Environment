package Solver;

import Utils.Config.BigGpConfig;
import Evaluators.Evaluator;
import Evolutions.Crosser;
import Evolutions.LineBuilder;
import Evolutions.Mutator;
import Generating.ProgramGenerator;
import Generating.Task;
import Model.Program;
import Serialization.Serializer;
import Tournaments.TournamentHandler;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Random;

public class Solver {
    private static final Random RANDOM = new Random();

    private BigGpConfig config;
    private final Task task;
    private final String problemFolder;

    private List<Individual> population;
    private final List<Individual> bestIndividuals;

    private String saveProgram(Program program) {
        Serializer serializer = new Serializer(problemFolder);
        serializer.writeProgramToTxtAndToJson(program);

        return serializer.getFolder();
    }

    private void saveTask(Task task, String path) {
        path += "data.json";

        task.save(path);
    }

    private void save(Individual bestIndividual) {
//        TODO: Uncomment this!!
        String path = saveProgram(bestIndividual.getProgram());
        saveTask(bestIndividual.getTask(), path);
    }

    private Individual getBestIndividualFromPopulation() {
        return population
                .stream()
                .filter(v -> !Double.isNaN(v.getFitnessValue()))
                .max(Comparator.comparing(v -> v.getFitnessValue()))
                .stream()
                .min(Comparator.comparing(v -> v.getProgram().getProgramLength()))
                .get();
    }

    private Individual getBestIndividualFromBestIndividuals(){
        return bestIndividuals.get(bestIndividuals.size() - 1);
    }

    private double getAvgFitness() {
        double avg = 0;

        for (Individual individual : population) {
            avg += individual.getFitnessValue();
        }

        return -avg / population.size();
    }

    private boolean isProblemSolved(Individual bestIndividual) {
        return bestIndividual.getFitnessValue() > -config.getError();
    }

    private void makeAllRunnable(int moreIndividuals, int epoch) {
        int currentPopulationSize = population.size();
        Evaluator.run(population, epoch);
        population = new ArrayList<>(population.stream().filter(individual -> individual.finishedAllCasesRun).toList());

        int addPopulationSize;
        List<Individual> addPopulation;

        while (population.size() != currentPopulationSize + moreIndividuals) {
            addPopulationSize = currentPopulationSize + moreIndividuals - population.size();

            System.out.println("\n[Runnable individuals: " + population.size() +
                    ", Generating additional population of size: " + addPopulationSize + "]");

            addPopulation = ProgramGenerator.makeAdditionalPopulation(addPopulationSize, task, task.getTaskName());
            Evaluator.run(addPopulation, epoch);
            addPopulation = addPopulation.stream().filter(individual -> individual.finishedAllCasesRun).toList();

            System.out.println("\n[Runnable individuals in additional population: " + addPopulation.size() + "]");

            population.addAll(new ArrayList<>(addPopulation));
        }
    }

    private static double getRandomPercentages() {
        return RANDOM.nextDouble() * 100;
    }

    private boolean isSolverStuck(){
        int limit = 15;
        if (bestIndividuals.size() < limit) {
            return false;
        }

        var diff = Math.abs(getBestIndividualFromBestIndividuals().getFitnessValue() - bestIndividuals.get(bestIndividuals.size() - limit).getFitnessValue());
        if (Math.abs(bestIndividuals.get(bestIndividuals.size() - limit).getFitnessValue()) * 0.05 > diff) {
            Individual best = getBestIndividualFromBestIndividuals();
            bestIndividuals.clear();
            bestIndividuals.add(best);

            System.out.println("\n[SOLVER IS STUCK!!]");
            return true;
        }
        return false;
    }

    private void refreshPopulation(int epoch){
        System.out.println("[REFRESHING POPULATION]");
        makeAllRunnable(population.size() / 2, 0);
    }

    public void solve() {
        System.out.println("\n[Making initial population]");
        this.population = ProgramGenerator.makePopulation(config, task, task.getTaskName());
        makeAllRunnable(0, 0);

        Individual bestIndividual = getBestIndividualFromPopulation();
        this.bestIndividuals.add(bestIndividual);
        for (int epoch = 0; epoch < config.getGenerations(); epoch++) {
            this.config = BigGpConfig.readConfig();
            if (isSolverStuck()){
                refreshPopulation(epoch);
            }

            System.out.println("\n[Generation number: " + epoch + " / " + config.getGenerations() + ", population size: " + population.size() + "]");
            System.out.println("[Best individual fitness: " + -bestIndividual.getFitnessValue() + "]");
            System.out.println("[AVG fitness: " + getAvgFitness() + "]");

            if (isProblemSolved(bestIndividual)) {
                save(bestIndividual);
                System.exit(100);
                return;
            }

            procedureEpoch(epoch);

            bestIndividual = getBestIndividualFromPopulation();
            this.bestIndividuals.add(bestIndividual);
        }
    }

    private void procedureEpoch(int epoch){
        double chance;
        double crossProbability = config.getCrossProbability();
        double mutationProbability = config.getMutationProbability();
        double lineChangingProbability = config.getLineChangingProbability();
        for (int j = 0; j < population.size(); j++) {

            if ((j + 1) % 10 == 0) {
                if (j + 1 != population.size()) {
                    System.out.print(((double) (j + 1) / (double) population.size()) * 100 + "%\r");
                } else {
                    System.out.print("100%\n");
                }
            }

            chance = getRandomPercentages();
            if (chance < crossProbability) {
                cross(epoch);
            } else if (crossProbability <= chance && chance < crossProbability + mutationProbability) {
                mutate(epoch);
            } else if (crossProbability + mutationProbability <= chance && chance < crossProbability + mutationProbability + lineChangingProbability) {
                lineChange(epoch);
            }
        }
    }

    private void cross(int epoch) {
        Individual parent1 = TournamentHandler.tournament(population, config);
        Individual parent2 = TournamentHandler.tournament(population, config);

        Crosser crosser = new Crosser();
        Program program = null;
        if (parent1.getProgram().getChildrenNodes().size() == 1 || parent2.getProgram().getChildrenNodes().size() == 1) {
            return;
        }
        try {
            program = crosser.cross(parent1.getProgram(), parent2.getProgram(), 30);
        } catch (Exception e) {
//            Do nothing
        }

        if (program == null) {
            return;
        }

        Individual offspring = new Individual(task, program);
        TournamentHandler.negativeTournament(population, offspring, config, epoch);
    }

    private void mutate(int epoch) {
        Individual parent = TournamentHandler.tournament(population, config);
        Individual offspring = new Individual(task, parent.getProgram());

        double pointMutation = config.getPointMutationProbability();
        double subtreeMutation = config.getSubtreeMutationProbability();
        double chance = getRandomPercentages();
        Mutator mutator = new Mutator();

        if (offspring.getProgram().getChildrenNodes().size() == 1) {
            return;
        }
        if (chance < pointMutation) {
            mutator.pointMutation(offspring.getProgram());
        } else if (pointMutation <= chance && chance < pointMutation + subtreeMutation) {
            mutator.subtreeMutation(offspring.getProgram());
        }

        TournamentHandler.negativeTournament(population, offspring, config, epoch);
    }

    private void lineChange(int epoch) {
        Individual parent = TournamentHandler.tournament(population, config);
        Individual offspring = new Individual(task, parent.getProgram());

        double newLineProbability = config.getNewLineProbability();
        double deleteLineProbability = config.getDeleteLineProbability();
        double swapLineProbability = config.getSwapLineProbability();
        double chance = getRandomPercentages();
        LineBuilder lineBuilder = new LineBuilder(offspring.getProgram());

        if (chance < newLineProbability) {
            lineBuilder.growOnceInsideBlock();
        } else if (newLineProbability <= chance && chance < newLineProbability + deleteLineProbability) {
            lineBuilder.deleteLine();
        } else if (newLineProbability + deleteLineProbability <= chance && chance < newLineProbability + deleteLineProbability + swapLineProbability) {
            lineBuilder.swapTwoLines();
        }

        TournamentHandler.negativeTournament(population, offspring, config, epoch);
    }

    public Solver(BigGpConfig config, Task task) {
        this.config = config;
        this.task = task;
        this.problemFolder = config.getTaskFolder();
        this.bestIndividuals = new ArrayList<>();
    }

    public static void main(String[] args) {
        BigGpConfig config = BigGpConfig.readConfig();
        Task task = Task.readTaskFromFolder(config.getTasksFolder() + config.getTaskFolder());

        System.out.println("\n[Solving: " + task.getTaskName() + "]");
        System.out.println(config);

        Solver solver = new Solver(config, task);
        solver.solve();
    }
}
