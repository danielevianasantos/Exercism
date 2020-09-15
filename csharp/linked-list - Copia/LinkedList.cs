using System;
public class Item<T>
{
    public T ValueItem { get; set; }
    public Item<T> NextItem { get; set; }
    public Item<T> PreviousItem { get; set; }
}
public class Deque<T>
{
    private Item<T> first;


    public void Push(T value)
    {
        if (first == null)
        {
            first = new Item<T> { ValueItem = value };
            first.PreviousItem = null;
            first.NextItem = first;
            return;
        }
        Item<T> last = first;
        while (last.NextItem != null)
        {
            last = last.NextItem;
            //last.PreviousItem = last;
        }
        last.PreviousItem = last;
        last.NextItem = null;
        last = new Item<T> { ValueItem = value };
    }

    public T Pop()
    {
        if (first == null)
        {
            throw new ArgumentOutOfRangeException("Error");
        }
        Item<T> last = first;
        while (last.NextItem != null)
        {
            last.PreviousItem = last;
            last = last.NextItem;
        }
        var temp = last.ValueItem;
        last = null;
        return temp;
    }

    public void Unshift(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public T Shift()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
