using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    static int ammount =0;
    public static int Sum(IEnumerable<int> multiples, int max)
    {   int[] array = multiples.ToArray();
        int aux = max-1;
        if(array != null && array.FirstOrDefault() > 0)
        {
            try
                     {
                        aux = max - 1;
                            bool already = false;
                            while(aux>=array.Min()&&aux>0)
                            {
                                for(int i=0; i < array.Length; i++)
                                {
                                    if ((array[i]>0) &&(aux % array[i] == 0)&&!already)
                                    {
                                        ammount = ammount + aux;already = true;
                                    }
                            
                                }
                                aux--;
                                already = false;
                            }
                         return ammount;
                     }
                     catch (ArgumentException)
                     {
                         throw new ArgumentException("Argument exception");
                     }
        }
        else
            return ammount;
    }
}