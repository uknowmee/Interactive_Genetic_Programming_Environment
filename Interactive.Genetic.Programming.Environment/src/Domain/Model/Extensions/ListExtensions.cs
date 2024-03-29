﻿namespace Model.Extensions;

public static class ListExtensions
{
    public static T PopFront<T>(this IList<T> list)
    {
        if (list.Count == 0)
        {
            throw new ArgumentException("List is empty, cannot pop front");
        }

        var item = list[0];
        list.RemoveAt(0);
        return item;
    }

    public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
    {
        ValidateIndices(list, indexA, indexB);
        (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        return list;
    }

    private static void ValidateIndices<T>(ICollection<T> list, int indexA, int indexB)
    {
        if (indexA < 0 || indexA >= list.Count || indexB < 0 || indexB >= list.Count)
        {
            throw new ArgumentException("Invalid indices");
        }
    }
}