package Model.SmallNodes.Expressions.Logic.Childs;

import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Expressions.Logic.LogicExpression;
import Model.SmallNodes.Operators.Logic.BoolOperator;
import Serialization.Token;

import java.util.ArrayList;

public class BooleanExpression extends Node implements Crossable, SubtreeMutable {

    private LogicExpression leftExpression;
    private BoolOperator operator;
    private LogicExpression rightExpression;

    @Override
    public String toString() {
        return "(" + leftExpression.toString() + operator.toString() + rightExpression.toString() + ")";
    }

    public void setLogicExpression(Node oldExpr, LogicExpression logicExpression) {
        if (leftExpression.toString().equals(oldExpr.toString()) && leftExpression.hashCode() == oldExpr.hashCode()) {
            this.leftExpression = logicExpression;
        } else {
            this.rightExpression = logicExpression;
        }
    }
    @Override
    public void subtreeMutate() {
        if (this.getParentNode() instanceof LogicExpression logicExpression) {
            logicExpression.setBooleanExpression(new BooleanExpression(logicExpression));
        }
    }

    public ArrayList<Node> getChildrenAsNodes(){
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        nodes.addAll(leftExpression.getChildrenAsNodes());
        nodes.addAll(operator.getChildrenAsNodes());
        nodes.addAll(rightExpression.getChildrenAsNodes());

        return nodes;
    }

    public BooleanExpression(Node parentNode) {
        super(parentNode, "BooleanExpression", true);

        double lastNextLogicExpressionChance = ((LogicExpression) parentNode).getNEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE();
        leftExpression = new LogicExpression(this, lastNextLogicExpressionChance);
        operator = new BoolOperator(this);
        rightExpression = new LogicExpression(this, lastNextLogicExpressionChance);
    }

    public BooleanExpression(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, "BooleanExpression", true);
        tokens.remove(0);

        double lastNextLogicExpressionChance = ((LogicExpression) parentNode).getNEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE();
        leftExpression = new LogicExpression(this, lastNextLogicExpressionChance, tokens);
        operator = new BoolOperator(this, tokens);
        rightExpression = new LogicExpression(this, lastNextLogicExpressionChance, tokens);
    }
}
