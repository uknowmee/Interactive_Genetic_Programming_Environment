package Serialization;

import Utils.Config.BigGpConfig;
import Utils.FileOperations.FileReader;
import Model.Program;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import org.apache.commons.io.FileUtils;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.concurrent.TimeUnit;

public class Serializer {

    private String FOLDER;

    private void runCommand(BigGpConfig config, String command) {
        boolean isWindows = config.isIfWindows();
        String userDir = System.getProperty("user.dir");

        try {
            ProcessBuilder builder = new ProcessBuilder();

            if (isWindows) {
                builder.directory(new File(userDir + FOLDER));
                builder.command("cmd.exe", "/c", command);
            } else {
                builder.directory(new File(userDir + "/" + FOLDER));
                builder.command("sh", "-c", "open -a TextEdit" + command);
            }

            Process process = builder.start();

            OutputStream outputStream = process.getOutputStream();

            boolean isFinished = process.waitFor(config.getShowTimeout(), TimeUnit.SECONDS);

            outputStream.flush();
            outputStream.close();

            if (!isFinished) {
                process.destroyForcibly();
            }
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    private void closeCommand(BigGpConfig config) {
        boolean isWindows = config.isIfWindows();
        String userDir = System.getProperty("user.dir");

        try {
            ProcessBuilder builder = new ProcessBuilder();

            if (isWindows) {
                builder.directory(new File(userDir + FOLDER));
                builder.command("cmd.exe", "/c", "taskkill /F /IM Notepad.exe");
            } else {
                builder.directory(new File(userDir + "/" + FOLDER));
                builder.command("sh", "-c", "killall TextEdit");
            }

            Process process = builder.start();

            OutputStream outputStream = process.getOutputStream();

            boolean isFinished = true;

            outputStream.flush();
            outputStream.close();

            if (!isFinished) {
                process.destroyForcibly();
            }
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public void writeProgramToTxtShowAndClose(Program program) {
        BigGpConfig config = BigGpConfig.readConfig();
        String path = FOLDER + program.getNAME() + ".txt";
        String progTxt = program.getProgramString();
        String progName = program.getNAME();

        try {
            Files.write(Paths.get(path), progTxt.getBytes());
            System.out.println("Successfully wrote to the file: " + program.getNAME());

            runCommand(config, progName + ".txt");
            closeCommand(config);

        } catch (IOException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public void writeProgramToTxt(Program program) {
        BigGpConfig config = BigGpConfig.readConfig();

        config.saveConfig(FOLDER);

        String path = FOLDER + program.getNAME() + ".txt";
        String progTxt = program.getProgramString();

        try {
            Files.write(Paths.get(path), progTxt.getBytes());
            System.out.println("Successfully wrote to the file: " + path);

        } catch (IOException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public void writeProgramToJson(Program program) {
        Gson gson = new Gson();
        String response = gson.toJson(Tokenizer.makeTokensFromListOfNodesWithEmpty(program.getChildrenAsNodesWithEmpty()));

        BigGpConfig config = BigGpConfig.readConfig();
        config.saveConfig(FOLDER);

        String path = FOLDER + program.getNAME() + ".json";

        try {
            Files.write(Paths.get(path), response.getBytes());
            System.out.println("Successfully wrote to the file: " + path);
        } catch (IOException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public void writeProgramToTxtAndToJson(Program program) {
        writeProgramToTxt(program);
        writeProgramToJson(program);
    }

    public static void clearOutputDirectory() {
        BigGpConfig config = BigGpConfig.readConfig();
        File file = new File(config.getOutputFolderShort());

        try {
            FileUtils.cleanDirectory(file);

            System.out.println("Directory cleared!");
        } catch (Exception e) {
            System.out.println("Error while clearing directory!");
        }
    }

    public static Program readProgramFileFromConfig() {
        BigGpConfig config = BigGpConfig.readConfig();

        StringBuilder fileText = FileReader.readFileByName(config.getProgramToRead());

        ArrayList<Token> tokens = new Gson().fromJson(fileText.toString(), new TypeToken<ArrayList<Token>>() {}.getType());

        return Program.programFromTokens(tokens);
    }

    public Program readProgram() {
        StringBuilder fileText = FileReader.readFileByName(FOLDER);

        ArrayList<Token> tokens = new Gson().fromJson(fileText.toString(), new TypeToken<ArrayList<Token>>() {}.getType());

        return Program.programFromTokens(tokens);
    }

    public Serializer() {
        BigGpConfig config = BigGpConfig.readConfig();
        FOLDER = config.getOutputFolder();
    }

    public Serializer(String folder) {
        BigGpConfig config = BigGpConfig.readConfig();

        if (config.isIfWindows()){
            FOLDER = config.getOutputFolderShort() + folder;
        } else {
            FOLDER = config.getOutputFolderShort() + folder;
        }
    }

    public String getFolder() {
        return FOLDER;
    }

    public static void main(String[] args) {
        Program program = new Program(1);
        program.addRandomNodes();

        Serializer serializer = new Serializer();

        serializer.writeProgramToTxtAndToJson(program);
//        clearOutputDirectory();
    }
}