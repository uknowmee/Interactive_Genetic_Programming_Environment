package Model.BaseNodes.FunctionCallOut;

import Model.BaseNodes.AddRandomBaseNode;
import Model.Interfaces.Crossable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.SmallNodes.Expressions.Standart.Childs.VarExpression;
import Serialization.Token;

import java.util.ArrayList;

public class FunctionCallOut extends Node implements Crossable, SubtreeMutable {

    private VarExpression variable;

    @Override
    public String toString() {
        return "write(" + variable.getVariableName() + ");";
    }

    public ArrayList<Node> getChildrenAsNodes(){
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);
        nodes.add(variable);

        return nodes;
    }

    @Override
    public void subtreeMutate() {
        Node parentNode = this.getParentNode();
        double nextDeepNodeChance = ((AddRandomBaseNode) parentNode).getNextDeepNodeChance();
        Node node = ((AddRandomBaseNode) parentNode).getRandomNode(parentNode, nextDeepNodeChance);

        ((AddRandomBaseNode) parentNode).reAttachSubtree(this, node);
    }

    public FunctionCallOut(Node parent) {
        super(parent, "FunctionCallOut", true);

        variable = new VarExpression(this, true);
    }

    public FunctionCallOut(Node parent, ArrayList<Token> tokens) {
        super(parent, "FunctionCallOut", true);

        tokens.remove(0);
        variable = new VarExpression(this, tokens);
    }
}
