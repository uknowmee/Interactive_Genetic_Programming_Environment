namespace Utils;

public static class PercentagesService
{
    private static Random Random { get; } = new();
    
    public static double RandomPercentage() => Random.NextDouble();
}