package Utils.FileOperations;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileReader {
    public static StringBuilder readFileByName(String fileName){
        StringBuilder fileText = new StringBuilder();

        try {
            File myObj = new File(fileName);
            Scanner myReader = new Scanner(myObj);
            while (myReader.hasNextLine()) {
                fileText.append(myReader.nextLine());
            }
            myReader.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }

        return fileText;
    }

    public static StringBuilder readFileByNameEachTimeMakeNewLine(String fileName){
        StringBuilder fileText = new StringBuilder();

        try {
            File myObj = new File(fileName);
            Scanner myReader = new Scanner(myObj);
            while (myReader.hasNextLine()) {
                fileText.append(myReader.nextLine()).append("\n");
            }
            myReader.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }

        return fileText;
    }
}
