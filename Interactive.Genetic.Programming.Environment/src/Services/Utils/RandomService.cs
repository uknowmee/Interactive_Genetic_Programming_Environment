namespace Utils;

public static class RandomService
{
    private static Random Random { get; } = new();
    
    public static double RandomPercentage() => Random.NextDouble();
    
    public static int RandomInt(int min, int max) => Random.Next(min, max);
    
    public static bool RandomBool() => Random.NextDouble() < 0.5;
    
    public static int RandomInt(int max) => Random.Next(max);
}