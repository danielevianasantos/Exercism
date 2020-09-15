using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class ScrabbleScore
{
    public static int Score(string input)
    {
        var list = new[]
        {
            new { str = "AEIOULNRST", cod = 1 },
            new { str = "DG", cod = 2 },
            new { str = "BCMP", cod = 3 },
            new { str = "FHVWY", cod = 4 },
            new { str = "K", cod = 5 },
            new { str = "JX", cod =8 },
            new { str = "QZ", cod =10}
         }.ToList();      
        
        var result = 0;

        for (int i = 0; i < input.ToUpper().Length; i++)
        { if (Regex.IsMatch(input.ToUpper()[i].ToString(), @"(<|A|E|I|O|U|L|N|R|S|T|>)$"))
                result += 1;
          if (Regex.IsMatch(input.ToUpper()[i].ToString(), @"(<|D|G|>)$"))
                result += 2;
          if (Regex.IsMatch(input.ToUpper().Substring(i,1), @"(<|B|C|M|P|>)$"))
                result += 3;
          if (Regex.IsMatch(input.ToUpper()[i].ToString(), @"(<|F|H|V|W|Y|>)$"))
                result += 4;
          if (Regex.IsMatch(input.ToUpper()[i].ToString(), @"(<|K|>)$"))
                result += 5;
          if (Regex.IsMatch(input.ToUpper()[i].ToString(), @"(<|J|X|>)$"))
                result += 8;
          if (Regex.IsMatch(input.ToUpper()[i].ToString(), @"(<|Q|Z|>)$"))
                result += 10;
        }

        return result;
    }
}