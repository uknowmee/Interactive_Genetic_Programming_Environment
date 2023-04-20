package Model.SmallNodes.Operators.Logic;

import Model.Node;
import Model.SmallNodes.Operators.Operator;
import Serialization.Token;

import java.util.ArrayList;

public class CompareOperator extends Operator {

    private final int BOUND;

    @Override
    public void mutate() {

        String newOperator = getSpecifiedOperator(getRandomInt(BOUND));

        while (newOperator.equals(getValue())) {
            newOperator = getSpecifiedOperator(getRandomInt(BOUND));
        }

        setOperator(newOperator);
    }

    private String getSpecifiedOperator(int operatorId) {
        String operatorValue = "";

        switch (operatorId) {
            case 0 -> operatorValue = " == ";
            case 1 -> operatorValue = " != ";
            case 2 -> operatorValue = " > ";
            case 3 -> operatorValue = " < ";
            case 4 -> operatorValue = " >= ";
            case 5 -> operatorValue = " <= ";
        }

        return operatorValue;
    }

    public CompareOperator(Node parentNode) {
        super(parentNode, "CompareOperator");
        BOUND = 6;

        setOperator(getSpecifiedOperator(getRandomInt(BOUND)));

    }

    public CompareOperator(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, tokens);
        BOUND = 6;
    }
}
