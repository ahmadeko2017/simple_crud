using MVC_Implementation.Models;
using MVC_Implementation.Utility;

namespace MVC_Implementation.View;

public class VJob
{
    public void GetAll(List<Job> jobs)
    {
        foreach (var job in jobs)
        {
            GetById(job);
        }
    }
    public void GetById(Job job)
    {
        Console.WriteLine($" id = {job.Id}");
        Console.WriteLine($" title = {job.Title}");
        Console.WriteLine($" min_salary = {job.MinSalary}");
        Console.WriteLine($" max_salary = {job.MaxSalary}");
        Console.WriteLine("========================");
    }
    public int Menu()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("       JOB TABLE");
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
    public Job InsertMenu()
    {
        Console.WriteLine("Insert Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");
        var title = GetInput.GetString("title : ");
        var minSalary = GetInput.GetInt("min_salary : ");
        var maxSalary = GetInput.GetInt("max_salary : ");

        return new Job(id, title, minSalary, maxSalary);
    }
    public Job UpdateMenu()
    {
        Console.WriteLine("Update Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");
        var title = GetInput.GetString("title : ");
        var minSalary = GetInput.GetInt("min_salary : ");
        var maxSalary = GetInput.GetInt("max_salary : ");

        return new Job(id, title, minSalary, maxSalary);
    }
    public string DeleteMenu()
    {
        Console.WriteLine("Delete Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");

        return id;
    }
    public string GetByIdMenu()
    {
        Console.WriteLine("Search Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");
        
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