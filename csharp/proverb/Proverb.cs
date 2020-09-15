using System;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string upcoming = "For want of a 1 the 2 was lost.";
        string first = "And all for the want of a 2.";
        string[] proverbs = new string[subjects.Length];
        int pos = subjects.Length;

        for (int i = 0; i < subjects.Length; i++)
        {
            while (pos != 1)
            {
                proverbs[i] = upcoming.Replace("1", subjects[i]).Replace("2", subjects[i + 1]);
                pos--;
                i++;
            }

        }

        if (pos == 1) proverbs[subjects.Length-1] = first.Replace("2", subjects[0]);
        
        return proverbs;
    }

}