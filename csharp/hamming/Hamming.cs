using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int distance = 0;
        if ((distance = Math.Abs(firstStrand.Length - secondStrand.Length)) > 0)
            throw new ArgumentException();
        else
        {
            for (int i = 0; i < Math.Max(firstStrand.Length, secondStrand.Length); i++)
            {
                if (firstStrand[i] != secondStrand[i])
                    distance++;
            }
        }
        return distance;
    }
}