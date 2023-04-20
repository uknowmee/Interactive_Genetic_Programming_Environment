package Utils.FileOperations;

public class PathNormalizer {
    public static String changePathToMac(String path) {
        path = path.substring(2);
        path = path.replace('\\', '/');

        return path;
    }
}
