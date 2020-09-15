using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean2(string phoneNumber)
    {
        string retorno = Regex.Replace(phoneNumber, @"\D", "");
        if (retorno[0] == '1')
            retorno = retorno.Substring(1);
        var valido = Regex.IsMatch(retorno, @"^[2-9][0-9]{2}[2-9][0-9]{6}$");
        if (!valido)
            throw new ArgumentException();
        return retorno;
    }
    public static string Clean(string phoneNumber)
    {
        bool verify_1=false;
        int verify_rest = 0;
        try
        {
            var char_array = phoneNumber.ToCharArray();
            bool prefix = false, go_on = false;
            var number = new char[10];
                for (int i = 0; i < char_array.Length; i++)
                {
                if ((char_array[i] == '+' || char_array[i] == '(')) ;
                else if (!prefix && phoneNumber.Length >= 11 && char_array[i] != '1')
                    throw new ArgumentException("Error");
                else if (!prefix && phoneNumber.Length >= 11 && (char_array[i] == '1' || char_array[i] == '+' || char_array[i] == '(') && !go_on)
                {
                    prefix = true;
                    go_on = true;
                }
                else if ((go_on || !prefix) && char_array[i] == '2' && !verify_1)
                {
                    verify_1 = true;
                    number[verify_rest] = char_array[i];
                    verify_rest++;
                    prefix = true;
                }
                else if (Char.IsDigit(char_array[i]))
                {
                    if ((char_array[i] == '0' || char_array[i] == '1' || char_array[i] == '2' || char_array[i] == '3' || char_array[i] == '4' ||
                            char_array[i] == '5' || char_array[i] == '6' || char_array[i] == '7' || char_array[i] == '8' ||
                            char_array[i] == '9') && verify_1)
                    {
                        number[verify_rest] = char_array[i];
                        verify_rest++;
                    }
                }
                else;
            }
            if (verify_1 && verify_rest >= 10)
                return new string(number);
            else
                throw new ArgumentException("Error");
        }
        catch(ArgumentException)
        {
            throw new ArgumentException("Error");
        }
    }
}