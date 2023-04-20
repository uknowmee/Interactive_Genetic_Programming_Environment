package Model.SmallNodes.Operators.Logic;

import Model.Node;
import Model.SmallNodes.Operators.Operator;
import Serialization.Token;

import java.util.ArrayList;

public class BoolOperator extends Operator {

    @Override
    public void mutate() {
        if (getValue().equals(" and ")) {
            setOperator(" or ");
        } else {
            setOperator(" and ");
        }
    }

    public BoolOperator(Node parentNode) {
        super(parentNode, "BoolOperator");

        if (getRandomInt(2) == 0) {
            setOperator(" and ");
        } else {
            setOperator(" or ");
        }
    }

    public BoolOperator(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, tokens);
    }
}
