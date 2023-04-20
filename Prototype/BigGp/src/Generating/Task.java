package Generating;

import Data.TestCase;
import Utils.FileOperations.FileReader;
import com.google.gson.Gson;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class Task {
    private String taskName;
    private String function;
    private int numOfTestCases;

    private int maxInputLength;
    private int minInputLength;

    private int maxOutputLength;
    private int minOutputLength;

    private List<TestCase> testCases;

    public List<TestCase> getTestCases() {
        return testCases;
    }

    public String getTaskName() {
        return taskName;
    }

    public int getNumOfTestCases() {
        return numOfTestCases;
    }

    public void addNewCase(TestCase testCase) {
        testCases.add(testCase);
    }

    public boolean ready() {
        boolean isReady = testCases.size() == numOfTestCases;

        if (isReady) {
            makeSummary();
        }

        return isReady;
    }

    private void makeSummary() {

    }

    public static Task readTaskFromFolder(String path) {
        Gson gson = new Gson();
        StringBuilder fileText = FileReader.readFileByName(path + "data.json");
        return gson.fromJson(String.valueOf(fileText), Task.class);
    }

    public void save(String path) {
        Gson gson = new Gson();
        String response = gson.toJson(this);

        try {
            Files.write(Paths.get(path), response.getBytes());
            System.out.println("Successfully wrote to the file: " + path);
        } catch (IOException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public void save(String path, String functionName) {
        this.function = functionName;
        this.save(path);
    }

    public static Task copy(Task task){
        Task taskCopy = new Task(task.taskName, task.numOfTestCases, task.maxInputLength,
                task.minInputLength, task.maxOutputLength, task.minOutputLength);
        task.getTestCases().forEach(testCase -> taskCopy.addNewCase(TestCase.copy(testCase)));
        return taskCopy;
    }

    public Task(String taskName, int numOfTestCases, int maxInputLength, int minInputLength,
                int maxOutputLength, int minOutputLength) {

        this.taskName = taskName;
        this.numOfTestCases = numOfTestCases;
        this.testCases = new ArrayList<>();

        this.maxInputLength = maxInputLength;
        this.minInputLength = minInputLength;

        this.maxOutputLength = maxOutputLength;
        this.minOutputLength = minOutputLength;
    }
}
