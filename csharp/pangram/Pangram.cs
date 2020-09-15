using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        input = input.ToLower();
        var char_array = (input.ToCharArray());
        var alphabet = ("abcdefghijklmnopqrstuvwxyz".ToCharArray());
        var lst = char_array.OfType<char>().ToList();
        var lst2 = alphabet.OfType<char>().ToList();
        var coincidences = lst2.Intersect(lst).Count() >= lst2.Count();
        return coincidences;
    }
}
