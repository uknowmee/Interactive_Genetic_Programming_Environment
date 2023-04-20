package Evaluators.F32;

import Data.TestCase;
import Generating.Task;
import Model.Program;
import Solver.Individual;

import java.util.List;

public class F32 {
    public static double smallest(Individual individual) {
        double fitness = 0;
        Task task = individual.getTask();
        Program program = individual.getProgram();

        for (TestCase testCase : task.getTestCases()) {
            List<Double> input = testCase.getInputValues();
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
}
