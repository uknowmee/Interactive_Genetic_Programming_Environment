namespace Utils;

public static class ListExtensions
{
    public static void Set<T>(this List<T> list, T toRemove, T item)
    {
        var idx = list.IndexOf(toRemove);
        list.RemoveAt(idx);
        list.Insert(idx, item);
    }
}