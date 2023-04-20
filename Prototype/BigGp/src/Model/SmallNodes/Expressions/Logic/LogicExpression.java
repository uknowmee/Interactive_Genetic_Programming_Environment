package Model.SmallNodes.Expressions.Logic;

import Utils.Config.BigGpConfig;
import Model.BaseNodes.IfStatement.IfStatement;
import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Expressions.Logic.Childs.BooleanExpression;
import Model.SmallNodes.Expressions.Logic.Childs.ComparisonExpression;
import Serialization.Token;

import java.util.ArrayList;

public class LogicExpression extends Node implements AddRandomLogicExpression, Crossable, SubtreeMutable {

    private double NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE;
    private ComparisonExpression comparisonExpression;
    private BooleanExpression booleanExpression;

    @Override
    public String toString() {
        if (comparisonExpression != null) {
            return comparisonExpression.toString();
        } else if (booleanExpression != null) {
            return booleanExpression.toString();
        }
//        should never happen
        return "";
    }

    @Override
    public double getNEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE() {
        return NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE;
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        if (comparisonExpression != null) {
            nodes.addAll(comparisonExpression.getChildrenAsNodes());
        } else if (booleanExpression != null) {
            nodes.addAll(booleanExpression.getChildrenAsNodes());
        }

        return nodes;
    }

    public void setComparisonExpression(ComparisonExpression comparisonExpression) {
        this.comparisonExpression = comparisonExpression;
    }

    @Override
    public void addRandomLogicExpression() {
        LogicExpressionChild logicExpressionChild = LogicExpressionChild.randomChild();
        switch (logicExpressionChild) {
            case COMP_EXPRESSION -> comparisonExpression = new ComparisonExpression(this);
            case BOOL_EXPRESSION -> {
                if (getRandomPercentages() < NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE) {
                    booleanExpression = new BooleanExpression(this);
                } else {
                    comparisonExpression = new ComparisonExpression(this);
                }
            }
        }
    }

    public void setBooleanExpression(BooleanExpression booleanExpression) {
        this.booleanExpression = booleanExpression;
    }

    @Override
    public void subtreeMutate() {
        if (this.getParentNode() instanceof IfStatement ifStatement) {
            ifStatement.setLogicExpression(new LogicExpression(ifStatement));
        } else if (this.getParentNode() instanceof BooleanExpression boolExpr){
            boolExpr.setLogicExpression(this, new LogicExpression(boolExpr, NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE));
        }
    }

    public LogicExpression(Node parentNode) {
        super(parentNode, "Expression", true);
        BigGpConfig config = BigGpConfig.readConfig();

        this.comparisonExpression = null;
        this.booleanExpression = null;

        this.NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE = config.getNewLogicExpressionChance();

        addRandomLogicExpression();
    }

    public LogicExpression(Node parentNode, double lastNextLogicExpressionChance) {
        super(parentNode, "Expression", true);

        this.comparisonExpression = null;
        this.booleanExpression = null;

        this.NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE = lastNextLogicExpressionChance;

        addRandomLogicExpression();
    }

    public LogicExpression(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, "Expression", true);
        tokens.remove(0);

        BigGpConfig config = BigGpConfig.readConfig();

        this.NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE = config.getNewLogicExpressionChance();

        switch (tokens.get(0).getNAME()) {
            case "ComparisonExpression" -> comparisonExpression = new ComparisonExpression(this, tokens);
            case "BooleanExpression" -> booleanExpression = new BooleanExpression(this, tokens);
        }
    }

    public LogicExpression(Node parentNode, double lastNextLogicExpressionChance, ArrayList<Token> tokens) {
        super(parentNode, "Expression", true);
        tokens.remove(0);

        this.NEXT_LOGIC_BOOLEAN_EXPRESSION_CHANCE = lastNextLogicExpressionChance;

        switch (tokens.get(0).getNAME()) {
            case "ComparisonExpression" -> comparisonExpression = new ComparisonExpression(this, tokens);
            case "BooleanExpression" -> booleanExpression = new BooleanExpression(this, tokens);
        }
    }
}
