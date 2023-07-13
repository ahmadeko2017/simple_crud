namespace MVC_Implementation.Models;

public class Department
{
    public Department(int id, string name, int locationId, int? managerId)
    {
        Id = id;
        Name = name;
        LocationId = locationId;
        ManagerId = managerId;
    }

    public int Id { get; }
    public string Name { get; }
    public int LocationId { get; }
    public int? ManagerId { get; }
}