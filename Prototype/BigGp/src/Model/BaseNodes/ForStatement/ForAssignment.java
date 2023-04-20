package Model.BaseNodes.ForStatement;

import Model.Node;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Model.SmallNodes.Expressions.Standart.Expression;
import Serialization.Token;

import java.util.ArrayList;

public class ForAssignment extends Node {

    private VarExpression variable;
    private Expression expression;

    public VarExpression getVariable() {
        return variable;
    }

    @Override
    public String toString() {
        return variable.toString() + " = " + expression.toString();
    }

    public void setExpression(Expression expression) {
        this.expression = expression;
    }

    public ArrayList<Node> getChildrenAsNodes(){
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);
        nodes.addAll(variable.getChildrenAsNodes());
        nodes.addAll(expression.getChildrenAsNodes());

        return nodes;
    }

    public ForAssignment(Node parentNode) {
        super(parentNode, "ForAssignment", true);
        this.expression = new Expression(this);
        this.variable = new VarExpression(this);
    }

    public ForAssignment(Node parent, ArrayList<Token> tokens) {
        super(parent, "ForAssignment", true);
        tokens.remove(0);

        this.variable = new VarExpression(this, tokens);
        this.expression = new Expression(this, tokens);
    }
}
