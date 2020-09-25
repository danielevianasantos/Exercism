using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class LedgerEntry
{
   public LedgerEntry(DateTime date, string desc, decimal chg)
   {
       Date = date;
       Desc = desc;
       Chg = chg;
   }

   public DateTime Date { get; }
   public string Desc { get; }
   public decimal Chg { get; }
}

public static class Ledger
{
    private const string USA = "en-US";
    private const string NETLD = "nl-NL";

    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
    new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
   
   private static CultureInfo CreateCulture(string cur, string loc)
   {
        if ((cur != "USD" && cur != "EUR")&&(loc != NETLD && loc != USA))
        {
           throw new ArgumentException("Invalid currency");
        }

       var culture = new CultureInfo(loc);
       culture.NumberFormat.CurrencySymbol = cur == "USD" ? "$" : "€";
       culture.NumberFormat.CurrencyNegativePattern = (loc != USA) ? 12 :0;
       culture.DateTimeFormat.ShortDatePattern = (loc == USA) ? "MM/dd/yyyy" : "dd/MM/yyyy";
       return culture;
   }

   private static string PrintHead(string loc)
   {
        return loc switch
        {
            USA => "Date       | Description               | Change       ",
            NETLD => "Datum      | Omschrijving              | Verandering  ",
            _ => throw new ArgumentException("Invalid locale")
        };
    }

   private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

   private static string Description(string desc) => 
        (desc.Length > 25) ? $"{desc.Substring(0, 22)}..." : desc;


   private static string Change(IFormatProvider culture, decimal cgh) =>
        cgh < 0.0m ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";
   

private static string PrintEntry(IFormatProvider culture, LedgerEntry entry) =>
   $"{Date(culture, entry.Date)} | {Description(entry.Desc),-25} | {Change(culture, entry.Chg),13}";



    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
   {
       var result = new List<LedgerEntry>();
       result.AddRange(entries.Where(e => e.Chg < 0).OrderBy(x => $"{x.Date}@{x.Desc}@{x.Chg}"));
       result.AddRange(entries.Where(e => e.Chg >= 0).OrderBy(x => $"{x.Date}@{x.Desc}@{x.Chg}"));

       return result;
   }

   public static string Format(string currency, string locale, LedgerEntry[] entries)
   {
       var formatted = PrintHead(locale);

       var culture = CreateCulture(currency, locale);

       if (entries.Length > 0)
       {
           var sortedentries = sort(entries);

           for (var i = 0; i < entries.Count(); i++)
           {
               formatted += $"\n{PrintEntry(culture, sortedentries.Skip(i).First())}";
           }
       }

       return formatted;
   }
}
