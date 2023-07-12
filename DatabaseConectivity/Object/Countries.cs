namespace DatabaseConectivity.Object;

public class Countries
{
    public Countries(string id, string name, int regionId)
    {
        Id = id;
        Name = name;
        RegionId = regionId;
    }

    public string Id { get; }
    public string Name { get; }
    public int RegionId { get; }
}