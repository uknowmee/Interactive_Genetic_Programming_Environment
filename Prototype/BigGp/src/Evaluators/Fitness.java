package Evaluators;

public class Fitness {
    private double value;
    private int calculations;

    public void setValue(double value) {
        this.value = value;
    }

    public double getValue() {
        return value;
    }
    public int getCalculations() {
        return calculations;
    }
    public void incrementCalculations() {
        calculations += 1;
    }
    public void resetCalculations() {
        calculations = 1;
    }

    public Fitness(){
        this.value = -1.0e34;
        this.calculations = 0;
    }
}
