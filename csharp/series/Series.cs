using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    private const int V = 1;
    static string[] slices; 
    public static string[] Slices(string numbers, int sliceLength)
    { 
        var parts = new List<string>();
        try
        {
            if((numbers!="")&&(sliceLength>0)&&(numbers.Length>=sliceLength))
                switch (sliceLength)
            {
                case 1:
                    {
                        var aux = new string[numbers.Length];
                        for (int i = 0; i < numbers.Length; i++)
                        { 
                            aux[i]=(numbers.Substring(i));
                        }
                        for (int i = 0; i < numbers.Length-1; i++)
                        {
                           aux[i] = aux[i].Substring(0, 1);
                        }
                        slices = aux;
                        break; 
                    }
                case 2:
                    {
                        
                        int j = 0, k=0;
                        if((numbers.Length-1)== 1)
                        {
                            var aux = new string[numbers.Length / 2];
                            while (j < numbers.Length)
                            {
                                aux[k] = (numbers.Substring(j));
                                k++;
                                j += 2;
                            }

                            for (int i = 0; i < aux.Length - 1; i++)
                            {
                                aux[i] = aux[i].Substring(0, 2);
                            }
                            slices = aux;
                        }
                        else
                        {
                            var aux = new string[numbers.Length-1];
                            while (j < numbers.Length-1)
                            {
                                aux[j] = (numbers.Substring(j));
                                j ++;
                            }

                            for (int i = 0; i <= aux.Length - 2; i++)
                            {
                                aux[i] = aux[i].Substring(0,2);
                            }
                            slices = aux;
                        }
                        
                        break;
                    }
                case 3:
                    {

                        int j = 0, k = 0;
                        if ((numbers.Length - 2) == 1)
                        {
                            var aux = new string[numbers.Length -2];
                            while (j < numbers.Length)
                            {
                                aux[k] = (numbers.Substring(j));
                                k++;
                                j += 3;
                            }
                            slices = aux;
                        }
                        else
                        {
                            var aux = new string[numbers.Length - 2];
                            while (j < numbers.Length - 2)
                            {
                                aux[j] = (numbers.Substring(j));
                                j++;
                            }

                            for (int i = 0; i <= aux.Length - 2; i++)
                            {
                                aux[i] = aux[i].Substring(0, 3);
                            }
                            slices = aux;
                        }

                        break;
                    }
                    case 5:
                        {

                            int j = 0, k = 0;
                            if ((numbers.Length - 4) == 1)
                            {
                                var aux = new string[numbers.Length - 4];
                                while (j < numbers.Length)
                                {
                                    aux[k] = (numbers.Substring(j));
                                    k++;
                                    j += 5;
                                }
                                slices = aux;
                            }
                            else
                            {
                                var aux = new string[numbers.Length - 4];
                                while (j < numbers.Length - 4)
                                {
                                    aux[j] = (numbers.Substring(j));
                                    j++;
                                }

                                for (int i = 0; i <= aux.Length - 2; i++)
                                {
                                    aux[i] = aux[i].Substring(0, 5);
                                }
                                slices = aux;
                            }

                            break;
                        }
                }
            else
                throw new ArgumentException("Error");


            return slices;
        }
        catch(ArgumentException)
        {
            throw new ArgumentException("Error");
        }

    }
}