using MVC_Implementation.DataAccess;
using MVC_Implementation.Models;
using MVC_Implementation.Utility;

namespace MVC_Implementation.View;

public class VDepartment
{
    public void GetAll(List<Department> departments)
    {
        foreach (var department in departments)
        {
            GetById(department);
        }
    }
    public void GetById(Department department)
    {
        Console.WriteLine($" id = {department.Id}");
        Console.WriteLine($" name = {department.Name}");
        Console.WriteLine($" location_id = {department.LocationId}");
        Console.WriteLine($" manager_id = {department.ManagerId}");
        Console.WriteLine("========================");
    }
    public int Menu()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("   DEPARTMENTS TABLE");
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
    public Department InsertMenu()
    {
        Console.WriteLine("Insert Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id : ");
        var name = GetInput.GetString("name : ");
        var locationId = GetInput.GetInt("location_id : ");
        var managerId = GetInput.GetInt("manager_id : ");

        return new Department(id, name, locationId, managerId);
    }
    public Department UpdateMenu()
    {
        Console.WriteLine("Update Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id : ");
        var name = GetInput.GetString("name : ");
        var locationId = GetInput.GetInt("location_id : ");
        var managerId = GetInput.GetInt("manager_id : ");

        return new Department(id, name, locationId, managerId);
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