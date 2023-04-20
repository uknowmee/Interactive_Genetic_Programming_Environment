package Generating;

import Utils.Config.BigGpConfig;
import Model.Program;
import Solver.Individual;

import java.util.ArrayList;
import java.util.List;

public class ProgramGenerator {

    private static int getNumOfInputs(String problemName) {
        switch (problemName) {
            case "1_2_A", "1_2_B", "1_2_C", "1_2_D", "1_2_E", "1_3_A", "1_3_B", "F_1", "F_4\\2" -> {
                return 2;
            }
            case "1_4_A", "F_2", "F_4\\3"-> {
                return 3;
            }
            case "F_3_2" -> {
                return 4;
            }
            default -> {
                return 1;
            }
        }
    }

    public static List<Individual> makePopulation(BigGpConfig config, Task task, String problemName) {
        int populationSize = config.getPopulationSize();
        return makeAdditionalPopulation(populationSize, task, problemName);
    }

    public static List<Individual> makeAdditionalPopulation(int populationSize, Task task, String problemName) {
        List<Individual> population = new ArrayList<>();

        int numOfInputs = getNumOfInputs(problemName);

        Program program;
        for (int i = 0; i < populationSize; i++) {
            program = new Program(numOfInputs);
            program.addRandomNodes();
            population.add(new Individual(task, program));

            if ((i + 1) % 10 == 0) {
                if (i + 1 != populationSize) {
                    System.out.print((i + 1) + " of " + populationSize + " has been created\r");
                } else {
                    System.out.print((i + 1) + " of " + populationSize + " has been created\n");
                }
            }
        }

        return population;
    }
}