package Model.BaseNodes.ForStatement;

import Utils.Config.BigGpConfig;
import Model.BaseNodes.AddRandomBaseNode;
import Model.BaseNodes.Assignment.Assignment;
import Model.BaseNodes.FunctionCallOut.FunctionCallOut;
import Model.BaseNodes.IfStatement.IfStatement;
import Model.EmptyNode;
import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Expressions.Logic.Childs.ComparisonExpression;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Serialization.Token;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Objects;
import java.util.Random;

public class ForStatement extends Node implements AddRandomBaseNode, Crossable, SubtreeMutable {

    private double NEXT_CHILD_CHANCE;
    private double NEXT_COMPARISON_EXPRESSION_CHANCE;
    private double NEXT_DEEP_NODE_CHANCE;
    private final ArrayList<VarExpression> variables;

    private int indent;

    private ForAssignment forAssignment;
    private ComparisonExpression comparisonExpression;
    private ForIncrement forIncrement;

    @Override
    public String toString() {
        StringBuilder forBody = new StringBuilder();

        forBody.append("for (")
                .append(forAssignment.toString())
                .append(", ")
                .append(comparisonExpression.toString())
                .append(", ")
                .append(forIncrement.toString())
                .append(") {\n");

        for (Node node : getChildrenNodes()) {
            forBody.append("\t".repeat(indent)).append(node.toString()).append("\n");
        }

        forBody.append("\t".repeat(indent - 1)).append("}");

        return forBody.toString();
    }

    @Override
    public void subtreeMutate() {
        Node parentNode = this.getParentNode();
        double nextDeepNodeChance = ((AddRandomBaseNode) parentNode).getNextDeepNodeChance();
        Node node = getRandomNode(parentNode, nextDeepNodeChance);

        ((AddRandomBaseNode) parentNode).reAttachSubtree(this, node);
    }

    @Override
    public ArrayList<VarExpression> getProgramVariables() {
        ArrayList<VarExpression> variables = (ArrayList<VarExpression>) getParentNode().getProgramVariables().clone();

        variables.addAll(this.variables);

        return variables;
    }

    @Override
    public int getRandomLineIdxFromSeq() {
        if (getChildrenNodes().size() == 0) {
            return 0;
        }

        return new Random().nextInt(getChildrenNodes().size());
    }

    @Override
    public double getNextChildChance() {
        return NEXT_CHILD_CHANCE;
    }

    @Override
    public int getParentIndent() {
        AddRandomBaseNode parentNode = (AddRandomBaseNode) getParentNode();
        return parentNode.getIndent();
    }

    @Override
    public int getIndent() {
        return indent;
    }

    @Override
    public double getParentNextDeepNodeChance() {
        AddRandomBaseNode parentNode = (AddRandomBaseNode) getParentNode();
        return parentNode.getNextDeepNodeChance();
    }

    @Override
    public double getNextDeepNodeChance() {
        return NEXT_DEEP_NODE_CHANCE;
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);
        nodes.addAll(forAssignment.getChildrenAsNodes());
        nodes.addAll(comparisonExpression.getChildrenAsNodes());
        nodes.addAll(forIncrement.getChildrenAsNodes());

        for (Node node : getChildrenNodes()) {
            nodes.addAll(node.getChildrenAsNodes());
        }

