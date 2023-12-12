namespace Model.Extensions;

public static class EnumExtensions
{
    private static readonly Random Random = new();

    public static T GetRandomValue<T>() => GetValues<T>().GetRandom();
    
    private static T[] GetValues<T>() => (T[]) Enum.GetValues(typeof(T));
    
    private static T GetRandom<T>(this IReadOnlyList<T> array) => array[Random.Next(array.Count)];
}
