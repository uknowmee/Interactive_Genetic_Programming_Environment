package Evolutions;

import Model.BaseNodes.Assignment.Assignment;
import Model.BaseNodes.ForStatement.ForStatement;
import Model.BaseNodes.FunctionCallOut.FunctionCallOut;
import Model.BaseNodes.IfStatement.IfStatement;
import Model.Interfaces.Crossable;
import Model.Node;
import Model.Program;
import Model.SmallNodes.Expressions.Standart.Childs.AdditiveExpression;
import Model.SmallNodes.Expressions.Standart.Childs.MultiplicativeExpression;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Serialization.Serializer;
import Serialization.Tokenizer;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Crosser {

    private int DEPTH;
    private ArrayList<Node> program1NodesWithEmpty;
    private ArrayList<Node> program2NodesWithEmpty;
    private static final Random RANDOM = new Random();


    public Program cross(Program program1, Program program2, int depth) throws Exception {
        DEPTH = depth;
        program1NodesWithEmpty = program1.getChildrenAsNodesWithEmpty();
        program2NodesWithEmpty = program2.getChildrenAsNodesWithEmpty();

        Program program = evalCross(0);

        DEPTH = 0;
        program1NodesWithEmpty = null;
        program2NodesWithEmpty = null;

        return program;
    }

    private Node getFirstCrossableNode() throws Exception {
        int size1 = program1NodesWithEmpty.size();

        Node node1 = program1NodesWithEmpty.get(RANDOM.nextInt(size1));

        int i = 0;
        while (!(node1 instanceof Crossable ||
                (node1 instanceof Assignment assignment && assignment.getRead() == null))) {
            if (i == program1NodesWithEmpty.size()) {
                throw new Exception("Couldn't cross!");
            }
            node1 = program1NodesWithEmpty.get(RANDOM.nextInt(size1));
            i += 1;
        }

        return node1;
    }

    private Node getSecondCompatibleNode(Node node1, int depth) throws Exception {
        ArrayList<Node> compWithOne = new ArrayList<>(program2NodesWithEmpty);
        String type = node1.getClass().getTypeName();

        if ((node1 instanceof Assignment assignment && assignment.getRead() == null) ||
                node1 instanceof ForStatement ||
                node1 instanceof FunctionCallOut ||
                node1 instanceof IfStatement) {

            compWithOne.removeIf(node -> !
                    (node.getClass().getTypeName().equals(type) ||
                            node instanceof ForStatement ||
                            node instanceof FunctionCallOut ||
                            node instanceof IfStatement));

            compWithOne.removeIf(imNode -> imNode instanceof Assignment as && as.getRead() != null);

        } else if (node1 instanceof AdditiveExpression || node1 instanceof MultiplicativeExpression) {
            compWithOne.removeIf(node -> !(node instanceof AdditiveExpression || node instanceof MultiplicativeExpression));
        } else {
            compWithOne.removeIf(node -> !(node.getClass().getTypeName().equals(type)));
        }

        if (compWithOne.size() == 0) {
            return null;
        }

        return compWithOne.get(RANDOM.nextInt(compWithOne.size()));
    }

    private Program evalCross(int depth) throws Exception {
        if (depth >= DEPTH) {
            throw new Exception("Couldn't cross!");
        }

        Node node1 = getFirstCrossableNode();
        Node node2 = getSecondCompatibleNode(node1, depth);

        if (node2 == null) {
            return evalCross(depth + 1);
        }

        Program program = swap(node1, node2);

        if (program == null) {
            return evalCross(depth + 1);
        } else {
//                System.out.println(depth);
            return program;
        }
    }

    private int getNodeIdx(Node node, ArrayList<Node> nodes) {
        for (int i = 0; i < nodes.size(); i++) {
            if (nodes.get(i).hashCode() == node.hashCode()) {
                return i;
            }
        }
//       should never happen!!
        return 0;
    }

    private boolean variablesCheck(Node node1, ArrayList<Node> sub2) {
        ArrayList<VarExpression> variables = node1.getProgramVariables();
        List<String> varIndexes = variables
                .stream()
                .map(var -> var.getVariableName().split("_")[1])
                .toList();

        for (Node node : sub2) {
            if (node instanceof VarExpression variable) {
                if (!(varIndexes.contains(variable.getValue().split("_")[1]))) {
                    return false;
                }
            }
        }

        return true;
    }

    private Program swap(Node node1, Node node2) {
        ArrayList<Node> sub1 = node1.getChildrenAsNodesWithEmpty();
        ArrayList<Node> sub2 = node2.getChildrenAsNodesWithEmpty();

        if (!variablesCheck(node1, sub2)) {
            return null;
        }

        int idxStart1 = getNodeIdx(node1, program1NodesWithEmpty);

        for (int i = 0; i < sub1.size(); i++) {
            program1NodesWithEmpty.remove(idxStart1);
        }
        program1NodesWithEmpty.addAll(idxStart1, sub2);

        return Program.programFromTokens(Tokenizer.makeTokensFromListOfNodesWithEmpty(program1NodesWithEmpty));
    }

    public Crosser() {

        DEPTH = 0;

        program1NodesWithEmpty = null;
        program2NodesWithEmpty = null;
    }

    public static void main(String[] args) {
        Serializer serializer = new Serializer("02-11-2022_06-10-06");

        Program program1 = Serializer.readProgramFileFromConfig();
        Program program2 = serializer.readProgram();

        Crosser crosser = new Crosser();

        try {
            Program program3 = crosser.cross(program1, program2, 30);
            System.out.println(program3.getProgramString());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
