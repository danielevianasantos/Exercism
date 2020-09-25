using System;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit=0)
    {
        if (limit <=1)
            throw new ArgumentOutOfRangeException();

        bool[] is_prime = new bool[limit + 1];
        var list = new List<int>();
        for (int i = 2; i <= limit; i++) 
            is_prime[i] = true;

        for (int i = 2; i <= limit; i++)
        {
            if (is_prime[i])
            {
                list.Add(i);

                for (int j = i * 2; j <= limit; j += i)
                    is_prime[j] = false;
            }
        }
        return list.ToArray();
    }
}