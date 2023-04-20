package Model.SmallNodes.Expressions.Logic.Childs;

import Model.BaseNodes.ForStatement.ForStatement;
import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Expressions.Logic.LogicExpression;
import Model.SmallNodes.Expressions.Standart.Expression;
import Model.SmallNodes.Operators.Logic.CompareOperator;
import Serialization.Token;

import java.util.ArrayList;

public class ComparisonExpression extends Node implements Crossable, SubtreeMutable {
    private Expression leftExpression;
    private CompareOperator operator;
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
        if (this.getParentNode() instanceof ForStatement forStatement) {
            forStatement.setComparisonExpression(new ComparisonExpression(forStatement, (forStatement.getNEXT_COMPARISON_EXPRESSION_CHANCE())));
        } else if (this.getParentNode() instanceof LogicExpression logicExpression) {
            logicExpression.setComparisonExpression(new ComparisonExpression(this.getParentNode()));
        }
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        nodes.addAll(leftExpression.getChildrenAsNodes());
        nodes.addAll(operator.getChildrenAsNodes());
        nodes.addAll(rightExpression.getChildrenAsNodes());

        return nodes;
    }

    public ComparisonExpression(Node parentNode) {
        super(parentNode, "ComparisonExpression", true);

        double lastNextLogicExpressionChance = ((LogicExpression) parentNode).getNEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE();
        leftExpression = new Expression(this, lastNextLogicExpressionChance);
        operator = new CompareOperator(this);
        rightExpression = new Expression(this, lastNextLogicExpressionChance);
    }

    public ComparisonExpression(Node parentNode, double NewExpressionInForComparisonChance) {
        super(parentNode, "ComparisonExpression", true);

        leftExpression = new Expression(this, NewExpressionInForComparisonChance);
        operator = new CompareOperator(this);
        rightExpression = new Expression(this, NewExpressionInForComparisonChance);
    }

    public ComparisonExpression(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, "ComparisonExpression", true);
        tokens.remove(0);

        double lastNextLogicExpressionChance = ((LogicExpression) parentNode).getNEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE();
        leftExpression = new Expression(this, lastNextLogicExpressionChance, tokens);
        operator = new CompareOperator(this, tokens);
        rightExpression = new Expression(this, lastNextLogicExpressionChance, tokens);
    }

    public ComparisonExpression(Node parentNode, double NewExpressionInForComparisonChance, ArrayList<Token> tokens) {
        super(parentNode, "ComparisonExpression", true);
        tokens.remove(0);

        leftExpression = new Expression(this, NewExpressionInForComparisonChance, tokens);
        operator = new CompareOperator(this, tokens);
        rightExpression = new Expression(this, NewExpressionInForComparisonChance, tokens);
    }
}
