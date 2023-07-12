namespace DatabaseConectivity.Object;

public class Country
{
    public Country(string id, string name, int regionId)
    {
        Id = id;
        Name = name;
        RegionId = regionId;
    }

    public string Id { get; }
    public string Name { get; }
    public int RegionId { get; }
}