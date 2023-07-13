using System.Data;
using Microsoft.Data.SqlClient;
using MVC_Implementation.Models;

namespace MVC_Implementation.DataAccess;

public class DJob
{
    public Job GetById(string id)
    {
        Job result = new Job("", "", 0, 0);
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM jobs WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Job(reader.GetString("id"), reader.GetString("title"), reader.GetInt32("min_salary"), reader.GetInt32("max_salary"));
                }
            }
            else
            {
                result = new Job("", "failure", 0, 0);
            }
            reader.Close();
        }
        catch
        {
            result = new Job("", "error", 0, 0);
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public List<Job> GetAll()
    {
        List<Job> results = new List<Job>();
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM jobs";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Job(reader.GetString("id"), reader.GetString("title"), reader.GetInt32("min_salary"), reader.GetInt32("max_salary")));
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

    public int Insert(Job job)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "INSERT INTO departments VALUES (@id, @title, @minSalary, @maxSalary)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", job.Id);
            sqlCommand.Parameters.AddWithValue("@title", job.Title);
            sqlCommand.Parameters.AddWithValue("@minSalary", job.MinSalary);
            sqlCommand.Parameters.AddWithValue("@maxSalary", job.MaxSalary);
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

    public int Update(Job job)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "UPDATE jobs SET title = @title, min_salary = @minSalary, max_salary = @maxSalary  WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", job.Id);
            sqlCommand.Parameters.AddWithValue("@title", job.Title);
            sqlCommand.Parameters.AddWithValue("@minSalary", job.MinSalary);
            sqlCommand.Parameters.AddWithValue("@maxSalary", job.MaxSalary);
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

    public int Delete(string id)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "DELETE jobs WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
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