using System;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(string text, string tag) => "<" + tag + ">" + text + "</" + tag + ">";

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = delimiter + "(.+)" + delimiter;
        var replacement = "<" + tag + ">$1</" + tag + ">";
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string Parse__(string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = Parse_(Parse__((markdown)));
        return list ? parsedText : Wrap(parsedText, "p");
    }

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        var count = 0;

        foreach(var input in markdown)
        {
            Match matches = Regex.Match(markdown, "^#+");
            count = matches.Length;
        }
        inListAfter = list;
        if (count == 0)
        {return null;
        }

        var headerTag = "h" + count;
        var headerHtml = Wrap(markdown.Substring(count + 1), headerTag);
        inListAfter = false;  
        return list? "</ul>" + headerHtml: headerHtml;
        
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");
            inListAfter = true; 
            return list? innerHtml: "<ul>" + innerHtml;
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        inListAfter = false;
        return !list? ParseText(markdown, list):"</ul>" + ParseText(markdown, false);
    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
    {
        string result = null;
        if (markdown.Contains("#"))
            result = ParseHeader(markdown, list, out inListAfter);
        else
            inListAfter = false;
 
       result = (result == null)? ParseLineItem(markdown, list, out inListAfter)
                           : ParseParagraph(markdown, list, out inListAfter);
        
        return result?? throw new ArgumentException("Invalid markdown");
    }

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = "";
        var list = false;

        for (int i = 0; i < lines.Length; i++)
        {
            var lineResult = ParseLine(lines[i], list, out list);
            result += lineResult;
        }
        return list? result + "</ul>": result;
    }
}