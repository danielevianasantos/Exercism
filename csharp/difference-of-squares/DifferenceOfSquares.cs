using System;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int summation=0,squareofsum=1;
        if (max > 1)
        {
            squareofsum = 0;
            for(int i=0;i<=max;i++)
                summation+=i;
            squareofsum = summation * summation;
        }
            

        return squareofsum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        int sum_fsquare = 1;
        if (max > 1)
        {
            sum_fsquare = 0;
            for (int i = 0; i <= max; i++)
                sum_fsquare += i*i;
        }
        return sum_fsquare;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}