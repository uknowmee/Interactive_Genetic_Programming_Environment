package Model.SmallNodes.Constants;

import Utils.Config.BigGpConfig;
import Model.BaseNodes.ForStatement.ForIncrement;
import Model.Interfaces.PointMutable;
import Model.Interfaces.Terminal;
import Model.Node;
import Model.SmallNodes.Expressions.Standart.Expression;
import Serialization.Token;

import java.util.ArrayList;
import java.util.Random;

public class Constant extends Node implements AddRandomConstant, PointMutable, Terminal {

    private static int MAX_INT;
    private static int MAX_STRING_LEN;
    private static final Random RANDOM = new Random();
    private String type;
    private String value;

    private String randomInteger(){
        return String.valueOf(RANDOM.nextInt(MAX_INT));
    }

    private String randomString(){
        return "XD I dont want to waste time for this :))";
    }

    private String randomBool(){
        if (RANDOM.nextInt(2) == 0){
            return "false";
        }

        return "true";
    }

    @Override
    public String getValue() {
        return type + " " + value;
    }

    @Override
    public void mutate() {

        if (this.getParentNode() instanceof ForIncrement){
            String oldValue = value;
            value = randomInteger();

            while (oldValue.equals(value)) {
                value = randomInteger();
            }
        } else if (this.getParentNode() instanceof Expression expression){
            expression.mutateConstantOrVar();
        }
    }

    public void addRandomConstant(RandomConstant givenConst) {
        switch (givenConst) {
            case INT -> {
                type = RandomConstant.INT.name();
                value = randomInteger();
            }
//            case STR -> {
//                type = RandomConstant.STR.name();
//                value = randomString();
//            }
//            case BOOL -> {
//                type = RandomConstant.BOOL.name();
//                value = randomBool();
//            }
//            case NULL -> {
//                type = RandomConstant.NULL.name();
//                value = null;
//            }
        }
    }

    @Override
    public String toString() {
        return value;
    }

    public ArrayList<Node> getChildrenAsNodes(){
        ArrayList<Node> nodes = new ArrayList<>();
        nodes.add(this);

        return nodes;
    }

    public Constant(Node parentNode) {
        super(parentNode, "Constant", true);

        BigGpConfig config = BigGpConfig.readConfig();
        MAX_INT = config.getMaxInt();
        MAX_STRING_LEN = config.getMaxStringLen();

        RandomConstant randomConstant = RandomConstant.randomChild();
        addRandomConstant(randomConstant);
    }

    public Constant(Node parentNode, RandomConstant givenConst) {
        super(parentNode, "Constant", true);

        BigGpConfig config = BigGpConfig.readConfig();
        MAX_INT = config.getMaxInt();
        MAX_STRING_LEN = config.getMaxStringLen();

        addRandomConstant(givenConst);
    }

    public Constant(Node parent, ArrayList<Token> tokens) {
        super(parent, "Constant", true);

        BigGpConfig config = BigGpConfig.readConfig();
        MAX_INT = config.getMaxInt();
        MAX_STRING_LEN = config.getMaxStringLen();

        Token token = tokens.remove(0);
        String[] data = token.getVALUE().split(" ");

        type = data[0];
        value = data[1];
    }

    public Constant(Node parentNode, RandomConstant givenConst, ArrayList<Token> tokens) {
        super(parentNode, "Constant", true);

        BigGpConfig config = BigGpConfig.readConfig();
        MAX_INT = config.getMaxInt();
        MAX_STRING_LEN = config.getMaxStringLen();

        Token token = tokens.remove(0);
        String[] data = token.getVALUE().split(" ");

        type = data[0];
        value = data[1];
    }
}
