using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {

        if(sequence.Contains("BDEFHIJKLMNOPQRSTUVWXYZ"))
            throw new ArgumentException();
        else
        { 
           int num_a = 0;
            int num_c = 0;
            int num_g = 0;
            int num_t = 0;
            num_a = sequence.Count(f => f == 'A');
            num_c = sequence.Count(f => f == 'C');
            num_g = sequence.Count(f => f == 'G');
            num_t = sequence.Count(f => f == 'T');
            var returnItems = new Dictionary<char, int>
            {
                ['A'] = num_a,
                ['C'] = num_c,
                ['G'] = num_g,
                ['T'] = num_t
            };
            return returnItems;     
        }
    }

}