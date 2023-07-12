using System.Data;
using DatabaseConectivity.Object;
using Microsoft.Data.SqlClient;

namespace DatabaseConectivity.DataAccessObject;

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
                            var commissionPct = reader.GetDecimal(7);
                            var managerId = reader.GetInt32(8);
                            var jobId = reader.GetString(9);
                            var departmentId = reader.GetInt32(10);
                            var employee = new Employees(id, firstName, lastName, email, phoneNumber, hireDate, salary, commissionPct, managerId, jobId, departmentId);
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
    
    public static void InsertTable(string table, string? idStr = default, int idInt = default, string? name = default, 
        int regionId = default, int locationId = default, int managerId = default, string? firstName = default, string? lastName = default, string? email = default, string? phoneNumber = default, DateTime hireDate = default, int salary = default, decimal commissionPct = default, string? jobId = default, int departmentId = default, DateTime startDate = default, int employeeId = default, DateTime endDate = default, string? title = default, int minSalary = default, int maxSalary = default, string? streetAddress = default, string? postalCode = default, string? city = default, string? stateProvince = default, string? countryId = default)
    
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pJobId;
            SqlParameter pId;
            SqlParameter pDepartmentId;
            SqlParameter pName;
            SqlParameter pManagerId;
            switch (table)
            {
                case "countries" :
                    sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@id, @name, @regionId)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    pName = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };
                    sqlCommand.Parameters.Add(pName);
                    
                    SqlParameter pRegionId = new SqlParameter
                    {
                        ParameterName = "@locationId",
                        SqlDbType = SqlDbType.Int,
                        Value = locationId
                    };
                    sqlCommand.Parameters.Add(pRegionId);
                    break;
                case "departments" :
                    sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@id, @name, @locationId, @managerId)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    pName = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };
                    sqlCommand.Parameters.Add(pName);
                    
                    SqlParameter pLocationId = new SqlParameter
                    {
                        ParameterName = "@locationId",
                        SqlDbType = SqlDbType.Int,
                        Value = locationId
                    };
                    sqlCommand.Parameters.Add(pLocationId);
                    
                    pManagerId = new SqlParameter
                    {
                        ParameterName = "@locationId",
                        SqlDbType = SqlDbType.Int,
                        Value = managerId
                    };
                    sqlCommand.Parameters.Add(pManagerId);

                    break;
                case "employees" :
                    sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@id, @firstName, @lastName, @email, @phoneNumber, @hireDate, @salary, @commissionPct, @managerId, @jobId, @departmentId)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    SqlParameter pFirstName = new SqlParameter
                    {
                        ParameterName = "@firstName",
                        SqlDbType = SqlDbType.VarChar,
                        Value = firstName
                    };
                    sqlCommand.Parameters.Add(pFirstName);
                    
                    SqlParameter pLastName = new SqlParameter
                    {
                        ParameterName = "@lastName",
                        SqlDbType = SqlDbType.VarChar,
                        Value = lastName
                    };
                    sqlCommand.Parameters.Add(pLastName);
                    
                    SqlParameter pEmail = new SqlParameter
                    {
                        ParameterName = "@email",
                        SqlDbType = SqlDbType.VarChar,
                        Value = email
                    };
                    sqlCommand.Parameters.Add(pEmail);
                    
                    SqlParameter pPhoneNumber = new SqlParameter
                    {
                        ParameterName = "@phoneNumber",
                        SqlDbType = SqlDbType.VarChar,
                        Value = phoneNumber
                    };
                    sqlCommand.Parameters.Add(pPhoneNumber);
                    
                    SqlParameter pHireDate = new SqlParameter
                    {
                        ParameterName = "@hireDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = hireDate
                    };
                    sqlCommand.Parameters.Add(pHireDate);
                    
                    SqlParameter pSalary = new SqlParameter
                    {
                        ParameterName = "@salary",
                        SqlDbType = SqlDbType.Int,
                        Value = salary
                    };
                    sqlCommand.Parameters.Add(pSalary);
                    
                    SqlParameter pCommissionPct = new SqlParameter
                    {
                        ParameterName = "@commissionPct",
                        SqlDbType = SqlDbType.Decimal,
                        Value = commissionPct
                    };
                    sqlCommand.Parameters.Add(pCommissionPct);
                    
                    pManagerId = new SqlParameter
                    {
                        ParameterName = "@managerId",
                        SqlDbType = SqlDbType.Int,
                        Value = managerId
                    };
                    sqlCommand.Parameters.Add(pManagerId);
                    
                    pJobId = new SqlParameter
                    {
                        ParameterName = "@jobId",
                        // SqlDbType = SqlDbType.NChar,
                        Value = jobId
                    };
                    sqlCommand.Parameters.Add(pJobId);
                    
                    pDepartmentId = new SqlParameter
                    {
                        ParameterName = "@departmentId",
                        SqlDbType = SqlDbType.Int,
                        Value = departmentId
                    };
                    sqlCommand.Parameters.Add(pDepartmentId);
                    break;
                case "histories" :
                    sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@startDate, @employeeID, @endDate, @departmentId, @jobId)";
                    SqlParameter pStartDate = new SqlParameter
                    {
                        ParameterName = "@startDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = startDate
                    };
                    sqlCommand.Parameters.Add(pStartDate);
                    
                    SqlParameter pEmployeeId = new SqlParameter
                    {
                        ParameterName = "@employeeId",
                        SqlDbType = SqlDbType.Int,
                        Value = employeeId
                    };
                    sqlCommand.Parameters.Add(pEmployeeId);
                    
                    SqlParameter pEndDate = new SqlParameter
                    {
                        ParameterName = "@endDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = endDate
                    };
                    sqlCommand.Parameters.Add(pEndDate);
                    
                    pDepartmentId = new SqlParameter
                    {
                        ParameterName = "@departmentId",
                        SqlDbType = SqlDbType.Int,
                        Value = departmentId
                    };
                    sqlCommand.Parameters.Add(pDepartmentId);
                    
                    pJobId = new SqlParameter
                    {
                        ParameterName = "@jobId",
                        SqlDbType = SqlDbType.VarChar,
                        Value = jobId
                    };
                    sqlCommand.Parameters.Add(pJobId);
                    break;
                case "jobs" :
                    sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@id, @title, @minSalary, @maxSalary)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    SqlParameter pTitle = new SqlParameter
                    {
                        ParameterName = "@title",
                        SqlDbType = SqlDbType.VarChar,
                        Value = title
                    };
                    sqlCommand.Parameters.Add(pTitle);
                    
                    SqlParameter pMinSalary = new SqlParameter
                    {
                        ParameterName = "@minSalary",
                        SqlDbType = SqlDbType.Int,
                        Value = minSalary
                    };
                    sqlCommand.Parameters.Add(pMinSalary);
                    
                    SqlParameter pMaxSalary = new SqlParameter
                    {
                        ParameterName = "@maxSalary",
                        SqlDbType = SqlDbType.Int,
                        Value = maxSalary
                    };
                    sqlCommand.Parameters.Add(pMaxSalary);
                    
                    break;
                case "locations" :
                    sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@id, @streetAddress, @postalCode, @city, @stateProvince, @countryId)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    SqlParameter pStreetAddress = new SqlParameter
                    {
                        ParameterName = "@streetAddress",
                        SqlDbType = SqlDbType.VarChar,
                        Value = streetAddress
                    };
                    sqlCommand.Parameters.Add(pStreetAddress);
                    
                    SqlParameter pPostalCode = new SqlParameter
                    {
                        ParameterName = "@postalCode",
                        SqlDbType = SqlDbType.VarChar,
                        Value = postalCode
                    };
                    sqlCommand.Parameters.Add(pPostalCode);
                    
                    SqlParameter pCity = new SqlParameter
                    {
                        ParameterName = "@city",
                        SqlDbType = SqlDbType.VarChar,
                        Value = city
                    };
                    sqlCommand.Parameters.Add(pCity);
                    
                    SqlParameter pStateProvince = new SqlParameter
                    {
                        ParameterName = "@stateProvince",
                        SqlDbType = SqlDbType.VarChar,
                        Value = stateProvince
                    };
                    sqlCommand.Parameters.Add(pStateProvince);
                    
                    SqlParameter pCountryId = new SqlParameter
                    {
                        ParameterName = "@countryId",
                        SqlDbType = SqlDbType.VarChar,
                        Value = countryId
                    };
                    sqlCommand.Parameters.Add(pCountryId);
                    break;
                case "regions" :
                    sqlCommand.CommandText = $"INSERT INTO {table} VALUES (@name)";
                    pName = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };
                    sqlCommand.Parameters.Add(pName);
                    break;
            }
            
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
    
    public static void UpdateTable(string table, string? idStr = default, int idInt = default, string? name = default, 
        int regionId = default, int locationId = default, int managerId = default, string? firstName = default, string? lastName = default, string? email = default, string? phoneNumber = default, DateTime hireDate = default, int salary = default, decimal commissionPct = default, string? jobId = default, int departmentId = default, DateTime startDate = default, int employeeId = default, DateTime endDate = default, string? title = default, int minSalary = default, int maxSalary = default, string? streetAddress = default, string? postalCode = default, string? city = default, string? stateProvince = default, string? countryId = default)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pJobId;
            SqlParameter pId;
            SqlParameter pDepartmentId;
            SqlParameter pName;
            SqlParameter pManagerId;
            switch (table)
            {
                case "countries" :
                    sqlCommand.CommandText = $"UPDATE {table} SET name = @name, region_id =  @regionId WHERE id = (@id)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    pName = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };
                    sqlCommand.Parameters.Add(pName);
                    
                    SqlParameter pRegionId = new SqlParameter
                    {
                        ParameterName = "@locationId",
                        SqlDbType = SqlDbType.Int,
                        Value = locationId
                    };
                    sqlCommand.Parameters.Add(pRegionId);
                    break;
                case "departments" :
                    sqlCommand.CommandText = $"UPDATE {table} SET name = @name, location_id = @locationId, manager_id = @managerId WHERE id = (@id)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    pName = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };
                    sqlCommand.Parameters.Add(pName);
                    
                    SqlParameter pLocationId = new SqlParameter
                    {
                        ParameterName = "@locationId",
                        SqlDbType = SqlDbType.Int,
                        Value = locationId
                    };
                    sqlCommand.Parameters.Add(pLocationId);
                    
                    pManagerId = new SqlParameter
                    {
                        ParameterName = "@locationId",
                        SqlDbType = SqlDbType.Int,
                        Value = managerId
                    };
                    sqlCommand.Parameters.Add(pManagerId);

                    break;
                case "employees" :
                    sqlCommand.CommandText = $"UPDATE {table} SET first_name = @firstName, last_name = @lastName, email = @email, phone_number = @phoneNumber, hire_date = @hireDate, salary = @salary, commission_pct = @commissionPct, manager_id = @managerId, job_id = @jobId, department_id = @departmentId WHERE id = (@id)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    SqlParameter pFirstName = new SqlParameter
                    {
                        ParameterName = "@firstName",
                        SqlDbType = SqlDbType.VarChar,
                        Value = firstName
                    };
                    sqlCommand.Parameters.Add(pFirstName);
                    
                    SqlParameter pLastName = new SqlParameter
                    {
                        ParameterName = "@lastName",
                        SqlDbType = SqlDbType.VarChar,
                        Value = lastName
                    };
                    sqlCommand.Parameters.Add(pLastName);
                    
                    SqlParameter pEmail = new SqlParameter
                    {
                        ParameterName = "@email",
                        SqlDbType = SqlDbType.VarChar,
                        Value = email
                    };
                    sqlCommand.Parameters.Add(pEmail);
                    
                    SqlParameter pPhoneNumber = new SqlParameter
                    {
                        ParameterName = "@phoneNumber",
                        SqlDbType = SqlDbType.VarChar,
                        Value = phoneNumber
                    };
                    sqlCommand.Parameters.Add(pPhoneNumber);
                    
                    SqlParameter pHireDate = new SqlParameter
                    {
                        ParameterName = "@hireDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = hireDate
                    };
                    sqlCommand.Parameters.Add(pHireDate);
                    
                    SqlParameter pSalary = new SqlParameter
                    {
                        ParameterName = "@salary",
                        SqlDbType = SqlDbType.Int,
                        Value = salary
                    };
                    sqlCommand.Parameters.Add(pSalary);
                    
                    SqlParameter pCommissionPct = new SqlParameter
                    {
                        ParameterName = "@commissionPct",
                        SqlDbType = SqlDbType.Decimal,
                        Value = commissionPct
                    };
                    sqlCommand.Parameters.Add(pCommissionPct);
                    
                    pManagerId = new SqlParameter
                    {
                        ParameterName = "@managerId",
                        SqlDbType = SqlDbType.Int,
                        Value = managerId
                    };
                    sqlCommand.Parameters.Add(pManagerId);
                    
                    pJobId = new SqlParameter
                    {
                        ParameterName = "@jobId",
                        // SqlDbType = SqlDbType.NChar,
                        Value = jobId
                    };
                    sqlCommand.Parameters.Add(pJobId);
                    
                    pDepartmentId = new SqlParameter
                    {
                        ParameterName = "@departmentId",
                        SqlDbType = SqlDbType.Int,
                        Value = departmentId
                    };
                    sqlCommand.Parameters.Add(pDepartmentId);
                    break;
                case "histories" :
                    sqlCommand.CommandText = $"UPDATE {table} SET end_date = @endDate, department_id = @departmentId, job_id = @jobId WHERE start_date = (@startDate) AND employee_id = (@employeeId)";
                    SqlParameter pStartDate = new SqlParameter
                    {
                        ParameterName = "@startDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = startDate
                    };
                    sqlCommand.Parameters.Add(pStartDate);
                    
                    SqlParameter pEmployeeId = new SqlParameter
                    {
                        ParameterName = "@employeeId",
                        SqlDbType = SqlDbType.Int,
                        Value = employeeId
                    };
                    sqlCommand.Parameters.Add(pEmployeeId);
                    
                    SqlParameter pEndDate = new SqlParameter
                    {
                        ParameterName = "@endDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = endDate
                    };
                    sqlCommand.Parameters.Add(pEndDate);
                    
                    pDepartmentId = new SqlParameter
                    {
                        ParameterName = "@departmentId",
                        SqlDbType = SqlDbType.Int,
                        Value = departmentId
                    };
                    sqlCommand.Parameters.Add(pDepartmentId);
                    
                    pJobId = new SqlParameter
                    {
                        ParameterName = "@jobId",
                        SqlDbType = SqlDbType.VarChar,
                        Value = jobId
                    };
                    sqlCommand.Parameters.Add(pJobId);
                    break;
                case "jobs" :
                    sqlCommand.CommandText = $"UPDATE {table} SET title = @title, @minSalary, @maxSalary WHERE id = (@id)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    SqlParameter pTitle = new SqlParameter
                    {
                        ParameterName = "@title",
                        SqlDbType = SqlDbType.VarChar,
                        Value = title
                    };
                    sqlCommand.Parameters.Add(pTitle);
                    
                    SqlParameter pMinSalary = new SqlParameter
                    {
                        ParameterName = "@minSalary",
                        SqlDbType = SqlDbType.Int,
                        Value = minSalary
                    };
                    sqlCommand.Parameters.Add(pMinSalary);
                    
                    SqlParameter pMaxSalary = new SqlParameter
                    {
                        ParameterName = "@maxSalary",
                        SqlDbType = SqlDbType.Int,
                        Value = maxSalary
                    };
                    sqlCommand.Parameters.Add(pMaxSalary);
                    
                    break;
                case "locations" :
                    sqlCommand.CommandText = $"UPDATE {table} SET street_address = @streetAddress, postal_code = @postalCode, city = @city, state_province = @stateProvince, country_id = @countryId WHERE id = (@id)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idInt
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    SqlParameter pStreetAddress = new SqlParameter
                    {
                        ParameterName = "@streetAddress",
                        SqlDbType = SqlDbType.VarChar,
                        Value = streetAddress
                    };
                    sqlCommand.Parameters.Add(pStreetAddress);
                    
                    SqlParameter pPostalCode = new SqlParameter
                    {
                        ParameterName = "@postalCode",
                        SqlDbType = SqlDbType.VarChar,
                        Value = postalCode
                    };
                    sqlCommand.Parameters.Add(pPostalCode);
                    
                    SqlParameter pCity = new SqlParameter
                    {
                        ParameterName = "@city",
                        SqlDbType = SqlDbType.VarChar,
                        Value = city
                    };
                    sqlCommand.Parameters.Add(pCity);
                    
                    SqlParameter pStateProvince = new SqlParameter
                    {
                        ParameterName = "@stateProvince",
                        SqlDbType = SqlDbType.VarChar,
                        Value = stateProvince
                    };
                    sqlCommand.Parameters.Add(pStateProvince);
                    
                    SqlParameter pCountryId = new SqlParameter
                    {
                        ParameterName = "@countryId",
                        SqlDbType = SqlDbType.VarChar,
                        Value = countryId
                    };
                    sqlCommand.Parameters.Add(pCountryId);
                    break;
                case "regions" :
                    sqlCommand.CommandText = $"UPDATE {table} SET @name WHERE id = (@id)";
                    pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.VarChar,
                        Value = idStr
                    };
                    sqlCommand.Parameters.Add(pId);
                    
                    pName = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Value = name
                    };
                    sqlCommand.Parameters.Add(pName);
                    break;
            }
            
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
    public static void DeleteTable(string table, int id = default, DateTime startDate = default, int employeeId = default)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            switch (table)
            {
                case "histories" :
                    sqlCommand.CommandText = $"DELETE {table} WHERE start_date = (@startDate) AND employee_id = (@employeeId)";
                    SqlParameter pStartDate = new SqlParameter
                    {
                        ParameterName = "@startDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = startDate
                    };
                    sqlCommand.Parameters.Add(pStartDate);
                    
                    SqlParameter pEmployeeId = new SqlParameter
                    {
                        ParameterName = "@employeeId",
                        SqlDbType = SqlDbType.Int,
                        Value = employeeId
                    };
                    sqlCommand.Parameters.Add(pEmployeeId);
                    break;
                default:
                    sqlCommand.CommandText = $"DELETE {table} WHERE id = (@id)";
                    SqlParameter pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = id
                    };
                    sqlCommand.Parameters.Add(pId);
                    break;
            }
            
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
    public static T GetTableById<T>(string table, int idTable = default, DateTime startDate = default, int employeeId = default)
    {
        var connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;

        try
        {
            switch (table)
            {
                case "histories" :
                    sqlCommand.CommandText = $"SELECT * FROM {table} WHERE start_date = (@startDate) AND employee_id = (@employeeId)";
                    SqlParameter pStartDate = new SqlParameter
                    {
                        ParameterName = "@startDate",
                        SqlDbType = SqlDbType.DateTime,
                        Value = startDate
                    };
                    sqlCommand.Parameters.Add(pStartDate);
                    
                    SqlParameter pEmployeeId = new SqlParameter
                    {
                        ParameterName = "@employeeId",
                        SqlDbType = SqlDbType.Int,
                        Value = employeeId
                    };
                    sqlCommand.Parameters.Add(pEmployeeId);
                    break;
                default:
                    sqlCommand.CommandText = $"SELECT * FROM {table} WHERE id = (@id)";
                    SqlParameter pId = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = idTable
                    };
                    sqlCommand.Parameters.Add(pId);
                    break;
            }
            
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                switch (table)
                {
                    case "countries" :
                        while (reader.Read())
                        {
                            
                            var id = reader.GetString(0);
                            var name = reader.GetString(1);
                            var regionId = reader.GetInt32(2);
                            var country = new Countries(id, name, regionId);
                            return (T) Convert.ChangeType(country, typeof(T));
                        }
                        break;

                    case "department" :
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var locationId = reader.GetInt32(2);
                            var managerId = reader.GetInt32(3);
                            var department = new Departments(id, name, locationId, managerId);
                            return (T) Convert.ChangeType(department, typeof(T));
                        }
                        break;
                    case "employees" :
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var firstName = reader.GetString(1);
                            var lastName = reader.GetString(2);
                            var email = reader.GetString(3);
                            var phoneNumber = reader.GetString(4);
                            var hireDate = reader.GetDateTime(5);
                            var salary = reader.GetInt32(6);
                            var commissionPct = reader.GetDecimal(7);
                            var managerId = reader.GetInt32(8);
                            var jobId = reader.GetString(9);
                            var departmentId = reader.GetInt32(10);
                            var employee = new Employees(id, firstName, lastName, email, phoneNumber, hireDate, salary, commissionPct, managerId, jobId, departmentId);
                            return (T) Convert.ChangeType(employee, typeof(List<T>));
                        }
                        break;
                    case "histories" :
                        while (reader.Read())
                        {
                            startDate = reader.GetDateTime(0);
                            employeeId = reader.GetInt32(1);
                            var endDate = reader.GetDateTime(2);
                            var departmentId = reader.GetInt32(3);
                            var jobId = reader.GetString(4);
                            var history = new Histories(startDate, employeeId, endDate, departmentId, jobId);
                            return (T) Convert.ChangeType(history, typeof(T));
                        }
                        break;
                    case "jobs" :
                        while (reader.Read())
                        {
                            var id = reader.GetString(0);
                            var title = reader.GetString(1);
                            var minSalary = reader.GetInt32(2);
                            var maxSalary = reader.GetInt32(3);
                            var job = new Jobs(id, title, minSalary, maxSalary);
                            return (T) Convert.ChangeType(job, typeof(T));
                        }
                        break;
                    case "locations" :
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var streetAddress = reader.GetString(1);
                            var postalCode = reader.GetString(2);
                            var city = reader.GetString(3);
                            var stateProvince = reader.GetString(4);
                            var countryId = reader.GetString(5);
                            var location = new Locations(id, streetAddress, postalCode, city, stateProvince, countryId);
                            return (T) Convert.ChangeType(location, typeof(T));
                        }
                        break;
                    case "regions" :
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var region = new Regions(id, name);
                            return (T) Convert.ChangeType(region, typeof(T));
                        }
                        break;
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

        return default(T);
    }
}