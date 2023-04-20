package Model.BaseNodes.Assignment;

import Model.Node;
import Model.Interfaces.Terminal;
import Serialization.Token;

import java.util.ArrayList;

public class FunctionCallIn extends Node implements Terminal {

    private final String value;

    public ArrayList<Node> getChildrenAsNodes(){
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        return nodes;
    }

    @Override
    public String toString() {
        return value;
    }

    @Override
    public String getValue() {
        return value;
    }

    public FunctionCallIn(Node parentNode) {
        super(parentNode, "FunctionCallIn", true);
        this.value = "read()";
    }

    public FunctionCallIn(Node parent, ArrayList<Token> tokens) {
        super(parent, "FunctionCallIn", true);

        this.value = tokens.remove(0).getVALUE();
    }
}
