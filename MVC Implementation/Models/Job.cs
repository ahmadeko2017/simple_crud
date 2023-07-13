namespace MVC_Implementation.Models;

public class Job
{
    public Job(string id, string title, int? minSalary, int? maxSalary)
    {
        Id = id;
        Title = title;
        MinSalary = minSalary;
        MaxSalary = maxSalary;
    }

    public string Id { get;}
    public string Title { get; }
    public int? MinSalary { get; }
    public int? MaxSalary { get; }
}