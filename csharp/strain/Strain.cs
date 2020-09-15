using System;
using System.Collections.Generic;

using Xunit.Sdk;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (T item in collection)
        {
            if(predicate(item))
                yield return item;
        }
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        if(collection!=null)
        {
            foreach (T item in collection)
            {
                if (!predicate(item))
                    yield return item;
            }
        }
        else
        {
            throw new EmptyException("Error");
        }
    }
}