package Model;

import java.util.ArrayList;

public class EmptyNode extends Node{

    @Override
    public String toString(){
        return getNAME();
    }
    public EmptyNode(String name) {
        super(null, name, false);
    }

    @Override
    public ArrayList<Node> getChildrenAsNodes() {
        return null;
    }
}
