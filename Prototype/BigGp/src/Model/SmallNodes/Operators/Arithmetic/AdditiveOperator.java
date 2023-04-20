package Model.SmallNodes.Operators.Arithmetic;

import Model.BaseNodes.ForStatement.ForIncrement;
import Model.Node;
import Model.SmallNodes.Expressions.Standart.TwoArgExpression;
import Model.SmallNodes.Operators.Operator;
import Serialization.Token;

import java.util.ArrayList;

public class AdditiveOperator extends Operator {

    @Override
    public void mutate() {
        if (this.getParentNode() instanceof ForIncrement){
            if (getValue().equals(" + ")){
                setOperator(" - ");
            } else {
                setOperator(" + ");
            }
        } else if (this.getParentNode() instanceof TwoArgExpression twoArgExpression){
            twoArgExpression.mutate();
        }
    }

    public AdditiveOperator(Node parentNode) {
        super(parentNode, "AdditiveOperator");
        if (getRandomInt(2) == 0){
            setOperator(" + ");
        } else {
            setOperator(" - ");
        }
    }

    public AdditiveOperator(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, tokens);
    }
}
