using System;
using System.Collections.Generic;

public static class ListExtensions
{
    private static Random rng = new Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1); // Random index from 0 to n
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static T Pop<T>(this List<T> list)
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Cannot pop from an empty list.");

        T last = list[^1]; // ^1 คือ index ตัวสุดท้าย
        list.RemoveAt(list.Count - 1);
        return last;
    }
}

