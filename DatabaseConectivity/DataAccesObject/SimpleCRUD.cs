using System.Data;
using DatabaseConectivity.Object;
using Microsoft.Data.SqlClient;

namespace DatabaseConectivity.DataAccesObject;

public static class SimpleCrud
{
    private static string _server = "localhost";
    private static string _database = "db_test";

    private static string _connectionString = $"Server={_server};" +
                                              $"Database={_database};" +
                                              $"Integrated Security = true;" +
                                              $"TrustServerCertificate = true;";
    public static List<T> GetTable<T>(string table)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = $"SELECT * FROM {table}";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                // Console.WriteLine("Reader berjalan");
                switch (table)
                {
                    case "countries" :
                        List<Countries> countries = new List<Countries>();
                        while (reader.Read())
                        {
                            
                            var id = reader.GetString(0);
                            var name = reader.GetString(1);
                            var regionId = reader.GetInt32(2);
                            var country = new Countries(id, name, regionId);
                            countries.Add(country);
                        }
                        return (List<T>) Convert.ChangeType(countries, typeof(List<T>));
                    case "department" :
                        List<Departments> departments = new List<Departments>();
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var locationId = reader.GetInt32(2);
                            var managerId = reader.GetInt32(3);
                            var department = new Departments(id, name, locationId, managerId);
                            departments.Add(department);
                        }
                        return (List<T>) Convert.ChangeType(departments, typeof(List<T>));
                    case "employees" :
                        List<Employees> employees = new List<Employees>();
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var firstName = reader.GetString(1);
                            var lastName = reader.GetString(2);
                            var email = reader.GetString(3);
                            var phoneNumber = reader.GetString(4);
                            var hireDate = reader.GetDateTime(5);
                            var salary = reader.GetInt32(6);
                            var commisionPct = reader.GetDecimal(7);
                            var managerId = reader.GetInt32(8);
                            var jobId = reader.GetString(9);
                            var departmentId = reader.GetInt32(10);
                            var employee = new Employees(id, firstName, lastName, email, phoneNumber, hireDate, salary, commisionPct, managerId, jobId, departmentId);
                            employees.Add(employee);
                        }
                        return (List<T>) Convert.ChangeType(employees, typeof(List<T>));
                    case "histories" :
                        List<Histories> histories = new List<Histories>();
                        while (reader.Read())
                        {
                            var startDate = reader.GetDateTime(0);
                            var employeeId = reader.GetInt32(1);
                            var endDate = reader.GetDateTime(2);
                            var departmentId = reader.GetInt32(3);
                            var jobId = reader.GetString(4);
                            var history = new Histories(startDate, employeeId, endDate, departmentId, jobId);
                            histories.Add(history);
                        }
                        return (List<T>) Convert.ChangeType(histories, typeof(List<T>));
                    case "jobs" :
                        List<Jobs> jobs = new List<Jobs>();
                        while (reader.Read())
                        {
                            var id = reader.GetString(0);
                            var title = reader.GetString(1);
                            var minSalary = reader.GetInt32(2);
                            var maxSalary = reader.GetInt32(3);
                            var job = new Jobs(id, title, minSalary, maxSalary);
                            jobs.Add(job);
                        }
                        return (List<T>) Convert.ChangeType(jobs, typeof(List<T>));
                    case "locations" :
                        List<Locations> locations = new List<Locations>();
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var streetAddress = reader.GetString(1);
                            var postalCode = reader.GetString(2);
                            var city = reader.GetString(3);
                            var stateProvince = reader.GetString(4);
                            var countryId = reader.GetString(5);
                            var location = new Locations(id, streetAddress, postalCode, city, stateProvince, countryId);
                            locations.Add(location);
                        }
                        return (List<T>) Convert.ChangeType(locations, typeof(List<T>));
                    case "regions" :
                        List<Regions> regions = new List<Regions>();
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var region = new Regions(id, name);
                            regions.Add(region);
                        }
                        return (List<T>) Convert.ChangeType(regions, typeof(List<T>));
                }
                
            }
            else
            {
                Console.WriteLine("No table found.");
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error : {e}");
            Console.WriteLine("Error connecting to database.");
        }

        return null;
    }
    
    public static void InsertTable(string table, string name)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@name)";
        
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = name
            };
            sqlCommand.Parameters.Add(pName);
            
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }
            
            transaction.Commit();
            connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }
    
    public static void UpdateTable(string table, int id, string name)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = $"UPDATE {table} SET name = (@name) WHERE id = (@id)";
        
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = name
            };
            sqlCommand.Parameters.Add(pName);
            
            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id
            };
            sqlCommand.Parameters.Add(pId);
            
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }
            
            transaction.Commit();
            connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }
    public static void DeleteTable(string table, int id)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = $"DELETE {table} WHERE id = (@id)";
        
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id
            };
            sqlCommand.Parameters.Add(pId);
            
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }
            
            transaction.Commit();
            connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }
    public static void GetTableById(string table, int id)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = $"SELECT * FROM {table} WHERE id = (@id)";

        try
        {
            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id
            };
            sqlCommand.Parameters.Add(pId);
            
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No regions found.");
            }

            reader.Close();
            connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }
}