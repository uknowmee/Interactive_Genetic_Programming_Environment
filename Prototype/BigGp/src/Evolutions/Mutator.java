package Evolutions;

import Model.Interfaces.PointMutable;
import Model.Interfaces.SubtreeMutable;
import Model.Node;
import Model.Program;
import Serialization.Serializer;

import java.util.ArrayList;
import java.util.Random;

public class Mutator {
    private Program program;
    private ArrayList<Node> nodes;
    private ArrayList<Node> pointMutableNodes;
    private ArrayList<Node> subtreeMutableNodes;


    public void pointMutation(Program program) {
        this.program = program;
        this.nodes = program.getChildrenAsNodes();
        this.pointMutableNodes = program.getPointMutableOnes();

        if (pointMutableNodes.size() == 0) {
            return;
        }

        ((PointMutable) pointMutableNodes.get(new Random().nextInt(pointMutableNodes.size()))).mutate();

        program.updateVariables();

        reset();
    }

    public void subtreeMutation(Program program) {
        this.program = program;
        this.nodes = program.getChildrenAsNodes();
        this.subtreeMutableNodes = program.getSubtreeMutableOnes();

        if (subtreeMutableNodes.size() == 0) {
            return;
        }

        ((SubtreeMutable) subtreeMutableNodes.get(new Random().nextInt(subtreeMutableNodes.size()))).subtreeMutate();

        program.updateVariables();

        reset();
    }

    private void reset() {
        this.program = null;
        this.nodes = null;
        this.pointMutableNodes = null;
        this.subtreeMutableNodes = null;
    }

    public Mutator() {
        reset();
    }

    public static void main(String[] args) {
        Serializer serializer = new Serializer("02-11-2022_04-53-33");
        Program program;
        String before;
        String after;
        Mutator mutator;

        int i = 0;
        while (i < 10000) {
            program = serializer.readProgram();

            before = program.getProgramString();

            mutator = new Mutator();
//            mutator.pointMutation(program);
            mutator.subtreeMutation(program);

            after = program.getProgramString();

            i += 1;
            if (after.equals(before)) {
                System.out.println(before);
                System.out.println("\n");
                System.out.println(after);
                System.out.println(i + "################################################################");
            }
        }
    }
}
