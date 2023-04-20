package Interpreter;

import Interpreter.Interpreter.EdWardLexer;
import Interpreter.Interpreter.EdWardParser;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.tree.ParseTree;

import java.util.ArrayList;
import java.util.List;

public class EdWardInterpreter {

    private Visitor visitor;
    private final ParseTree tree;
    private final String program;
    private boolean finished;
    private List<Double> programOutput;

    public boolean isFinished() {
        return finished;
    }

    public List<Double> getProgramOutput() {
        return programOutput;
    }

    public void run(List<Double> input) {
        this.finished = false;
        this.programOutput = new ArrayList<>();

        this.visitor = new Visitor(input);
        try {
            this.visitor.visit(tree);

            this.finished = true;
            this.programOutput = this.visitor.getProgramOutput();

        } catch (Exception e) {
//            Do nothing
        }
    }

    public EdWardInterpreter(String program) {
        this.finished = false;
        this.programOutput = new ArrayList<>();
        this.program = program;

        Lexer lexer = new EdWardLexer(CharStreams.fromString(program));
        CommonTokenStream stream = new CommonTokenStream(lexer);

        EdWardParser parser = new EdWardParser(stream);
        this.tree = parser.program();

        if (parser.getNumberOfSyntaxErrors() > 0) {
            System.out.println("PROGRAM WITH ERRORS!!!!");
            System.exit(-1000);
        }
    }

    public static void main(String[] args) {

        String program = "x_0 = read();\n" +
                "if ((42 > (9 * (56 * 78)))) {\n" +
                "\tx_1 = x_0;\n" +
                "\twrite(x_0);\n" +
                "}\n" +
                "x_0 = (((9 * (2 * 45)) - 12) - 9);\n" +
                "write(x_0);";
        List<Double> input = List.of(new Double[]{0.0, 2.0});

        EdWardInterpreter edWardInterpreter = new EdWardInterpreter(program);
        edWardInterpreter.run(input);

        System.out.println(edWardInterpreter.getProgramOutput());
    }
}
