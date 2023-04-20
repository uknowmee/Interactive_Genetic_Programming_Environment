package Model.SmallNodes.Operators;

import Model.Interfaces.PointMutable;
import Model.Interfaces.Terminal;
import Model.Node;
import Serialization.Token;

import java.util.ArrayList;
import java.util.Random;

public abstract class Operator extends Node implements PointMutable, Terminal {
    private String operator;
    private static final Random RANDOM = new Random();

    public void setOperator(String newOperator){
        operator = newOperator;
    }

    public int getRandomInt(int bound){
        return RANDOM.nextInt(bound);
    }

    @Override
    public String getValue(){
        return operator;
    }

    @Override
    public String toString() {
        return operator;
    }

    public ArrayList<Node> getChildrenAsNodes(){
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        return nodes;
    }

    public String getOperator() {
        return operator.replace(" ", "");
    }

    public Operator(Node parentNode, String name) {
        super(parentNode, name, true);
    }

    public Operator(Node parentNode, ArrayList<Token> tokens) {
        super(parentNode, tokens.get(0).getNAME(), true);
        Token token = tokens.remove(0);
        setOperator(token.getVALUE());
    }
}
