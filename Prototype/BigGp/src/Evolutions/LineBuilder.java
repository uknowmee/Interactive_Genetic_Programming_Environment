package Evolutions;

import Model.BaseNodes.AddRandomBaseNode;
import Model.Node;
import Model.Program;
import Serialization.Serializer;

import java.util.ArrayList;
import java.util.Random;

public class LineBuilder {
    private Program program;
    private ArrayList<Node> nodes;
    private ArrayList<AddRandomBaseNode> growingOnes;

    private static final Random RANDOM = new Random();

    public void growOnceLastInBlock() {
        growingOnes.get(RANDOM.nextInt(growingOnes.size())).addRandomNode();
    }

    public void growOnceInsideBlock() {
        growingOnes.get(RANDOM.nextInt(growingOnes.size())).addRandomNodeInside();
    }

    public void growLotLastInBlock() {
        growingOnes.get(RANDOM.nextInt(growingOnes.size())).addRandomNodes();
    }

    public void swapTwoLines() {
        AddRandomBaseNode node = growingOnes.get(RANDOM.nextInt(growingOnes.size()));

        if (growingOnes.size() == 1 && node instanceof Program pr && pr.getChildrenNodes().size() <= pr.getINPUTS() + 1){
            return;
        }

        while (((Node) node).getChildrenNodes().size() <= 1) {
            node = growingOnes.get(RANDOM.nextInt(growingOnes.size()));
        }

        if (node instanceof Program pr && pr.getChildrenNodes().size() <= pr.getINPUTS() + 1){
            return;
        }

        node.swapTwoLines();
    }

    public void deleteLine() {
        AddRandomBaseNode node = growingOnes.get(RANDOM.nextInt(growingOnes.size()));

        if (growingOnes.size() == 1 && node instanceof Program pr && pr.getChildrenNodes().size() <= pr.getINPUTS() + 1){
            return;
        }

        while (((Node) node).getChildrenNodes().size() < 1) {
            node = growingOnes.get(RANDOM.nextInt(growingOnes.size()));
        }

        if (node instanceof Program pr && pr.getChildrenNodes().size() <= pr.getINPUTS() + 1){
            return;
        }

        node.deleteLine();
    }

    public LineBuilder(Program program) {
        this.program = program;
        this.nodes = program.getChildrenAsNodes();
        this.growingOnes = new ArrayList<>();

        growingOnes.add(program);

        for (Node node : nodes) {
            if (node instanceof AddRandomBaseNode growingOne) {
                growingOnes.add(growingOne);
            }
        }
    }

    public static void main(String[] args) {
//        Serializer serializer = new Serializer("09-11-2022_12-49-13");
        Serializer serializer = new Serializer("02-11-2022_04-53-33");
        Program program = serializer.readProgram();

        LineBuilder lineBuilder = new LineBuilder(program);

//        lineBuilder.growOnceLastInBlock();
//        lineBuilder.growOnceInsideBlock();
//        lineBuilder.growLotLastInBlock();
        lineBuilder.swapTwoLines();
//        lineBuilder.deleteLine();

        System.out.println(program.getProgramString());
    }
}
