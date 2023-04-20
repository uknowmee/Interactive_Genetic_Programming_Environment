package Model.BaseNodes.Assignment;

import Model.BaseNodes.AddRandomBaseNode;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Model.SmallNodes.Expressions.Standart.Expression;
import Serialization.Token;

import java.util.ArrayList;
import java.util.Random;


public class Assignment extends Node implements SubtreeMutable {

    //    Currently hardcoded, that we can only get expression not read() during program generation
//    If we want to use read() we have to use one of 2 constructors
    enum AssignmentChild {
        EXPRESSION,
        FUNCTION_CALL_IN;
        private static final AssignmentChild[] VALUES = AssignmentChild.class.getEnumConstants();
        private static final int SIZE = VALUES.length;
        private static final Random RANDOM = new Random();

        public static AssignmentChild randomChild() {
            return VALUES[(RANDOM.nextInt(SIZE))];
        }
    }

    private VarExpression variable;
    private Expression expression;
    private FunctionCallIn read;

    @Override
    public String toString() {
        if (read == null) {
            return variable.getVariableName() + " = " + expression.toString() + ";";
        } else {
            return variable.getVariableName() + " = " + read.toString() + ";";
        }
    }

    public void setExpression(Expression expression) {
        this.expression = expression;
    }

    @Override
    public void subtreeMutate() {
        Node parentNode = this.getParentNode();
        double nextDeepNodeChance = ((AddRandomBaseNode) parentNode).getNextDeepNodeChance();
        Node node = ((AddRandomBaseNode) parentNode).getRandomNode(parentNode, nextDeepNodeChance);

        ((AddRandomBaseNode) parentNode).reAttachSubtree(this, node);
    }

    public FunctionCallIn getRead() {
        return read;
    }

    public VarExpression getVariable() {
        return variable;
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);
        nodes.addAll(variable.getChildrenAsNodes());

        if (read == null) {
            nodes.addAll(expression.getChildrenAsNodes());
        } else {
            nodes.addAll(read.getChildrenAsNodes());
        }

        return nodes;
    }

    public Assignment(Node parent) {
        super(parent, "Assignment", true);

//        Hardcoded for expression
        expression = new Expression(this);
        read = null;

        variable = new VarExpression(this);

//        AssignmentChild assignmentChild = AssignmentChild.randomChild();
//
//        switch (assignmentChild) {
//            case EXPRESSION -> {
//                value = new Expression(this);
//                read = null;
//            }
//            case FUNCTION_CALL_IN -> {
//                read = new FunctionCallIn(this);
//                value = null;
//            }
//        }
    }

    //    USE THIS ONLY DURING PROGRAM INPUT DECLARATION!!!!!!
    public Assignment(Node parent, boolean shouldVarAlreadyExist) {
        super(parent, "Assignment", true);

        try {
            variable = new VarExpression(this, shouldVarAlreadyExist);
        } catch (Exception e) {
            e.printStackTrace();
            System.out.println(
                    "[shouldVarAlreadyExist] value was" + shouldVarAlreadyExist +
                            "when u didnt have any variables existing." +
                            "This should never happen bcs this constructor" +
                            "was ment to be used only during program input declarations when" +
                            "[shouldVarAlreadyExist] value should always be false!!");
        }

        read = new FunctionCallIn(this);
        expression = null;
    }

    private void assignmentFromTokens(ArrayList<Token> tokens) {
        switch (tokens.get(0).getNAME()) {
            case "VarExpression" -> variable = new VarExpression(this, tokens);
            case "Expression" -> expression = new Expression(this, tokens);
            case "FunctionCallIn" -> read = new FunctionCallIn(this, tokens);
        }
    }

    public Assignment(Node parent, ArrayList<Token> tokens) {
        super(parent, "Assignment", true);
        tokens.remove(0);

        assignmentFromTokens(tokens);
        assignmentFromTokens(tokens);
    }
}
