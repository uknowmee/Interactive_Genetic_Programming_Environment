package Model.SmallNodes.Operators.Arithmetic;

import Model.Node;
import Model.SmallNodes.Expressions.Standart.TwoArgExpression;
import Model.SmallNodes.Operators.Operator;
import Serialization.Token;

import java.util.ArrayList;


public class MultiplicativeOperator extends Operator {

    @Override
    public void mutate() {
        if (this.getParentNode() instanceof TwoArgExpression twoArgExpression){
            twoArgExpression.mutate();
        }
    }

    public MultiplicativeOperator(Node parentNode) {
        super(parentNode, "MultiplicativeOperator");

        if (getRandomInt(2) == 0){
            setOperator(" * ");
        } else {
            setOperator(" / ");
        }
    }

    public MultiplicativeOperator(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, tokens);
    }
}
