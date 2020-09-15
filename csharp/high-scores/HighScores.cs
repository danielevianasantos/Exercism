using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> _values;
    public HighScores(List<int> list) => _values = list;

    public List<int> Scores() =>  _values;

    public int Latest() => _values.Last();
    public int PersonalBest() =>  _values.Max();
    public List<int> PersonalTopThree()
    {
        var size_list = _values.Count() >= 3 ? 3 : _values.Count();
        var top = _values.OrderByDescending(x => x)
                  .Take(size_list)
                  .ToList();
        return top;
    }
}