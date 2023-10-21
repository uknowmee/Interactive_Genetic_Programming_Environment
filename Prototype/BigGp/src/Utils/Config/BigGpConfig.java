package Utils.Config;

import Utils.FileOperations.FileReader;
import Utils.FileOperations.PathNormalizer;
import com.google.gson.Gson;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.text.SimpleDateFormat;
import java.util.Date;

public class BigGpConfig {
    private String outputFolder = "";
    private String tasksFolder = "";
    private String taskFolder = "";

    private String programToRead = "";
    private String nextConfigsFolder = "";

    private boolean ifWindows;
    private int showTimeout;

    private double error;
    private int populationSize;
    private int generations;
    private int tournamentSize;

    private double crossProbability;

    private double mutationProbability;
    private double pointMutationProbability;
    private double subtreeMutationProbability;

    private double lineChangingProbability;
    private double newLineProbability;
    private double deleteLineProbability;
    private double swapLineProbability;

    private int maxInt;
    private int maxStringLen;

    private double newChildOfProgramNodeChance;
    private double newDeepNodeGenerationChance;
    private double newDeepNodeGenerationFall;

    private double newChildOfForNodeChance;
    private double newExpressionInForComparisonChance;

    private double newChildOfIfNodeChance;

    private double newLogicExpressionChance;
    private double newTwoArgExpressionChance;
    private double newVarExpressionChance;

    public int getShowTimeout() {
        return showTimeout;
    }

    @Override
    public String toString() {
        return "BigGpConfig{" +
                "\n outputFolder=" + outputFolder +
                "\n tasksFolder=" + tasksFolder +
                "\n taskFolder=" + taskFolder +
                "\n programToRead=" + programToRead +
                ",\n nextConfigsFolder=" + nextConfigsFolder +
                ",\n\n ifWindows=" + ifWindows +
                ",\n showTimeout=" + showTimeout +
                ",\n\n error=" + error +
                ",\n populationSize=" + populationSize +
                ",\n generations=" + generations +
                ",\n tournamentSize=" + tournamentSize +
                ",\n\n crossProbability=" + crossProbability +
                ",\n mutationProbability=" + mutationProbability +
                ",\n pointMutationProbability=" + pointMutationProbability +
                ",\n subtreeMutationProbability=" + subtreeMutationProbability +
                ",\n\n lineChangingProbability=" + lineChangingProbability +
                ",\n newLineProbability=" + newLineProbability +
                ",\n deleteLineProbability=" + deleteLineProbability +
                ",\n swapLineProbability=" + swapLineProbability +
                ",\n\n maxInt=" + maxInt +
                ",\n maxStringLen=" + maxStringLen +
                ",\n\n newChildOfProgramNodeChance=" + newChildOfProgramNodeChance +
                ",\n newDeepNodeGenerationChance=" + newDeepNodeGenerationChance +
                ",\n newDeepNodeGenerationFall=" + newDeepNodeGenerationFall +
                ",\n\n newChildOfForNodeChance=" + newChildOfForNodeChance +
                ",\n newExpressionInForComparisonChance=" + newExpressionInForComparisonChance +
                ",\n\n newChildOfIfNodeChance=" + newChildOfIfNodeChance +
                ",\n\n newLogicExpressionChance=" + newLogicExpressionChance +
                ",\n newTwoArgExpressionChance=" + newTwoArgExpressionChance +
                ",\n newVarExpressionChance=" + newVarExpressionChance +
                "\n}";
    }

    public int getMaxInt() {
        return maxInt;
    }

    public int getMaxStringLen() {
        return maxStringLen;
    }

    public String getProgramToRead() {
        if (ifWindows) {
            return getOutputFolderShort() + programToRead + "\\" + "Program.json";
        }
        return getOutputFolderShort() + "/" + programToRead + "/" + "Program.json";
    }

    public String getOutputFolder() {
        String pattern = "dd-MM-yyyy_HH-mm-ss";
        SimpleDateFormat dateFormat = new SimpleDateFormat(pattern);
        String date = dateFormat.format(new Date());

        File dir = null;

        if (ifWindows) {
            dir = new File(outputFolder + "\\" + date + "\\");
        } else {
            dir = new File(outputFolder + "/" + date + "/");
        }

        assert dir != null;
        if (!(dir.exists())) {
            dir.mkdirs();
        }

        if (ifWindows) {
            return dir + "\\";
        }
        return dir + "/";
    }

