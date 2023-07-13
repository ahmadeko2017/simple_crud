namespace MVC_Implementation.Models;

public class Country
{
    public Country(string id, string name, int regionId)
    {
        Id = id;
        Name = name;
        RegionId = regionId;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }
}