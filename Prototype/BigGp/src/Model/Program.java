package Model;

import Utils.Config.BigGpConfig;
import Model.BaseNodes.AddRandomBaseNode;
import Model.BaseNodes.Assignment.Assignment;
import Model.BaseNodes.ForStatement.ForStatement;
import Model.BaseNodes.FunctionCallOut.FunctionCallOut;
import Model.BaseNodes.IfStatement.IfStatement;
import Model.Interfaces.PointMutable;
import Model.Interfaces.SubtreeMutable;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Serialization.Token;
import Serialization.Tokenizer;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Objects;
import java.util.Random;

public class Program extends Node implements AddRandomBaseNode {
    private double NEXT_CHILD_CHANCE;
    private double NEXT_DEEP_NODE_CHANCE;
    private int INPUTS;
    private static final int INDENT = 0;
    private final ArrayList<VarExpression> variables;

    private ArrayList<Token> tokens;

    public int getINPUTS() {
        return INPUTS;
    }

    public String getProgramString() {
        StringBuilder program = new StringBuilder();
        ArrayList<Node> nodes = getChildrenNodes();

        for (Node node : nodes) {
            if (node instanceof AddRandomBaseNode){
                ((AddRandomBaseNode) node).reCalculateIndent();
            }
        }

        for (Node node : nodes) {
            program.append(node.toString());
            if (!(node.hashCode() == nodes.get(nodes.size() - 1).hashCode())){
                program.append("\n");
            }
        }

        return program.toString();
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();

        for (Node node : getChildrenNodes()) {
            nodes.addAll(node.getChildrenAsNodes());
        }

        return nodes;
    }

    public void clearVariables() {
        variables.clear();
    }

    public void updateVariables() {
        ArrayList<Node> nodes = getChildrenAsNodes();

        clearVariables();
        for (Node node : nodes){
            if (node instanceof AddRandomBaseNode addRandomBaseNode) {
                addRandomBaseNode.clearVariables();
            }
        }

        for (Node node : nodes) {
            if (node instanceof VarExpression varExpression) {
                varExpression.addToProgramVariables(varExpression);
            }
        }
    }

    public ArrayList<Node> getChildrenAsNodesWithEmpty() {
        ArrayList<Node> nodes = new ArrayList<>();

        for (Node node : getChildrenNodes()) {
            nodes.addAll(node.getChildrenAsNodesWithEmpty());
        }

        return nodes;
    }

    public ArrayList<Node> getPointMutableOnes() {
        ArrayList<Node> nodes = getChildrenAsNodes();

        nodes.removeIf(node -> !(node instanceof PointMutable));
        nodes.removeIf(node -> !((PointMutable) node).isMutable());

        return nodes;
    }

    public ArrayList<Node> getSubtreeMutableOnes() {
        ArrayList<Node> nodes = getChildrenAsNodes();

        nodes.removeIf(node -> !(node instanceof SubtreeMutable));
        nodes.removeIf(node -> !((SubtreeMutable) node).isMutable());

        return nodes;
    }

    public int getProgramLength(){
        return getProgramString().split("\r\n|\r|\n").length;
    }

    @Override
    public ArrayList<VarExpression> getProgramVariables() {
        return variables;
    }

    @Override
    public void addToProgramVariables(VarExpression variable) {
        for (VarExpression var : variables) {
            if (Objects.equals(var.getVariableName(), variable.getVariableName())) {
                return;
            }
        }

        variables.add(variable);
    }

    @Override
    public double getNextChildChance() {
        return NEXT_CHILD_CHANCE;
    }

    @Override
    public void addRandomNode() {
        int probCounter = 0;

        while (true) {
            BaseNode node = BaseNode.randomNode();
            switch (node) {
                case ASSIGNMENT -> {
                    addNode(new Assignment(this));
                    return;
                }
                case FUNCTION_CALL_OUT -> {
                    probCounter += 1;
                    if (probCounter > 1) {
                        addNode(new FunctionCallOut(this));
                        return;
                    }
                }
                case IF_STATEMENT -> {
                    IfStatement ifStatement = new IfStatement(this);
                    addNode(ifStatement);
                    ifStatement.addRandomNode();
                    ifStatement.addRandomNodes();
                    return;
                }
                case FOR_STATEMENT -> {
                    ForStatement forStatement = new ForStatement(this);
                    addNode(forStatement);
                    forStatement.addRandomNode();
                    forStatement.addRandomNodes();
                    return;
                }
//              case SCOPE -> {
//                  addChildren(new Scope(this));
//                    return;
//              }
            }
        }
    }

