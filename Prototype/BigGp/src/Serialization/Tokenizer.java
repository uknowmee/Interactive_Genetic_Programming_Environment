package Serialization;

import Model.Interfaces.Terminal;
import Model.Node;

import java.util.ArrayList;

public class Tokenizer {
    public static ArrayList<Token> makeTokensFromListOfNodesWithEmpty(ArrayList<Node> nodes){
        ArrayList<Token> tokens = new ArrayList<>();

        for (Node node : nodes) {
            if (node instanceof Terminal terminal){
                tokens.add(new Token(terminal.getType(), terminal.getValue()));
            } else {
                tokens.add(new Token(node.getNAME(), null));
            }
        }

        return tokens;
    }
}
