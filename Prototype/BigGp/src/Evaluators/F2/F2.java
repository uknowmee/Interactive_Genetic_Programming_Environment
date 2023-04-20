package Evaluators.F2;

import Data.TestCase;
import Generating.Task;
import Model.Program;
import Solver.Individual;

import java.util.List;

public class F2 {
    public static double sameOrderAsInputs(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> input = testCase.getInputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 3) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= Math.abs(input.get(0) - programOutput.get(0));
                fitness -= Math.abs(input.get(1) - programOutput.get(1));
                fitness -= Math.abs(input.get(2) - programOutput.get(2));
            }
        }
        return fitness;
    }
    public static double howMuchPositive(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> input = testCase.getInputValues();
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            List<Double> moreThanZero = output.stream().filter(out -> out > 0).toList();
            if (!(programOutput.size() == 0 || programOutput.size() == 1 || programOutput.size() == 2 || programOutput.size() == 3)) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= Math.pow(Math.abs(moreThanZero.size() - programOutput.size()), 2);
            }
        }
        return fitness;
    }

    public static double x0MoreThan0(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 1) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                fitness -= Math.abs(output.get(0) - programOutput.get(0));
            }
        }
        return fitness;
    }

    public static double x0x1MoreThan0(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> input = testCase.getInputValues();
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 2) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                for (int i = 0; i < 2; i++) {
                    fitness -= Math.abs(output.get(i) - programOutput.get(i));
                }
            }
        }
        return fitness;
    }

    public static double x0x1x2MoreThan0(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> input = testCase.getInputValues();
            List<Double> output = testCase.getOutputValues();
            List<Double> programOutput = testCase.getProgramOutputValues();

            if (programOutput.size() != 3) {
                fitness -= 2000;
                fitness -= program.getProgramLength() * 5;
            } else {
                for (int i = 0; i < 3; i++) {
                    fitness -= Math.abs(output.get(i) - programOutput.get(i));
                }
            }
        }
        return fitness;
    }
}
