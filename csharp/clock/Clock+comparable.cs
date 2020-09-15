using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;


public partial class Clock : IComparable<Clock>, IComparable
{
    public int CompareTo([AllowNull] Clock other)
    {
        if (this > other)
            return 1;
        else if (this < other)
            return -1;
        return 0;
    }

    public int CompareTo(object obj)
    {
        if (obj is Clock clock)
            return CompareTo(clock);
        throw new ArgumentException("Argurment exception");
    }
}

