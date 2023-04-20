package Model;

import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;

import java.util.ArrayList;
import java.util.Objects;
import java.util.Random;

public abstract class Node {
    private Node parentNode;
    private final ArrayList<Node> childrenNodes;
    private final String NAME;
    private static final Random RANDOM = new Random();


    public static double getRandomPercentages()  {
        return RANDOM.nextDouble() * 100;
    }

    public Node getParentNode() {
        return parentNode;
    }

    public ArrayList<Node> getChildrenNodes() {
        return childrenNodes;
    }

    public String getNAME() {
        return NAME;
    }

    public ArrayList<VarExpression> getProgramVariables() {
        return parentNode.getProgramVariables();
    }

    public abstract ArrayList<Node> getChildrenAsNodes();

    public ArrayList<Node> getChildrenAsNodesWithEmpty(){
        return getChildrenAsNodes();
    }

    public boolean isLast() {
        return childrenNodes == null;
    }

    protected Node addNode(Node child) {
        if (!isLast()) {
            Objects.requireNonNull(childrenNodes).add(child);
        } else {
            System.out.println("Tried to add child to last node!");
            System.exit(0);
        }

        return child;
    }

    public void addToProgramVariables(VarExpression variable) {
        parentNode.addToProgramVariables(variable);
    }

    public void deleteParent() {
        parentNode = null;
    }

    //    Is last tells if certain node can have any children (horizontal tree grow)
    public Node(Node parentNode, String name, boolean isLast) {
        this.parentNode = parentNode;
        NAME = name;
        if (isLast) {
            childrenNodes = null;
        } else {
            childrenNodes = new ArrayList<>();
        }
    }
}
