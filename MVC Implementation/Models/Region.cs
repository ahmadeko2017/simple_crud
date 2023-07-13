namespace MVC_Implementation.Models;

public class Region
{
    public Region(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}