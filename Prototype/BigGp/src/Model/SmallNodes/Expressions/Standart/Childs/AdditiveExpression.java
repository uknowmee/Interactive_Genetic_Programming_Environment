package Model.SmallNodes.Expressions.Standart.Childs;

import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Expressions.Standart.Expression;
import Model.SmallNodes.Expressions.Standart.TwoArgExpression;
import Model.SmallNodes.Operators.Arithmetic.AdditiveOperator;
import Serialization.Token;

import java.util.ArrayList;

public class AdditiveExpression extends Node implements Crossable, TwoArgExpression, SubtreeMutable {

    private Expression leftExpression;
    private AdditiveOperator operator;
    private Expression rightExpression;

    @Override
    public String toString() {
        return "(" + leftExpression.toString() + operator.toString() + rightExpression.toString() + ")";
    }

    public void setExpression(Node oldExpr, Expression expression) {
        if (leftExpression.toString().equals(oldExpr.toString()) && leftExpression.hashCode() == oldExpr.hashCode()) {
            this.leftExpression = expression;
        } else {
            this.rightExpression = expression;
        }
    }

    @Override
    public void subtreeMutate() {
        if (this.getParentNode() instanceof Expression expression) {
            expression.subtreeMutateTwoArgExpression();
        }
    }

    public Expression getLeftExpression(){
        return leftExpression;
    }

    public Expression getRightExpression(){
        return rightExpression;
    }

    public String getOperatorValue(){
        return operator.getValue();
    }

    public ArrayList<Node> getChildrenAsNodes(){
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        nodes.addAll(leftExpression.getChildrenAsNodes());
        nodes.addAll(operator.getChildrenAsNodes());
        nodes.addAll(rightExpression.getChildrenAsNodes());

        return nodes;
    }

    public AdditiveExpression(Node parentNode) {
        super(parentNode, "AdditiveExpression", true);

        double lastNextTwoArgExpressionChance = ((Expression) parentNode).getNEXT_TWO_ARG_EXPRESSION_CHANCE();
        leftExpression = new Expression(this, lastNextTwoArgExpressionChance);
        operator = new AdditiveOperator(this);
        rightExpression = new Expression(this, lastNextTwoArgExpressionChance);
    }

    public AdditiveExpression(Node parentNode, Expression left, Expression right, String operator) {
        super(parentNode, "AdditiveExpression", true);

        leftExpression = left;
        this.operator = new AdditiveOperator(this);

        while (this.operator.getValue().equals(operator)){
            this.operator = new AdditiveOperator(this);
        }

        rightExpression = right;
    }

    public AdditiveExpression(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, "AdditiveExpression", true);

        tokens.remove(0);

        double lastNextTwoArgExpressionChance = ((Expression) parentNode).getNEXT_TWO_ARG_EXPRESSION_CHANCE();
        leftExpression = new Expression(this, lastNextTwoArgExpressionChance, tokens);
        operator = new AdditiveOperator(this, tokens);
        rightExpression = new Expression(this, lastNextTwoArgExpressionChance, tokens);
    }
}
