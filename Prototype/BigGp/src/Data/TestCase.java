package Data;

import java.util.List;

public class TestCase {
    private Vector input;
    private Vector output;
    private Vector programOutput;

    public List<Double> getInputValues(){
        return input.getValues();
    }

    public List<Double> getOutputValues(){
        return output.getValues();
    }

    public List<Double> getProgramOutputValues(){
        return programOutput.getValues();
    }

    public void setProgramOutput(List<Double> programOutput) {
        this.programOutput.clear();
        programOutput.forEach(output -> this.programOutput.addValue(output));
    }

    public static TestCase copy(TestCase testCase){
        TestCase testCaseCopy = new TestCase(new Vector(), new Vector(), new Vector());

        testCase.input.getValues().forEach(val -> testCaseCopy.input.addValue(val));
        testCase.output.getValues().forEach(val -> testCaseCopy.output.addValue(val));
        testCase.programOutput.getValues().forEach(val -> testCaseCopy.programOutput.addValue(val));

        return testCaseCopy;
    }

    public TestCase(IVector input, IVector output, IVector programOutput) {
        this.input = (Vector) input;
        this.output = (Vector) output;
        this.programOutput = (Vector) programOutput;
    }
}
