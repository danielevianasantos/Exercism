using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries =8,
    Tomatoes =16,
    Chocolate =32,
    Pollen = 64,
    Cats =128
}

public class Allergies
{
    private static int _mask;
    public Allergies(int mask) => _mask= mask;
    public bool IsAllergicTo(Allergen allergen) => (_mask & allergen.GetHashCode())>0;
    public Allergen[] List()
    {
        List<Allergen> allergies = new List<Allergen>();
        foreach (var item in Enum.GetValues(typeof(Allergen)))
        {
            if(IsAllergicTo((Allergen)item))
                allergies.Add((Allergen)item);
        }
        return allergies.ToArray();
    }
}