        return nodes;
    }

    public double getNEXT_COMPARISON_EXPRESSION_CHANCE() {
        return NEXT_COMPARISON_EXPRESSION_CHANCE;
    }

    public ArrayList<Node> getChildrenAsNodesWithEmpty() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);
        nodes.addAll(forAssignment.getChildrenAsNodes());
        nodes.addAll(comparisonExpression.getChildrenAsNodes());
        nodes.addAll(forIncrement.getChildrenAsNodes());

        nodes.add(new EmptyNode("Start ForStatement"));
        for (Node node : getChildrenNodes()) {
            nodes.addAll(node.getChildrenAsNodesWithEmpty());
        }
        nodes.add(new EmptyNode("End ForStatement"));

        return nodes;
    }

    @Override
    public void setIndent(int toSet) {
        indent = toSet;
    }

    public void setForIncrement(ForIncrement forIncrement) {
        this.forIncrement = forIncrement;
    }

    public void setComparisonExpression(ComparisonExpression comparisonExpression) {
        this.comparisonExpression = comparisonExpression;
    }

    //    Duplicated code with IfStatement
    @Override
    public void addRandomNode() {
        BaseNode node = BaseNode.randomNode();
        switch (node) {
            case ASSIGNMENT -> {
                addNode(new Assignment(this));
            }
            case FUNCTION_CALL_OUT -> {
                if (getRandomPercentages() < 50) {
                    addNode(new FunctionCallOut(this));
                } else {
                    addNode(new Assignment(this));
                }
            }
            case IF_STATEMENT -> {
                if (getRandomPercentages() < NEXT_DEEP_NODE_CHANCE) {
                    IfStatement ifStatement = new IfStatement(this);
                    addNode(ifStatement);
                    ifStatement.addRandomNode();
                    ifStatement.addRandomNodes();
                } else {
                    addAssOrCallOUT();
                }
            }
            case FOR_STATEMENT -> {
                if (getRandomPercentages() < NEXT_DEEP_NODE_CHANCE) {
                    ForStatement forStatement = new ForStatement(this);
                    addNode(forStatement);
                    forStatement.addRandomNode();
                    forStatement.addRandomNodes();
                } else {
                    addAssOrCallOUT();
                }
            }
//            case SCOPE -> {
//                addChildren(new Scope(this));
//                return;
//            }
        }
    }

    @Override
    public void addRandomNodes() {
        while (getRandomPercentages() < getNextChildChance()) {
            addRandomNode();
        }
    }

    @Override
    public void addRandomNodeInside() {
        BaseNode node = BaseNode.randomNode();
        int idx = getRandomLineIdxFromSeq();

        switch (node) {
            case ASSIGNMENT -> {
                getChildrenNodes().add(idx, new Assignment(this));
            }
            case FUNCTION_CALL_OUT -> {
                if (getRandomPercentages() < 50) {
                    getChildrenNodes().add(idx, new FunctionCallOut(this));
                } else {
                    getChildrenNodes().add(idx, new Assignment(this));
                }
            }
            case IF_STATEMENT -> {
                if (getRandomPercentages() < NEXT_DEEP_NODE_CHANCE) {
                    IfStatement ifStatement = new IfStatement(this);
                    getChildrenNodes().add(idx, ifStatement);
                    ifStatement.addRandomNode();
                    ifStatement.addRandomNodes();
                } else {
                    addAssOrCallOUTInside(idx);
                }
            }
            case FOR_STATEMENT -> {
                if (getRandomPercentages() < NEXT_DEEP_NODE_CHANCE) {
                    ForStatement forStatement = new ForStatement(this);
                    getChildrenNodes().add(idx, forStatement);
                    forStatement.addRandomNode();
                    forStatement.addRandomNodes();
                } else {
                    addAssOrCallOUTInside(idx);
                }
            }
//            case SCOPE -> {
//                addChildren(new Scope(this));
//                return;
//            }
        }
    }

    @Override
    public void addToProgramVariables(VarExpression variable) {
        ArrayList<VarExpression> parentVariables = getParentNode().getProgramVariables();

        for (VarExpression var : variables) {
            if (Objects.equals(var.getVariableName(), variable.getVariableName())) {
                return;
            }
        }

        for (VarExpression var : parentVariables) {
            if (Objects.equals(var.getVariableName(), variable.getVariableName())) {
                return;
            }
        }

        variables.add(variable);
    }

    @Override
    public void swapTwoLines() {
        int node1Idx = getRandomLineIdxFromSeq();
        int node2Idx = getRandomLineIdxFromSeq();

        while (node1Idx == node2Idx) {
            node2Idx = getRandomLineIdxFromSeq();
        }

        Collections.swap(getChildrenNodes(), node1Idx, node2Idx);
    }

    @Override
    public void deleteLine() {
        getChildrenNodes().remove(getRandomLineIdxFromSeq());
    }

    private void addAssOrCallOUT() {
        if (getRandomPercentages() < 50) {
            addNode(new Assignment(this));
        } else {
            addNode(new FunctionCallOut(this));
        }
    }

    private void addAssOrCallOUTInside(int idx) {
        if (getRandomPercentages() < 50) {
            getChildrenNodes().add(idx, new Assignment(this));
        } else {
            getChildrenNodes().add(idx, new FunctionCallOut(this));
        }
    }

    public void clearVariables() {
        variables.clear();
    }

    public ForStatement(Node parent) {
        super(parent, "ForStatement", false);
        BigGpConfig config = BigGpConfig.readConfig();

        NEXT_CHILD_CHANCE = config.getNewChildOfForNodeChance();
        NEXT_DEEP_NODE_CHANCE = getParentNextDeepNodeChance() * (1 - config.getNewDeepNodeGenerationFall() / 100);
        NEXT_COMPARISON_EXPRESSION_CHANCE = config.getNewExpressionInForComparisonChance();

        indent = getParentIndent() + 1;

        variables = new ArrayList<>();

        forAssignment = new ForAssignment(this);
        comparisonExpression = new ComparisonExpression(this, NEXT_COMPARISON_EXPRESSION_CHANCE);
        forIncrement = new ForIncrement(this);
    }

    public void addNodes(ArrayList<Token> tokens) {
        Token token;
        while (tokens.size() > 0) {
            token = tokens.get(0);

            switch (token.getNAME()) {
                case "Assignment" -> addNode(new Assignment(this, tokens));
                case "FunctionCallOut" -> addNode(new FunctionCallOut(this, tokens));
                case "IfStatement" -> {
                    IfStatement ifStatement = new IfStatement(this, tokens);
                    addNode(ifStatement);
                    ifStatement.addNodes(tokens);
                }
                case "ForStatement" -> {
                    ForStatement forStatement = new ForStatement(this, tokens);
                    addNode(forStatement);
                    forStatement.addNodes(tokens);
                }
                case "End ForStatement" -> {
                    tokens.remove(0);
                    return;
                }
            }
        }
    }

    public ForStatement(Node parent, ArrayList<Token> tokens) {
        super(parent, "ForStatement", false);
        tokens.remove(0);

        BigGpConfig config = BigGpConfig.readConfig();

        NEXT_CHILD_CHANCE = config.getNewChildOfForNodeChance();
        NEXT_DEEP_NODE_CHANCE = getParentNextDeepNodeChance() * (1 - config.getNewDeepNodeGenerationFall() / 100);
        NEXT_COMPARISON_EXPRESSION_CHANCE = config.getNewExpressionInForComparisonChance();

        indent = getParentIndent() + 1;

        variables = new ArrayList<>();

        forAssignment = new ForAssignment(this, tokens);
        comparisonExpression = new ComparisonExpression(this, NEXT_COMPARISON_EXPRESSION_CHANCE, tokens);
        forIncrement = new ForIncrement(this, tokens);
        tokens.remove(0);
    }
}
