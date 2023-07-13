using System.Data;
using Microsoft.Data.SqlClient;
using MVC_Implementation.Models;

namespace MVC_Implementation.DataAccess;

public class DHistory
{
    public History GetById(DateTime startDate, int employeeId)
    {
        History result = new History(DateTime.Now, 0, DateTime.Now, 0, "");
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM histories WHERE start_date = @startDate AND employee_id = @employeeId";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@startDate", startDate);
            sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new History(reader.GetDateTime("start_date"), reader.GetInt32("employee_id"), reader.GetDateTime("end_date"), reader.GetInt32("department_id"), reader.GetString("job_id"));
                }
            }
            else
            {
                result = new History(DateTime.Now, 0, DateTime.Now, 0, "failure");
            }
            reader.Close();
        }
        catch
        {
            result = new History(DateTime.Now, 0, DateTime.Now, 0, "error");
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public List<History> GetAll()
    {
        List<History> results = new List<History>();
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM histories";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new History(reader.GetDateTime("start_date"), reader.GetInt32("employee_id"), reader.GetDateTime("end_date"), reader.GetInt32("department_id"), reader.GetString("job_id")));
                }
            }
            reader.Close();
        }
        catch
        {
            // ignored
        }
        finally
        {
            connection.Close();
        }
        return results;
    }

    public int Insert(History history)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "INSERT INTO histories VALUES (@startDate, @employeeId, @endDate, @departmentId, @jobId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@startDate", history.StartDate);
            sqlCommand.Parameters.AddWithValue("@employeeId", history.EmployeeId);
            sqlCommand.Parameters.AddWithValue("@endDate", history.EndDate);
            sqlCommand.Parameters.AddWithValue("@departmentId", history.DepartmentId);
            sqlCommand.Parameters.AddWithValue("@jobId", history.JobId);
            result = sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            result = -1;
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public int Update(History history)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "UPDATE histories SET end_date = @endDate, department_id = @departmentId, job_id = @jobId WHERE start_date = @startDate AND employee_id = @employeeId";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@startDate", history.StartDate);
            sqlCommand.Parameters.AddWithValue("@employeeId", history.EmployeeId);
            sqlCommand.Parameters.AddWithValue("@endDate", history.EndDate);
            sqlCommand.Parameters.AddWithValue("@departmentId", history.DepartmentId);
            sqlCommand.Parameters.AddWithValue("@jobId", history.JobId);
            result = sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            result = -1;
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public int Delete(DateTime startDate, int employeeId)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "DELETE histories WHERE start_date = @startDate AND employee_id = @employeeId";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@startDate", startDate);
            sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
            result = sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            result = -1;
        }
        finally
        {
            connection.Close();
        }
        return result;
    }
}