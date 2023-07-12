namespace DatabaseConectivity.Utility;

public static class GetInput
{
    public static int GetInt(string text)
    {
        while (true)
        {
            Console.Write(text);
            try
            {
                var input = Console.ReadLine();
                if (input != null) return Int32.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Insert allowed number . . .");
            }
        }
    }
    public static Decimal GetDecimal(string text)
    {
        while (true)
        {
            Console.Write(text);
            try
            {
                var input = Console.ReadLine();
                if (input != null) return Decimal.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Insert allowed number . . .");
            }
        }
    }
    
    public static string GetString(string text)
    {
        string? name;
        while (true)
        {
            Console.Write(text);
            name = Console.ReadLine();
            if (name != null && name.Length >= 2)
            {
                break;
            }
            else
            {
                Console.WriteLine("Insert at Least 2 Character . . .");
            }
        }

        return name;
    }
    
    public static DateTime GetDateTime(string text)
    {
        string? name;
        while (true)
        {
            Console.Write(text);
            name = Console.ReadLine();
            if (name != null && name.Length >= 2)
            {
                try
                {
                    return DateTime.Parse(name);
                }
                catch 
                {
                    Console.WriteLine("Use this format : yyyy-MM-dd HH:mm:ss");
                }
            }
            else
            {
                Console.WriteLine("Insert at Least 2 Character . . .");
            }
        }
    }
}