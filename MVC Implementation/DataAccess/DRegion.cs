using System.Data;
using Microsoft.Data.SqlClient;
using MVC_Implementation.Models;

namespace MVC_Implementation.DataAccess;

public class DRegion
{
    public Region GetById(int id)
    {
        Region result = new Region(0, "");
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM regions WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Region(reader.GetInt32("id"), reader.GetString("name"));
                }
            }
            else
            {
                result = new Region(0, "failure");
            }
            reader.Close();
        }
        catch
        {
            result = new Region(0, "error");
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public List<Region> GetAll()
    {
        List<Region> results = new List<Region>();
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM regions";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Region(reader.GetInt32("id"), reader.GetString("name")));
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

    public int Insert(Region region)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "INSERT INTO locations VALUES (@name)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@name", region.Name);
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

    public int Update(Region region)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "UPDATE regions SET name = @name WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", region.Id);
            sqlCommand.Parameters.AddWithValue("@name", region.Name);
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
            string query = "DELETE regions WHERE id = @id";
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