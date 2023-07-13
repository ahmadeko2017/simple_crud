namespace MVC_Implementation.Models;

public static class Connection
{
    public static string Get(string server = "localhost", string database = "db_test")
    {
        return 
            $"Server={server};" + 
            $"Database={database};" + 
            $"Integrated Security = true;" + 
            $"TrustServerCertificate = true;";
    }
}