package Generating;

import java.util.*;

public class Function {

    public enum Type {
        AND,
        OR,
        NOT,
        TRUE;
    }

    public static class RetVal {
        public String stringValue;
        public int intValue;

        public RetVal(String stringValue, int intValue) {
            this.stringValue = stringValue;
            this.intValue = intValue;
        }
    }

    private Function parent;
    private Function leftChild;
    private Function rightChild;
    private Type type;
    private List<Type> leftTypes;

    public static List<List<Integer>> getCases(int numOfVars) {

        List<List<Integer>> result = new ArrayList<>();
        int bound;

        if (numOfVars == 1) {
            bound = (int) (Math.pow(numOfVars, 2) + 1);
        } else if (numOfVars % 2 == 0) {
            bound = (int) (Math.pow(numOfVars, 2));
        } else {
            bound = (int) (Math.pow(numOfVars, 2) - 1);
        }

        for (int i = 0; i < bound; i++) {
            List<String> values = Arrays.stream(Integer.toBinaryString(i).split("")).toList();
            List<Integer> singleCase = new ArrayList<>();

            while (singleCase.size() + values.size() < numOfVars) {
                singleCase.add(0);
            }

            values.forEach(val -> singleCase.add(Integer.parseInt(val)));

            result.add(singleCase);
        }

        return result;
    }

    public boolean eval(ArrayList<Integer> evalCase){
        switch (type){
            case TRUE -> {
                return evalCase.remove(0) == 1;
            }
            case NOT -> {
                return evalCase.remove(0) == 0;
            }
            case AND -> {
                boolean left = leftChild.eval(evalCase);
                boolean right = rightChild.eval(evalCase);
                return left && right;
            } case OR -> {
                boolean left = leftChild.eval(evalCase);
                boolean right = rightChild.eval(evalCase);
                return left || right;
            }
            default -> {
//                should never happen
                return false;
            }
        }
    }

    public RetVal getString(int index) {
        switch (type){
            case TRUE -> {
                return new RetVal("x" + index, index + 1);
            }
            case NOT -> {
                return new RetVal("!x" + index, index + 1);

            }
            case AND -> {
                var retLeftChild = leftChild.getString(index);
                var retRightChild = rightChild.getString(retLeftChild.intValue);
                return new RetVal(
                        "(" + retLeftChild.stringValue + " and " + retRightChild.stringValue + ")",
                        retRightChild.intValue);
            } case OR -> {
                var retLeftChild = leftChild.getString(index);
                var retRightChild = rightChild.getString(retLeftChild.intValue);
                return new RetVal(
                        "(" + retLeftChild.stringValue + " or " + retRightChild.stringValue + ")",
                        retRightChild.intValue);
            }
            default -> {
//                should never happen
                return null;
            }
        }
    }

    public Function(Function parent, List<Type> types) {
        types = new ArrayList<>(types);

        this.parent = parent;
        this.type = types.remove(0);


        if (this.type == Type.AND || this.type == Type.OR) {
            leftChild = new Function(this, types);
            rightChild = new Function(this, leftChild.leftTypes);
            this.leftTypes = new ArrayList<>(rightChild.leftTypes);
        } else {
            leftChild = null;
            rightChild = null;
            this.leftTypes = new ArrayList<>(types);
        }
    }
}
