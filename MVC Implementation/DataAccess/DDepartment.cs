using System.Data;
using Microsoft.Data.SqlClient;
using MVC_Implementation.Models;

namespace MVC_Implementation.DataAccess;

public class DDepartment
{
    public Department GetById(int id)
    {
        Department result = new Department(0, "", 0, 0);
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM departments WHERE id = (@id)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Department(reader.GetInt32("id"), reader.GetString("name"), reader.GetInt32("location_id"), reader.GetInt32("manager_id"));
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
        return result;
    }

    public List<Department> GetAll()
    {
        List<Department> results = new List<Department>();
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM departments";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Department(reader.GetInt32("id"), reader.GetString("name"), reader.GetInt32("location_id"), reader.GetInt32("manager_id")));
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

    public int Insert(Department department)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "INSERT INTO departments VALUES (@id, @name, @locationId, @managerId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", department.Id);
            sqlCommand.Parameters.AddWithValue("@name", department.Name);
            sqlCommand.Parameters.AddWithValue("@locationId", department.LocationId);
            sqlCommand.Parameters.AddWithValue("@managerId", department.ManagerId);
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

    public int Update(Department department)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "UPDATE departments SET  name = @name, location_id = @locationId, manager_id = @manager_id WHERE id = (@id)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", department.Id);
            sqlCommand.Parameters.AddWithValue("@name", department.Name);
            sqlCommand.Parameters.AddWithValue("@locationId", department.LocationId);
            sqlCommand.Parameters.AddWithValue("@managerId", department.ManagerId);
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

    public int Delete(int id)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "DELETE departments WHERE id = (@id)";
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