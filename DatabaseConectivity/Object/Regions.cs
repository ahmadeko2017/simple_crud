namespace DatabaseConectivity.Object;

public class Regions
{
    public Regions(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}