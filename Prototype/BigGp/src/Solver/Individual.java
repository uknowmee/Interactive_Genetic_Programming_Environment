package Solver;

import Data.TestCase;
import Evaluators.Fitness;
import Generating.Task;
import Interpreter.EdWardInterpreter;
import Model.Program;

public class Individual {
    public boolean finishedAllCasesRun;
    private Task task;
    private Program program;

    private Fitness fitness;

    public double getFitnessValue() {
        return fitness.getValue();
    }
    public Fitness getFitness() {
        return fitness;
    }
    public void setFitnessValue(double value) {
        fitness.setValue(value);
    }

    public Task getTask() {
        return task;
    }

    public Program getProgram() {
        return program;
    }

    public void runProgramOnAllCases() {
        EdWardInterpreter edWardInterpreter = new EdWardInterpreter(program.getProgramString());

        for (TestCase testCase : task.getTestCases()) {

            edWardInterpreter.run(testCase.getInputValues());

            if (edWardInterpreter.isFinished()){
                testCase.setProgramOutput(edWardInterpreter.getProgramOutput());
            } else {
                return;
            }
        }

        finishedAllCasesRun = true;
    }

    @Override
    public String toString() {
        return  "# Fitness: " + -this.getFitnessValue() + "\n\n" + this.program.getProgramString();
    }

    public void initializeFitness(){
        this.fitness = new Fitness();
    }

    public Individual(Task task, Program program) {
        this.task = Task.copy(task);
        this.program = program;
        this.finishedAllCasesRun = false;
        this.fitness = null;
    }
}
