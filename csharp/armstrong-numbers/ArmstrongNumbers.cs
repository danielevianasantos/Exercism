using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        //bool result=false;
        //if (number <= 9)
        //    result = true;
        //else
        //{
        //    var digits= new int [(int)Math.Log10(number)+1];
        //    for(int i=0;i<digits.Length;i++)
        //    {
        //        digits[i] = (int)Math.Log10(number);
        //        number -= digits[i]*(int)Math.Pow(10, digits[i]);

        //    }
        //}
        //return result;
        var aux = Convert.ToString(number);
        var aux1 = new char[aux.Length];
        bool result = false;
        if (number <= 9)
            result = true;
        else
        {
            for (int i = 0; i < aux.Length - 1; i++)
            {
                aux[i] = aux[i].Substring(0, 1);
            }
            slices = aux;
            break;
        }
        return result;
    }
}