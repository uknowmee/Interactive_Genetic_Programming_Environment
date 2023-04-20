package Generating;

import Utils.Config.BigGpConfig;
import Data.*;
import Data.Vector;

import java.io.File;
import java.util.*;

public class DataGenerator {
    private final BigGpConfig config;
    private final int numOfTestCases;

    private void saveTestCases(Task task) {
        String path = config.getTasksFolder() + task.getTaskName();

        File dir = null;

        if (config.isIfWindows()) {
            dir = new File(path + "\\");
            path += "\\data.json";
        } else {
            dir = new File(path + "/");
            path += "/data.json";
        }

        if (!(dir.exists())) {
            dir.mkdirs();
        }

        task.save(path);
    }

    private void saveTestCases(Task task, String functionName) {
        String path = config.getTasksFolder() + task.getTaskName();

        File dir = null;

        if (config.isIfWindows()) {
            dir = new File(path + "\\");
            path += "\\data.json";
        } else {
            dir = new File(path + "/");
            path += "/data.json";
        }

        if (!(dir.exists())) {
            dir.mkdirs();
        }

        task.save(path, functionName);
    }

    private int generateInt() {
        return new Random().nextInt();
    }

    private int generatePositiveInt() {
        return Math.abs(new Random().nextInt());
    }

    private int generateInt(int from, int to) {
        return new Random().nextInt(from, to);
    }

    private double generateDouble(int from, int size) {
        return from + new Random().nextFloat() * size;
    }