    public String getOutputFolderShort() {
        if (ifWindows) {
            return outputFolder + "\\";
        }
        return outputFolder;
    }

    public String getNextConfigsFolder() {
        return nextConfigsFolder;
    }

    public boolean isIfWindows() {
        return ifWindows;
    }

    public double getNewChildOfProgramNodeChance() {
        return newChildOfProgramNodeChance;
    }

    public double getNewDeepNodeGenerationChance() {
        return newDeepNodeGenerationChance;
    }

    public double getNewDeepNodeGenerationFall() {
        return newDeepNodeGenerationFall;
    }

    public double getNewChildOfForNodeChance() {
        return newChildOfForNodeChance;
    }

    public double getNewExpressionInForComparisonChance() {
        return newExpressionInForComparisonChance;
    }

    public double getNewChildOfIfNodeChance() {
        return newChildOfIfNodeChance;
    }

    public double getNewLogicExpressionChance() {
        return newLogicExpressionChance;
    }

    public double getNewTwoArgExpressionChance() {
        return newTwoArgExpressionChance;
    }

    public double getNewVarExpressionChance() {
        return newVarExpressionChance;
    }

    public String getTasksFolder() {
        return tasksFolder;
    }

    public String getTaskFolder() {
        return taskFolder;
    }

    public double getError() {
        return error;
    }

    public int getPopulationSize() {
        return populationSize;
    }

    public int getGenerations() {
        return generations;
    }

    public int getTournamentSize() {
        return tournamentSize;
    }

    public double getCrossProbability() {
        return crossProbability;
    }

    public double getMutationProbability() {
        return mutationProbability;
    }

    public double getPointMutationProbability() {
        return pointMutationProbability;
    }

    public double getSubtreeMutationProbability() {
        return subtreeMutationProbability;
    }

    public double getLineChangingProbability() {
        return lineChangingProbability;
    }

    public double getNewLineProbability() {
        return newLineProbability;
    }

    public double getDeleteLineProbability() {
        return deleteLineProbability;
    }

    public double getSwapLineProbability() {
        return swapLineProbability;
    }

    private void normalizePaths() {
        if (!ifWindows) {
            outputFolder = PathNormalizer.changePathToMac(outputFolder);
            tasksFolder = PathNormalizer.changePathToMac(tasksFolder);
            taskFolder = PathNormalizer.changeTaskFolderPathToMac(taskFolder);
        }
    }

    public void saveConfig() {
        Gson gson = new Gson();
        String response = gson.toJson(this);
        String path = "BigGpConfig.json";

        try {
            Files.write(Paths.get(path), response.getBytes());
            System.out.println("Successfully wrote to the file: " + path);
        } catch (IOException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public void saveConfig(String path) {
        File dir = new File(path);;
        if (!(dir.exists())) {
            dir.mkdirs();
        }

        Gson gson = new Gson();
        String response = gson.toJson(this);
        path += "BigGpConfig.json";

        try {
            Files.write(Paths.get(path), response.getBytes());
            System.out.println("Successfully wrote to the file: " + path);
        } catch (IOException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public static String getConfigInJson(BigGpConfig bigGpConfig) {
        Gson gson = new Gson();
        return gson.toJson(bigGpConfig);
    }

    public static BigGpConfig readConfig() {
        Gson gson = new Gson();
        String fileName = "BigGpConfig.json";
        BigGpConfig bigGpConfig;
        StringBuilder fileText = FileReader.readFileByName(fileName);

        bigGpConfig = gson.fromJson(String.valueOf(fileText), BigGpConfig.class);

        bigGpConfig.normalizePaths();

        return bigGpConfig;
    }

    public BigGpConfig() {

    }

    public static void main(String[] args) {

        BigGpConfig bigGpConfig = BigGpConfig.readConfig();
        System.out.println(bigGpConfig);
    }
}