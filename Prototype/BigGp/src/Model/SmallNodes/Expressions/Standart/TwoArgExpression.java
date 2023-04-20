package Model.SmallNodes.Expressions.Standart;

import Model.Node;
import Model.SmallNodes.Expressions.Standart.Childs.AdditiveExpression;
import Model.SmallNodes.Expressions.Standart.Childs.MultiplicativeExpression;

import java.util.Random;

public interface TwoArgExpression {

    private void mutateOperator(Expression left, Expression right, String operator) {
        Node parent = ((Node) this).getParentNode();

        if (new Random().nextInt(2) == 0) {
            AdditiveExpression add = new AdditiveExpression(parent, left, right, operator);

            ((Expression) parent).setAdditiveExpression(add);
        } else {
            MultiplicativeExpression mul = new MultiplicativeExpression(parent, left, right, operator);

            ((Expression) parent).setMultiplicativeExpression(mul);
        }
    }

    public default void mutate() {
        Expression left = null;
        Expression right = null;
        String operator = "";

        if (this instanceof AdditiveExpression additiveExpression) {
            left = additiveExpression.getLeftExpression();
            right = additiveExpression.getRightExpression();
            operator = additiveExpression.getOperatorValue();


        } else if (this instanceof MultiplicativeExpression multiplicativeExpression) {
            left = multiplicativeExpression.getLeftExpression();
            right = multiplicativeExpression.getRightExpression();
            operator = multiplicativeExpression.getOperatorValue();
        }

        mutateOperator(left, right, operator);
    }
}
