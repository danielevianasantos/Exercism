using System;
using System.Linq;

public static class ReverseString
{   static string reversed;
    public static string Reverse(string input) =>  reversed = new string(input.ToCharArray()
                                                                        .Reverse().ToArray());
}