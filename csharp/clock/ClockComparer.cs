using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
public partial class ClockComparer
{
    public static Ascending Ascending => new Ascending();
    public static Descending Descending => new Descending();
    public static DescendingHourAscendingMinutesComparer DescendingHourAscendingMinutes => new DescendingHourAscendingMinutesComparer();
}
public class Ascending : IComparer<Clock>, IComparer
{
    public int Compare(object one, object two)
    {
        if (!(one is Clock && two is Clock))
        {
            throw new ArgumentException("Cannot compare that are not Clocks.");
        }
        return Compare(one, two);
    }
    public int Compare([AllowNull] Clock one, [AllowNull] Clock two)
    {
        if (one > two) return 1;
        if (two > one) return -1;
        return 0;
    }
}
public class Descending : IComparer<Clock>, IComparer
{
    public int Compare(object one, object two)
    {
        if (!(one is Clock && two is Clock))
        {
            throw new ArgumentException("Cannot compare that are not Clocks.");
        }
        return Compare(one, two);
    }
    public int Compare([AllowNull] Clock one, [AllowNull] Clock two)
    {
        if (one > two) return 1;
        if (two > one) return -1;
        return 0;
    }
}
public class DescendingHourAscendingMinutesComparer : IComparer<Clock>, IComparer
{
     public int Compare(object one, object two)
     {
       if (!(one is Clock && two is Clock))
       {
            throw new ArgumentException("Cannot compare that are not Clocks.");
       }
       return Compare(one, two);
     }
    public int Compare([AllowNull] Clock one, [AllowNull] Clock two)
    {
        if (one > two) return 1;
        if (two > one) return -1;
        return 0;
    }

}

