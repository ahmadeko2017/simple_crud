using MVC_Implementation.Models;
using MVC_Implementation.Utility;

namespace MVC_Implementation.View;

public class VHistory
{
    public void GetAll(List<History> histories)
    {
        foreach (var history in histories)
        {
            GetById(history);
        }
    }
    public void GetById(History history)
    {
        Console.WriteLine($" start_date = {history.StartDate}");
        Console.WriteLine($" employee_id = {history.EmployeeId}");
        Console.WriteLine($" end_date = {history.EndDate}");
        Console.WriteLine($" department_id = {history.DepartmentId}");
        Console.WriteLine($" job_id = {history.JobId}");
        Console.WriteLine("========================");
    }
    public int Menu()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("       HISTORY TABLE");
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
    public History InsertMenu()
    {
        Console.WriteLine("Insert Data");
        Console.WriteLine("===========");
        var startDate = GetInput.GetDateTime("start_date : ");
        var employeeId = GetInput.GetInt("employee_id : ");
        var endDate = GetInput.GetDateTime("end_date : ");
        var departmentId = GetInput.GetInt("department_id : ");
        var jobId = GetInput.GetString("job_id");

        return new History(startDate, employeeId, endDate, departmentId, jobId);
    }
    public History UpdateMenu()
    {
        Console.WriteLine("Update Data");
        Console.WriteLine("===========");
        var startDate = GetInput.GetDateTime("start_date : ");
        var employeeId = GetInput.GetInt("employee_id : ");
        var endDate = GetInput.GetDateTime("end_date : ");
        var departmentId = GetInput.GetInt("department_id : ");
        var jobId = GetInput.GetString("job_id");

        return new History(startDate, employeeId, endDate, departmentId, jobId);
    }
    public (DateTime, int) DeleteMenu()
    {
        Console.WriteLine("Delete Data");
        Console.WriteLine("===========");
        var startDate = GetInput.GetDateTime("start_date : ");
        var employeeId = GetInput.GetInt("employee_id : ");

        return (startDate, employeeId);
    }
    public (DateTime, int) GetByIdMenu()
    {
        Console.WriteLine("Search Data");
        Console.WriteLine("===========");
        var startDate = GetInput.GetDateTime("start_date : ");
        var employeeId = GetInput.GetInt("employee_id : ");

        return (startDate, employeeId);
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