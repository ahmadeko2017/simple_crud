using MVC_Implementation.Models;
using MVC_Implementation.Utility;

namespace MVC_Implementation.View;

public class VEmployee
{
    public void GetAll(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            GetById(employee);
        }
    }
    public void GetById(Employee employee)
    {
        Console.WriteLine($" id = {employee.Id}");
        Console.WriteLine($" first_name = {employee.FirstName}");
        Console.WriteLine($" last_name = {employee.LastName}");
        Console.WriteLine($" email = {employee.Email}");
        Console.WriteLine($" phone_number = {employee.PhoneNumber}");
        Console.WriteLine($" hire_date = {employee.HireDate}");
        Console.WriteLine($" salary = {employee.Salary}");
        Console.WriteLine($" commission_pct = {employee.CommissionPct}");
        Console.WriteLine($" manager_id = {employee.ManagerId}");
        Console.WriteLine($" job_id = {employee.JobId}");
        Console.WriteLine($" department_id = {employee.DepartmentId}");
        Console.WriteLine("========================");
    }
    public int Menu()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("     EMPLOYEES TABLE");
        Console.WriteLine("========================");
        Console.WriteLine(" [1] Insert");
        Console.WriteLine(" [2] Update");
        Console.WriteLine(" [3] Delete");
        Console.WriteLine(" [4] GetById");
        Console.WriteLine(" [5] SelectAll");
        Console.WriteLine(" [6] Main Menu");
        Console.WriteLine("========================");
        Console.Write("Insert Your Choice : ");
        var input = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("========================");
        
        return input;
    }
    public Employee InsertMenu()
    {
        Console.WriteLine("Insert Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id : ");
        var firstName = GetInput.GetString("first_name : ");
        var lastName = GetInput.GetString("last_name : ");
        var email = GetInput.GetString("email : ");
        var phoneNumber = GetInput.GetString("phone_number : ");
        var hireDate = GetInput.GetDateTime("hire_date : ");
        var salary = GetInput.GetInt("salary : ");
        var commissionPct = GetInput.GetDecimal("commission_pct : ");
        var managerId = GetInput.GetInt("manager_id : ");
        var jobId = GetInput.GetString("job_id : ");
        var departmentId = GetInput.GetInt("department_id : ");

        return new Employee(id, firstName, lastName, email, phoneNumber, hireDate, salary, commissionPct, managerId, jobId, departmentId);
    }
    public Employee UpdateMenu()
    {
        Console.WriteLine("Update Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id : ");
        var firstName = GetInput.GetString("first_name : ");
        var lastName = GetInput.GetString("last_name : ");
        var email = GetInput.GetString("email : ");
        var phoneNumber = GetInput.GetString("phone_number : ");
        var hireDate = GetInput.GetDateTime("hire_date : ");
        var salary = GetInput.GetInt("salary : ");
        var commissionPct = GetInput.GetDecimal("commission_pct : ");
        var managerId = GetInput.GetInt("manager_id : ");
        var jobId = GetInput.GetString("job_id : ");
        var departmentId = GetInput.GetInt("department_id : ");

        return new Employee(id, firstName, lastName, email, phoneNumber, hireDate, salary, commissionPct, managerId, jobId, departmentId);
    }
    public int DeleteMenu()
    {
        Console.WriteLine("Delete Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id : ");

        return id;
    }
    public int GetByIdMenu()
    {
        Console.WriteLine("Search Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id : ");
        
        return id;
    }
    public void GetAllMenu()
    {
        Console.WriteLine("Search All Data");
        Console.WriteLine("===============");
    }
    public void DataEmpty()
    {
        Console.WriteLine("Data not Found!");
    }
    public void Success()
    {
        Console.WriteLine("Success!");
    }
    public void Failure()
    {
        Console.WriteLine("Fail, Id, not found!");
    }
    public void Error()
    {
        Console.WriteLine("Error retrieving from database!");
    }
}