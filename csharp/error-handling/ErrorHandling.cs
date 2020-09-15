using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception("Error");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int number;
        if (int.TryParse(input, out number)) 
            return number;
        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        try
        {
            result = Int32.Parse(input);
            return true;
        }
        catch
        {
            result = 0;
            return false;
        }
           
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            disposableObject.Dispose();
        }
        finally
        {
            throw new Exception();
        }
    }
}
