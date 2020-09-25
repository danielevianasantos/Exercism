using System;
using System.Collections.Generic;
using System.Linq;

public class Reactor
{
    public InputCell CreateInputCell(int value)
    {
        var inputCell = new InputCell();
        inputCell.Value = value;
        return inputCell;
    }

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute)
    {
        var retorno = new ComputeCell();
        int[] vetor = new int[producers.Count()];
        int i = 0;
        foreach (var item in producers)
        {
            vetor[i] = item.Value;
            i++;
        }

        retorno.Value = compute(vetor);
        yield return  retorno;
    }
}

public abstract class Cell
{public int Value { get; set; }
}

public class InputCell : Cell
{
    
}

public class ComputeCell : Cell
{
    public EventHandler<int> Changed { get; internal set; }
}