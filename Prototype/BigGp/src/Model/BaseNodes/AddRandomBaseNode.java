package Model.BaseNodes;


import Model.BaseNodes.Assignment.Assignment;
import Model.BaseNodes.ForStatement.ForStatement;
import Model.BaseNodes.FunctionCallOut.FunctionCallOut;
import Model.BaseNodes.IfStatement.IfStatement;
import Model.Node;

import java.util.Random;

import static Model.Node.getRandomPercentages;

public interface AddRandomBaseNode {

    enum BaseNode {
        ASSIGNMENT,
        FUNCTION_CALL_OUT,
        IF_STATEMENT,
        FOR_STATEMENT;
//        SCOPE

        private static final BaseNode[] VALUES = BaseNode.class.getEnumConstants();
        private static final int SIZE = VALUES.length;
        private static final Random RANDOM = new Random();

        public static BaseNode randomNode() {
            return VALUES[(RANDOM.nextInt(SIZE))];
        }
    }

    public abstract void addRandomNode();

    public abstract void addRandomNodeInside();

    public abstract void addRandomNodes();

    public abstract int getRandomLineIdxFromSeq();

    public abstract void swapTwoLines();

    public abstract void deleteLine();

    public abstract double getNextChildChance();

    public abstract int getParentIndent();

    public abstract int getIndent();

    public abstract double getParentNextDeepNodeChance();

    public abstract double getNextDeepNodeChance();

    public abstract void setIndent(int toSet);

    public abstract void clearVariables();

    public default void reCalculateIndent() {
        this.setIndent(this.getParentIndent() + 1);
    }

    public default Node getRandomNode(Node parentNode, double nextDeepNodeChance) {
        BaseNode node = BaseNode.randomNode();
        switch (node) {
            case ASSIGNMENT -> {
                return new Assignment(parentNode);
            }
            case FUNCTION_CALL_OUT -> {
                if (getRandomPercentages() < 50) {
                    return new FunctionCallOut(parentNode);
                } else {
                    return new Assignment(parentNode);
                }
            }
            case IF_STATEMENT -> {
                if (getRandomPercentages() < nextDeepNodeChance) {
                    return new IfStatement(parentNode);
                } else {
                    return getRandomPercentages() < 50 ? new Assignment(parentNode) : new FunctionCallOut(parentNode);
                }
            }
            case FOR_STATEMENT -> {
                if (getRandomPercentages() < nextDeepNodeChance) {
                    return new ForStatement(parentNode);
                } else {
                    return getRandomPercentages() < 50 ? new Assignment(parentNode) : new FunctionCallOut(parentNode);
                }
            }
        }
//        should never happen!
        return null;
    }

    public default void reAttachSubtree(Node oldNode, Node newNode) {
        this.setChildNode(oldNode, newNode);
        if (newNode instanceof ForStatement forStatement) {
            forStatement.addRandomNode();
            forStatement.addRandomNodes();
        } else if (newNode instanceof IfStatement ifStatement) {
            ifStatement.addRandomNode();
            ifStatement.addRandomNodes();
        }
    }

    private void setChildNode(Node oldNode, Node newNode) {
        int nodeIdx = ((Node) this).getChildrenNodes().indexOf(oldNode);
        ((Node) this).getChildrenNodes().remove(oldNode);
        ((Node) this).getChildrenNodes().add(nodeIdx, newNode);
    }
}
