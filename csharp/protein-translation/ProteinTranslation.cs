using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var lstStrings = new[]
        {
            new { l_str = new { tri = new [] { "AUG"}, pro = "Methionine" }},
            new { l_str = new { tri = new [] { "UUU","UUC"}, pro = "Phenylalanine" }},
            new { l_str = new { tri = new [] { "UUA","UUG"}, pro = "Leucine" }},
            new { l_str = new { tri = new [] { "UCU","UCC","UCA","UCG"}, pro = "Serine" }},
            new { l_str = new { tri = new [] { "UAU","UAC"}, pro = "Tyrosine" }},
            new { l_str = new { tri = new [] { "UGU","UGC"}, pro = "Cysteine" }},
            new { l_str = new { tri = new [] { "UGG" }, pro = "Tryptophan" }},
            new { l_str = new { tri = new [] { "UAA","UAG","UGA"}, pro = "STOP" }}
         }.ToList();

        var lst_strand = new List<string>();
        int j = 0, k=0;
        for (int i = 0; i < strand.Length; i += 3)
        {
            lst_strand.Add(strand.Substring(i,3));
            j++;
        }
        var array_strand = lst_strand.ToArray();
        j = 0;
        var pro = new List<string>();
     
        for(j=0;j<array_strand.Length;j++)
        {   if (lstStrings.Last().l_str.tri.Contains(array_strand[j]))
                { break; }
            foreach (var item in lstStrings)
            {
                if (lstStrings.Last().l_str.tri.Contains(array_strand[j]))
                { break; }
                if (item.l_str.tri.Contains(array_strand[j]))
                    pro.Add(item.l_str.pro);
            }
        }
        return pro.Distinct().ToArray();
    }
}