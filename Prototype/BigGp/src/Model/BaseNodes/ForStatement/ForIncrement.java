package Model.BaseNodes.ForStatement;

import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Constants.AddRandomConstant;
import Model.SmallNodes.Constants.Constant;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Model.SmallNodes.Operators.Arithmetic.AdditiveOperator;
import Serialization.Token;

import java.util.ArrayList;
import java.util.Random;

public class ForIncrement extends Node implements Crossable, SubtreeMutable {

    private AdditiveOperator additiveOperator;
    private VarExpression variable;
    private Constant constInt;

    @Override
    public String toString() {

        if (variable != null) {
            return additiveOperator.getOperator() + variable.toString();
        } else {
            return additiveOperator.getOperator() + constInt.toString();
        }
    }

    public ArrayList<Node> getChildrenAsNodes() {
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);
        nodes.addAll(additiveOperator.getChildrenAsNodes());

        if (variable != null) {
            nodes.addAll(variable.getChildrenAsNodes());
        } else {
            nodes.addAll(constInt.getChildrenAsNodes());
        }

        return nodes;
    }

    @Override
    public void subtreeMutate() {
        if (this.getParentNode() instanceof ForStatement forStatement){
            forStatement.setForIncrement(new ForIncrement(forStatement));
        }
    }

    public ForIncrement(Node parentNode) {
        super(parentNode, "ForIncrement", true);

        variable = null;
        constInt = null;

        if (new Random().nextInt(2) == 0) {
            variable = new VarExpression(this, true);
        } else {
            constInt = new Constant(this, AddRandomConstant.RandomConstant.INT);
        }
        additiveOperator = new AdditiveOperator(this);
    }

    private void forIncrementFromTokens(ArrayList<Token> tokens) {
        switch (tokens.get(0).getNAME()) {
            case "VarExpression" -> variable = new VarExpression(this, tokens);
            case "AdditiveOperator" -> additiveOperator = new AdditiveOperator(this, tokens);
            case "Constant" -> constInt = new Constant(this, AddRandomConstant.RandomConstant.INT, tokens);
        }
    }

    public ForIncrement(Node parent, ArrayList<Token> tokens) {
        super(parent, "ForIncrement", true);
        tokens.remove(0);

        forIncrementFromTokens(tokens);
        forIncrementFromTokens(tokens);
    }
}
