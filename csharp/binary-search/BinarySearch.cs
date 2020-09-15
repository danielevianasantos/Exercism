using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int minNum = 0; 
        int maxNum = input.Length - 1, mid; 
        while (minNum <= maxNum && maxNum > 0) 
        { mid = (int)(minNum + maxNum) / 2; 
            if (value == input[mid]) 
            { return mid; } 
            else if (value < input[mid]) 
            { maxNum= mid - 1; } 
            else { minNum= mid + 1; 
            }
        }
        if (input.Length == 1)
            return 0;
        else return -1;
    }
}