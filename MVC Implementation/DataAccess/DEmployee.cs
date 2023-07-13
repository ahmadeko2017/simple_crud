using System.Data;
using Microsoft.Data.SqlClient;
using MVC_Implementation.Models;

namespace MVC_Implementation.DataAccess;

public class DEmployee
{
    public Employee SelectById(int id)
    {
        Employee result = new Employee(0, "", "", "", "", DateTime.Now, 0, 0, 0, "", 0);
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM employees WHERE id = (@id)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Employee(reader.GetInt32("id"), reader.GetString("first_name"), reader.GetString("last_name") ?? "", reader.GetString("email"), reader.GetString("phone_number") ?? "", reader.GetDateTime("hire_date"), reader.GetInt32("salary"), reader.GetDecimal("commission_pct"), reader.GetInt32("manager_id"), reader.GetString("job_id"), reader.GetInt32("department_id"));
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

    public List<Employee> SelectAll()
    {
        List<Employee> results = new List<Employee>();
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "SELECT * FROM employees";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
                
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Employee(reader.GetInt32("id"), reader.GetString("first_name"), reader.GetString("last_name") ?? "", reader.GetString("email"), reader.GetString("phone_number") ?? "", reader.GetDateTime("hire_date"), reader.GetInt32("salary"), reader.GetDecimal("commission_pct"), reader.GetInt32("manager_id"), reader.GetString("job_id"), reader.GetInt32("department_id")));
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

    public int Insert(Employee employee)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "INSERT INTO employees VALUES (@id, @firstName ,@lastName, @email, @phoneNumber, @hireDate, @salary, @commissionPct, @managerId, @jobId, @departmentId)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", employee.Id);
            sqlCommand.Parameters.AddWithValue("@firstName", employee.FirsName);
            sqlCommand.Parameters.AddWithValue("@lastName", employee.LastName);
            sqlCommand.Parameters.AddWithValue("@email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@hireDate", employee.HireDate);
            sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
            sqlCommand.Parameters.AddWithValue("@commissionPct", employee.CommissionPct);
            sqlCommand.Parameters.AddWithValue("@managerId", employee.ManagerId);
            sqlCommand.Parameters.AddWithValue("@jobId", employee.JobId);
            sqlCommand.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
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

    public int Update(Employee employee)
    {
        int result = 0;
        var conStr = Connection.Get();
        using var connection = new SqlConnection(conStr);
        connection.Open();
        try
        {
            string query = "UPDATE employees SET first_name = @firstName ,last_name = @lastName, email = @email, phone_number = @phoneNumber, hire_date = @hireDate, salary = @salary, commission_pct = @commissionPct, manager_id = @managerId, job_id = @jobId, department_id = @departmentId WHERE id = (@id)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", employee.Id);
            sqlCommand.Parameters.AddWithValue("@firstName", employee.FirsName);
            sqlCommand.Parameters.AddWithValue("@lastName", employee.LastName);
            sqlCommand.Parameters.AddWithValue("@email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@hireDate", employee.HireDate);
            sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
            sqlCommand.Parameters.AddWithValue("@commissionPct", employee.CommissionPct);
            sqlCommand.Parameters.AddWithValue("@managerId", employee.ManagerId);
            sqlCommand.Parameters.AddWithValue("@jobId", employee.JobId);
            sqlCommand.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
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
            string query = "DELETE employees WHERE id = (@id)";
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