package Model.SmallNodes.Expressions.Standart;

import Utils.Config.BigGpConfig;
import Model.BaseNodes.Assignment.Assignment;
import Model.BaseNodes.ForStatement.ForAssignment;
import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Constants.Constant;
import Model.SmallNodes.Expressions.Logic.Childs.ComparisonExpression;
import Model.SmallNodes.Expressions.Standart.Childs.AdditiveExpression;
import Model.SmallNodes.Expressions.Standart.Childs.MultiplicativeExpression;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Serialization.Token;

import java.util.ArrayList;

public class Expression extends Node implements AddRandomExpression, Crossable, SubtreeMutable {

    private double NEXT_TWO_ARG_EXPRESSION_CHANCE;
    private Constant constant;
    private VarExpression variable;
    private MultiplicativeExpression multiplicativeExpression;
    private AdditiveExpression additiveExpression;


    public double getNEXT_TWO_ARG_EXPRESSION_CHANCE() {
        return NEXT_TWO_ARG_EXPRESSION_CHANCE;
    }

    @Override
    public String toString() {
        if (constant != null) {
            return constant.toString();
        } else if (variable != null) {
            return variable.toString();
        } else if (multiplicativeExpression != null) {
            return multiplicativeExpression.toString();
        } else if (additiveExpression != null) {
            return additiveExpression.toString();
        }
//        should never happen
        return "";
    }

    public void subtreeMutateTwoArgExpression() {
        this.multiplicativeExpression = null;
        this.additiveExpression = null;

        if (getRandomPercentages() < 50) {
            multiplicativeExpression = new MultiplicativeExpression(this);
        } else {
            additiveExpression = new AdditiveExpression(this);
        }
    }

    @Override
    public void subtreeMutate() {
        if (this.getParentNode() instanceof Assignment assignment) {
            assignment.setExpression(new Expression(assignment));

        } else if (this.getParentNode() instanceof ForAssignment forAssignment) {
            forAssignment.setExpression(new Expression(forAssignment));

        } else if (this.getParentNode() instanceof ComparisonExpression comparisonExpression) {
            comparisonExpression.setExpression(this, new Expression(comparisonExpression, NEXT_TWO_ARG_EXPRESSION_CHANCE));

        } else if (this.getParentNode() instanceof AdditiveExpression addExpr) {
            addExpr.setExpression(this, new Expression(addExpr, NEXT_TWO_ARG_EXPRESSION_CHANCE));

        } else if (this.getParentNode() instanceof MultiplicativeExpression mulExpr) {
            mulExpr.setExpression(this, new Expression(mulExpr, NEXT_TWO_ARG_EXPRESSION_CHANCE));
        }
    }

    public void setAdditiveExpression(AdditiveExpression additiveExpression) {
        this.multiplicativeExpression = null;
        this.additiveExpression = additiveExpression;
    }

    public void setMultiplicativeExpression(MultiplicativeExpression multiplicativeExpression) {
        this.additiveExpression = null;
        this.multiplicativeExpression = multiplicativeExpression;
    }

    public void mutateConstantOrVar() {
        Constant oldConstant = constant;
        VarExpression oldVariable = variable;

        while (true) {
            constant = null;
            variable = null;
            addConstOrVar();
            if (constant != null && oldConstant != null) {
                if (!oldConstant.getValue().equals(constant.getValue()) && variable == null) {
                    break;
                }
            } else if (variable != null && oldVariable != null) {
                if (!oldVariable.getValue().equals(variable.getValue()) && constant == null) {
                    break;
                }
            } else {
                break;
            }
        }
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        if (constant != null) {
            nodes.addAll(constant.getChildrenAsNodes());
        } else if (variable != null) {
            nodes.addAll(variable.getChildrenAsNodes());
        } else if (multiplicativeExpression != null) {
            nodes.addAll(multiplicativeExpression.getChildrenAsNodes());
        } else if (additiveExpression != null) {
            nodes.addAll(additiveExpression.getChildrenAsNodes());
        }

        return nodes;
    }

    @Override
    public void addRandomExpression() {
        ExpressionChild expressionChild = ExpressionChild.randomChild();
        switch (expressionChild) {
            case CONSTANT -> constant = new Constant(this);
            case VAR_EXPRESSION -> {
                try {
                    variable = new VarExpression(this, true);
                } catch (RuntimeException e) {
//                    happens when no var exists (almost never) and u want to use it.
//                    its fine just generate constant instead of variable.
                    constant = new Constant(this);
                }
            }
            case MUL_EXPRESSION -> {
                if (getRandomPercentages() < NEXT_TWO_ARG_EXPRESSION_CHANCE) {
                    multiplicativeExpression = new MultiplicativeExpression(this);
                } else {
                    addConstOrVar();
                }
            }
            case ADD_EXPRESSION -> {
                if (getRandomPercentages() < NEXT_TWO_ARG_EXPRESSION_CHANCE) {
                    additiveExpression = new AdditiveExpression(this);
                } else {
                    addConstOrVar();
                }
            }
        }
    }

    private void addConstOrVar() {
        if (getRandomPercentages() < 50) {
            constant = new Constant(this);
        } else {
            try {
                variable = new VarExpression(this, true);
            } catch (RuntimeException e) {
//                    happens when no var exists (almost never) and u want to use it.
//                    its fine just generate constant instead of variable.
                constant = new Constant(this);
            }
        }
    }

    public Expression(Node parentNode) {
        super(parentNode, "Expression", true);
        BigGpConfig config = BigGpConfig.readConfig();

        this.constant = null;
        this.variable = null;
        this.multiplicativeExpression = null;
        this.additiveExpression = null;

        this.NEXT_TWO_ARG_EXPRESSION_CHANCE = config.getNewTwoArgExpressionChance();

        addRandomExpression();
    }

    public Expression(Node parentNode, double lastNextTwoArgExpressionChance) {
        super(parentNode, "Expression", true);

        this.constant = null;
        this.variable = null;
        this.multiplicativeExpression = null;
        this.additiveExpression = null;

        this.NEXT_TWO_ARG_EXPRESSION_CHANCE = lastNextTwoArgExpressionChance;

        addRandomExpression();
    }

    public Expression(Node parent, ArrayList<Token> tokens) {
        super(parent, "Expression", true);

        BigGpConfig config = BigGpConfig.readConfig();

        this.NEXT_TWO_ARG_EXPRESSION_CHANCE = config.getNewTwoArgExpressionChance();

        tokens.remove(0);
        switch (tokens.get(0).getNAME()) {
            case "Constant" -> constant = new Constant(this, tokens);
            case "VarExpression" -> variable = new VarExpression(this, tokens);
            case "MultiplicativeExpression" -> multiplicativeExpression = new MultiplicativeExpression(this, tokens);
            case "AdditiveExpression" -> additiveExpression = new AdditiveExpression(this, tokens);
        }
    }

    public Expression(Node parent, double lastNextTwoArgExpressionChance, ArrayList<Token> tokens) {
        super(parent, "Expression", true);

        this.NEXT_TWO_ARG_EXPRESSION_CHANCE = lastNextTwoArgExpressionChance;

        tokens.remove(0);
        switch (tokens.get(0).getNAME()) {
            case "Constant" -> constant = new Constant(this, tokens);
            case "VarExpression" -> variable = new VarExpression(this, tokens);
            case "MultiplicativeExpression" -> multiplicativeExpression = new MultiplicativeExpression(this, tokens);
            case "AdditiveExpression" -> additiveExpression = new AdditiveExpression(this, tokens);
        }
    }
}
