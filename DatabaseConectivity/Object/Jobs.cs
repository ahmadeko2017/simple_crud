namespace DatabaseConectivity.Object;

public class Jobs
{
    public Jobs(string id, string title, int? minSalary, int? maxSalary)
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