    @Override
    public void addRandomNodes() {
        while (getRandomPercentages() < getNextChildChance()) {
            addRandomNode();
        }
    }

    @Override
    public int getRandomLineIdxFromSeq(){

        if (getChildrenNodes().size() == INPUTS) {
            return INPUTS;
        }

        return new Random().nextInt(INPUTS, getChildrenNodes().size());
    }

    @Override
    public void addRandomNodeInside(){
        int probCounter = 0;
        int idx = getRandomLineIdxFromSeq();

        while (true) {
            BaseNode node = BaseNode.randomNode();
            switch (node) {
                case ASSIGNMENT -> {
                    getChildrenNodes().add(idx, new Assignment(this));
                    return;
                }
                case FUNCTION_CALL_OUT -> {
                    probCounter += 1;
                    if (probCounter > 1) {
                        getChildrenNodes().add(idx, new FunctionCallOut(this));
                        return;
                    }
                }
                case IF_STATEMENT -> {
                    IfStatement ifStatement = new IfStatement(this);
                    getChildrenNodes().add(idx, ifStatement);
                    ifStatement.addRandomNode();
                    ifStatement.addRandomNodes();
                    return;
                }
                case FOR_STATEMENT -> {
                    ForStatement forStatement = new ForStatement(this);
                    getChildrenNodes().add(idx, forStatement);
                    forStatement.addRandomNode();
                    forStatement.addRandomNodes();
                    return;
                }
//              case SCOPE -> {
//                  addChildren(new Scope(this));
//                    return;
//              }
            }
        }
    }

    @Override
    public void swapTwoLines(){
        int node1Idx = getRandomLineIdxFromSeq();
        int node2Idx = getRandomLineIdxFromSeq();

        while (node1Idx == node2Idx){
            node2Idx = getRandomLineIdxFromSeq();
        }

        Collections.swap(getChildrenNodes(), node1Idx, node2Idx);
    }

    @Override
    public void deleteLine() {
        getChildrenNodes().remove(getRandomLineIdxFromSeq());
    }

    @Override
    public int getParentIndent() {
        return INDENT;
    }

    @Override
    public int getIndent() {
        return INDENT;
    }

    @Override
    public double getParentNextDeepNodeChance() {
        return NEXT_DEEP_NODE_CHANCE;
    }

    @Override
    public double getNextDeepNodeChance() {
        return NEXT_DEEP_NODE_CHANCE;
    }

    @Override
    public void setIndent(int toSet) {
        return;
    }

    public static Program programFromTokens(ArrayList<Token> tokens){
        return new Program(tokens);
    }

    public Program programCopy(){
        return new Program(Tokenizer.makeTokensFromListOfNodesWithEmpty(this.getChildrenAsNodesWithEmpty()));
    }

    //    Program constructor which creates certain number of "var = read()" ie. (inputs)
    public Program(int inputs) {
        super(null, "Program", false);
        BigGpConfig config = BigGpConfig.readConfig();

        NEXT_CHILD_CHANCE = config.getNewChildOfProgramNodeChance();
        NEXT_DEEP_NODE_CHANCE = config.getNewDeepNodeGenerationChance();
        INPUTS = inputs;

        variables = new ArrayList<>();

        for (int i = 0; i < INPUTS; i++) {
            addNode(new Assignment(this, false));
        }
        addRandomNode();
    }

    private Program(ArrayList<Token> tokens) {
        super(null, "Program", false);
        BigGpConfig config = BigGpConfig.readConfig();

        NEXT_CHILD_CHANCE = config.getNewChildOfProgramNodeChance();
        NEXT_DEEP_NODE_CHANCE = config.getNewDeepNodeGenerationChance();

        variables = new ArrayList<>();
        this.tokens = tokens;

        Token token;

        while (this.tokens.size() > 0){
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
            }
        }

        for (Node node : getChildrenNodes()) {
            if (node instanceof Assignment assignment){
                if (assignment.getRead() == null){
                    break;
                }
            } else {
                break;
            }
            INPUTS += 1;
        }
    }
}
