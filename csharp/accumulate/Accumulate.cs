using System;
using System.Collections.Generic;
public static class AccumulateExtensions
{//T is the type of the first argument in Accumulate and U is return type of this same Method
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {

        foreach (T item in collection)
        {
            yield return func(item);
        }
    }

    public static IEnumerable<U> AccumulateNonLazy<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        var col_list = new List<U>();
        foreach (T item in collection)
        {
            col_list.Add(func(item));
        }
        return col_list;
    }
}