    private void generate_1_1_A() {
        int maxInputLength = 0;
        int minInputLength = 0;
        int maxOutputLength = -1;
        int minOutputLength = 1;

        Task task = new Task("1_1_A", 1, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector input = new Vector();
        IVector output = new Vector();
        IVector programOutput = new Vector();

        output.addValue(1);

        while (!task.ready()) {
            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_1_B() {
        int maxInputLength = 0;
        int minInputLength = 0;
        int maxOutputLength = -1;
        int minOutputLength = 1;

        Task task = new Task("1_1_B", 1, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector input = new Vector();
        IVector output = new Vector();
        IVector programOutput = new Vector();

        output.addValue(789);

        while (!task.ready()) {
            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_1_C() {
        int maxInputLength = 0;
        int minInputLength = 0;
        int maxOutputLength = -1;
        int minOutputLength = 1;

        Task task = new Task("1_1_C", 1, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector input = new Vector();
        IVector output = new Vector();
        IVector programOutput = new Vector();

        output.addValue(31415);

        while (!task.ready()) {
            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_1_D() {
        int maxInputLength = 0;
        int minInputLength = 0;
        int maxOutputLength = -1;
        int minOutputLength = 1;

        Task task = new Task("1_1_D", 1, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector input = new Vector();
        IVector output = new Vector();
        IVector programOutput = new Vector();

        output.addValue(1);

        while (!task.ready()) {
            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_1_E() {
        int maxInputLength = 0;
        int minInputLength = 0;
        int maxOutputLength = -1;
        int minOutputLength = 1;

        Task task = new Task("1_1_E", 1, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector input = new Vector();
        IVector output = new Vector();
        IVector programOutput = new Vector();

        output.addValue(789);

        while (!task.ready()) {
            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_1_F() {
        int maxInputLength = 0;
        int minInputLength = 0;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_1_F", 1, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector input = new Vector();
        IVector output = new Vector();
        IVector programOutput = new Vector();

        output.addValue(1);

        while (!task.ready()) {
            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_2_A() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_2_A", numOfTestCases, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {

            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(0, 10);
            int num2 = generateInt(0, 10);

            input.addValue(num1);
            input.addValue(num2);
            output.addValue(num1 + num2);

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_2_B() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_2_B", numOfTestCases, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {

            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(-9, 10);
            int num2 = generateInt(-9, 10);

            input.addValue(num1);
            input.addValue(num2);
            output.addValue(num1 + num2);

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_2_C() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_2_C", 1000, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {

            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(0, 9999);
            int num2 = generateInt(0, 9999);

            input.addValue(num1);
            input.addValue(num2);
            output.addValue(num1 + num2);

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_2_D() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_2_D", numOfTestCases, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {

            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(0, 9999);
            int num2 = generateInt(0, 9999);

            input.addValue(num1);
            input.addValue(num2);
            output.addValue(num1 - num2);

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_2_E() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_2_E", 1000, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {

            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(0, 9999);
            int num2 = generateInt(0, 9999);

            input.addValue(num1);
            input.addValue(num2);
            output.addValue(num1 * num2);

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_3_A() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_3_A", 1000, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {

            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(0, 10);
            int num2 = generateInt(0, 10);

            while (num1 == 0 || num2 == 0) {
                num1 = generateInt(0, 10);
                num2 = generateInt(0, 10);
            }

            input.addValue(num1);
            input.addValue(num2);
            output.addValue(Math.max(num1, num2));

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_3_B() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_3_B", 1000, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {

            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(-9999, 9999);
            int num2 = generateInt(-9999, 9999);

            input.addValue(num1);
            input.addValue(num2);
            output.addValue(Math.max(num1, num2));

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1_4_A() {
        int borderValue = 10;

        int maxInputLength = 3;
        int minInputLength = maxInputLength;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("1_4_A", 800, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();
        while (!task.ready()) {
            IVector input = new Vector();
            IVector output = new Vector();

            int sum = 0;
            for (int i = 0; i < maxInputLength; i++) {
                int value = generateInt(-borderValue, borderValue);
                input.addValue(value);
                sum += value;
            }

            output.addValue(((double) sum / maxInputLength));

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_1() {
        int maxInputLength = 2;
        int minInputLength = 2;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("F_1", numOfTestCases, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {
            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(-10, 11);
            double num2 = generateDouble(-10, 20);

            input.addValue(num1);
            input.addValue(num2);

            output.addValue(num1 + num2);

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_2() {
        int maxInputLength = 3;
        int minInputLength = 1;
        int maxOutputLength = maxInputLength;
        int minOutputLength = maxInputLength;

        Task task = new Task("F_2", 2000, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {
            IVector input = new Vector();
            IVector output = new Vector();

//            for (int i = 0; i < generateInt(minInputLength, maxInputLength); i++) {
            for (int i = 0; i < maxInputLength; i++) {
                int value = generateInt(-200, 200);
                input.addValue(value);
            }

            input.getValues().forEach(val -> {
                if (val >= 0) {
                    output.addValue(val);
                } else {
                    output.addValue(0);
                }
            });

            while (output.getValues().size() != maxOutputLength) {
                output.addValue(0);
            }

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_3_1() {
        int maxInputLength = 3;
        int minInputLength = 3;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task("F_3_1", numOfTestCases, maxInputLength, minInputLength, maxOutputLength, minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {
            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(-10, 11);
            int num2 = generateInt(-10, 11);
            int num3 = generateInt(-10, 11);

            input.addValue(num1);
            input.addValue(num2);
            input.addValue(num3);

            Object[] values = input.getValues().toArray();
            Arrays.sort(values);
            output.addValue((Double) values[1]);

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_3_2() {
        int maxInputLength = 4;
        int minInputLength = 4;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        Task task = new Task(
                "F_3_2",
                800,
                maxInputLength,
                minInputLength,
                maxOutputLength,
                minOutputLength);

        IVector programOutput = new Vector();

        while (!task.ready()) {
            IVector input = new Vector();
            IVector output = new Vector();

            int num1 = generateInt(1, 101);
            int num2 = generateInt(1, 101);
            int num3 = generateInt(1, 101);
            int num4 = generateInt(1, 101);

            input.addValue(num1);
            input.addValue(num2);
            input.addValue(num3);
            input.addValue(num4);

            output.addValue(Collections.min(input.getValues()));

            task.addNewCase(new TestCase(input, output, programOutput));
        }

        saveTestCases(task);
    }

    private void generate_4() {
        genLogic(1, List.of(new Function.Type[]{
                Function.Type.TRUE
        }));

        genLogic(2, List.of(new Function.Type[]{
                Function.Type.AND,
                Function.Type.TRUE,
                Function.Type.TRUE
        }));

        genLogic(3, List.of(new Function.Type[]{
                Function.Type.AND,
                Function.Type.OR,
                Function.Type.TRUE,
                Function.Type.TRUE,
                Function.Type.TRUE
        }));
    }

    private void genLogic(int numOfVariables, List<Function.Type> functionDefinition) {
        int maxInputLength = numOfVariables;
        int minInputLength = numOfVariables;
        int maxOutputLength = 1;
        int minOutputLength = 1;

        List<List<Integer>> cases = Function.getCases(numOfVariables);
        Function function = new Function(null, functionDefinition);

        Task task = new Task("F_4\\" + numOfVariables, (int) Math.pow(2, numOfVariables), maxInputLength, minInputLength, maxOutputLength, minOutputLength);
        IVector programOutput = new Vector();

        cases.forEach(evalCase -> {
            IVector input = new Vector();
            IVector output = new Vector();

            evalCase.forEach(input::addValue);
            output.addValue(function.eval(new ArrayList<>(evalCase)) ? 1 : 0);

            task.addNewCase(new TestCase(input, output, programOutput));
        });

//        saveTestCases(task, function.getString(0).stringValue);
    }

    public void generateAllTasks() {
        generate_1_1_A();
        generate_1_1_B();
        generate_1_1_C();
        generate_1_1_D();
        generate_1_1_E();
        generate_1_1_F();

        generate_1_2_A();
        generate_1_2_B();
        generate_1_2_C();
        generate_1_2_D();
        generate_1_2_E();

        generate_1_3_A();
        generate_1_3_B();

        generate_1_4_A();

        generate_1();
        generate_2();
        generate_3_1();
        generate_3_2();
        generate_4();
    }

    public DataGenerator(int numOfTestCases) {
        this.config = BigGpConfig.readConfig();
        this.numOfTestCases = numOfTestCases;
    }

    public static void main(String[] args) {
        DataGenerator generator = new DataGenerator(200);
//        generator.generateAllTasks();
        generator.generate_4();
    }
}
