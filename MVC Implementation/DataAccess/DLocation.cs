using System.Data;
using Microsoft.Data.SqlClient;
using MVC_Implementation.Models;

namespace MVC_Implementation.DataAccess;

public class DLocation
{
    public Location SelectById(int id)
    {
        Location result = new Location(0, "", "", "", "", "");
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM locations WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Location(reader.GetInt32("id"), reader.GetString("street_address"), reader.GetString("postal_code"), reader.GetString("city"), reader.GetString("state_province"), reader.GetString("country_id"));
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

    public List<Location> SelectAll()
    {
        List<Location> results = new List<Location>();
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM locations";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Location(reader.GetInt32("id"), reader.GetString("street_address"), reader.GetString("postal_code"), reader.GetString("city"), reader.GetString("state_province"), reader.GetString("country_id")));
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

    public int Insert(Location location)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "INSERT INTO locations VALUES (@id, @streetAddress, @postalCode, @city, @stateProvince, @countryId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", location.Id);
            sqlCommand.Parameters.AddWithValue("@streetAddress", location.StreetAddress);
            sqlCommand.Parameters.AddWithValue("@postalCode", location.PostalCode);
            sqlCommand.Parameters.AddWithValue("@city", location.City);
            sqlCommand.Parameters.AddWithValue("@stateProvince", location.StateProvince);
            sqlCommand.Parameters.AddWithValue("@countryId", location.CountryId);
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

    public int Update(Location location)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "UPDATE locations SET street_address = @streetAddress, postal_code = @postalCode, city = @city, state_province = @stateProvince, country_id = @countryId WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", location.Id);
            sqlCommand.Parameters.AddWithValue("@streetAddress", location.StreetAddress);
            sqlCommand.Parameters.AddWithValue("@postalCode", location.PostalCode);
            sqlCommand.Parameters.AddWithValue("@city", location.City);
            sqlCommand.Parameters.AddWithValue("@stateProvince", location.StateProvince);
            sqlCommand.Parameters.AddWithValue("@countryId", location.CountryId);
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
            string query = "DELETE locations WHERE id = @id";
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