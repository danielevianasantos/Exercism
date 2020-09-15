using System;

public class Deque<T>
{
    public ItemLista<T> itemLista;

    public void Push(T value)
    {
        if (itemLista == null)
        {
            itemLista = new ItemLista<T> { Anterior = null, Proximo = null, Valor = value };
        }
        else
        {
            while (itemLista.Proximo != null)
            {
                itemLista = itemLista.Proximo;
            }

            ItemLista<T> novoItem = new ItemLista<T>() { Anterior = itemLista, Proximo = null, Valor = value };
            itemLista.Proximo = novoItem;
        }
    }

    public T Pop()
    {
        while (itemLista.Proximo != null)
        {
            itemLista = itemLista.Proximo;
        }

        var valor = itemLista.Valor;

        if (itemLista.Anterior != null)
        {
            itemLista = itemLista.Anterior;
        }
        itemLista.Proximo = null;

        return valor;

    }

    public void Unshift(T value)
    {
        if (itemLista == null)
        {
            itemLista = new ItemLista<T> { Anterior = null, Proximo = null, Valor = value };
        }
        else
        {
            while (itemLista.Anterior != null)
            {
                itemLista = itemLista.Anterior;
            }

            ItemLista<T> novoItem = new ItemLista<T>() { Anterior = null, Proximo = itemLista, Valor = value };
            itemLista.Anterior = novoItem;
        }
    }

    public T Shift()
    {
        while (itemLista.Anterior != null)
        {
            itemLista = itemLista.Anterior;
        }
        var valor = itemLista.Valor;


        if (itemLista.Proximo != null)
        {
            itemLista = itemLista.Proximo;
        }
        itemLista.Anterior = null;
        return valor;
    }
    public class ItemLista<T>
    {
        public ItemLista<T> Anterior { get; set; }

        public ItemLista<T> Proximo { get; set; }

        public T Valor { get; set; }
    }
}