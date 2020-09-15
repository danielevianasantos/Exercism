using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        int steps = 0;
        if(number>0)
        {
            int aux = number;
            do
            {
                if (aux % 2 == 0)
                    aux = aux / 2;
                else
                    aux = aux* 3 + 1;
                steps++;
            }while (aux > 1) ;
        return steps;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Error");
        }
    }
}