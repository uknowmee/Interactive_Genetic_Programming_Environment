package Evaluators;

import Data.TestCase;
import Evaluators.F2.F2;
import Evaluators.F32.F32;
import Generating.Task;
import Model.Program;
import Solver.Individual;

import java.util.List;
import java.util.Objects;

public class Evaluator {

    private static void calculateFitness(Individual individual, int epoch) {
        if (individual.getFitness() == null) {
            individual.initializeFitness();
        }

        if (!individual.finishedAllCasesRun) {
            individual.setFitnessValue(-1.0e34);
            return;
        }

        double fitnessValue = 0;
        switch (individual.getTask().getTaskName()) {
            case "1_1_A", "1_1_B" -> {
                fitnessValue = calculate1_1_A(individual);
            }
            case "1_1_C" -> {
                fitnessValue = calculate1_1_C(individual);
            }
            case "1_1_D", "1_1_E" -> {
                fitnessValue = calculate1_1_D(individual);
            }case "1_1_F" -> {
                fitnessValue = calculate1_1_F(individual);
            }
            case "1_2_A", "1_2_B", "1_2_C", "1_2_D", "F_1" -> {
                fitnessValue = calculate1_2_A(individual);
            }
            case "1_2_E" -> {
                fitnessValue = calculate1_2_E(individual);
            }
            case "1_3_A" -> {
                fitnessValue = calculate1_3_A(individual);
            }
            case "1_3_B" -> {
                fitnessValue = calculate1_3_B(individual);
            }
            case "1_4_A" -> {
                fitnessValue = calculate1_4_A(individual);
            }
            case "F_2" -> {
                fitnessValue = calculateF_2(individual);
            }
            case "F_3_2" -> {
                fitnessValue = calculateF_3_2(individual);
            }
            case "F_4\\1" -> {
                fitnessValue = calculateF_4_1(individual);
            }
            case "F_4\\2" -> {
                fitnessValue = calculateF_4_2(individual);
            }
            case "F_4\\3" -> {
                fitnessValue = calculateF_4_3(individual);
            }
        }
        individual.setFitnessValue(fitnessValue);
    }

    private static double calculate1_1_A(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();
        double diff = 1e34;

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() == 0) {
                fitness -= 1000;
                fitness -= program.getProgramLength() * 5;
            } else {
                for (double value : programOutput) {
                    if (Math.abs(output.get(0) - value) < diff) {
                        diff = Math.abs(output.get(0) - value);
                    }
                }
                fitness -= diff;
            }
        }

        return fitness;
    }

    private static double calculate1_1_C(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();
        double diff = 1e34;

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() == 0) {
                fitness -= 90000;
                fitness -= program.getProgramLength() * 5;
            } else {
                for (double value : programOutput) {
                    if (Math.abs(output.get(0) - value) < diff) {
                        diff = Math.abs(output.get(0) - value);
                    }
                }
                fitness -= diff;
            }
        }

        return fitness;
    }

    private static double calculate1_1_D(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() == 0) {
                fitness -= 1000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= (programOutput.size() - 1) * 20;
                double diff = Math.abs(output.get(0) - programOutput.get(0));
                if (diff > 1) {
                    fitness -= program.getProgramLength();
                }
                fitness -= diff;
            }
        }

        return fitness;
    }

    private static double calculate1_1_F(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 1) {
                fitness -= 1000;
                fitness -= program.getProgramLength() * 5;
            } else {
                double diff = Math.abs(output.get(0) - programOutput.get(0));
                if (diff > 0.1) {
                    fitness -= program.getProgramLength();
                }
                fitness -= diff;
            }
        }

        return fitness;
    }

    private static double calculate1_2_A(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() == 0) {
                fitness -= 1000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= (programOutput.size() - 1) * 20;
                fitness -= Math.abs(output.get(0) - programOutput.get(0));
            }
        }

        return fitness;
    }

    private static double calculate1_2_E(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() == 0) {
                fitness -= 1000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= (programOutput.size() - 1) * 20;
                double val;
                if (Math.abs(programOutput.get(0)) < 0.001) {
                    val = Math.abs(output.get(0) - programOutput.get(0));
                } else {
                    val = Math.abs(1 - output.get(0) / programOutput.get(0));
//                    val = Math.pow(Math.abs(1 - output.get(0) / programOutput.get(0)), 2);
                }
                if (fitness > -400000) {
                    fitness -= val;
                }
            }
        }

        return fitness;
    }

    private static double calculate1_3_A(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() == 0) {
                fitness -= 1000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= (programOutput.size() - 1) * 20;
                if (fitness > -400000) {
                    fitness -= Math.abs(output.get(0) - programOutput.get(0)) / Math.abs(output.get(0));
                }
            }
        }

        return fitness;
    }

    private static double calculate1_3_B(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() == 0) {
                fitness -= 1000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= (programOutput.size() - 1) * 20;
                if (fitness > -400000) {
                    fitness -= Math.abs(1 - output.get(0) / programOutput.get(0));
                }
            }
        }

        return fitness;
    }

    private static double calculate1_4_A(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> input = testCase.getInputValues();
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

//            if (programOutput.size() == 0 || program.getProgramLength() > 5) {*
            if (programOutput.size() == 0) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= (programOutput.size() - 1) * 20;
                if (fitness > -400000) {
                    fitness -= Math.abs(output.get(0) - programOutput.get(0));
                }
            }
        }

        return fitness;
    }

    private static double calculateF_2(Individual individual) {
        return F2.sameOrderAsInputs(individual);
//        return F2.x0MoreThan0(individual);
//        return F2.x0x1MoreThan0(individual);
//        return F2.howMuchPositive(individual);
    }

    private static double calculateF_3_2(Individual individual) {
        return F32.smallest(individual);
    }

    private static double calculateF_4_1(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 1 || !(programOutput.contains(0.0) || programOutput.contains(1.0))) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                if (fitness > -400000) {
                    fitness -= Math.abs(output.get(0) - programOutput.get(0));
                }
            }
        }

        return fitness;
    }

    private static double calculateF_4_2(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 1 || !(programOutput.contains(0.0) || programOutput.contains(1.0))) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                if (fitness > -400000) {
                    fitness -= Math.abs(output.get(0) - programOutput.get(0));
                }
            }
        }

        return fitness;
    }

    private static double calculateF_4_3(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> input = testCase.getInputValues();
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 1 || !(programOutput.contains(0.0) || programOutput.contains(1.0))) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                if (fitness > -400000) {
                    if (input.get(2) != 1 && programOutput.get(0) == 1){
                        fitness -= 20;
                    }
                    if (!(input.get(0) == 1 || input.get(1) == 1) && programOutput.get(0) == 1){
                        fitness -= 10;
                    }
                    fitness -= Math.abs(output.get(0) - programOutput.get(0)) * 5;
                }
            }
        }

        return fitness;
    }

    public static void run(List<Individual> population, int epoch) {
        int populationSize = population.size();
        System.out.println("\n[Running population of size: " + populationSize + "]");

        Individual individual;
        for (int i = 0; i < populationSize; i++) {
            individual = population.get(i);
            individual.runProgramOnAllCases();
            calculateFitness(individual, epoch);

            if ((i + 1) % 10 == 0) {
                if (i + 1 != populationSize) {
                    System.out.print((i + 1) + " of " + populationSize + "\r");
                } else {
                    System.out.print((i + 1) + " of " + populationSize + "\n");
                }
            }
        }
    }

    public static void run(Individual individual, int epoch) {
        individual.runProgramOnAllCases();
        calculateFitness(individual, epoch);
    }
}
