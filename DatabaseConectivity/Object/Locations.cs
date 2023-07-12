namespace DatabaseConectivity.Object;

public class Locations
{
    public Locations(int id, string? streetAddress, string? postalCode, string city, string? stateProvince, string countryId)
    {
        Id = id;
        StreetAddress = streetAddress;
        PostalCode = postalCode;
        City = city;
        StateProvince = stateProvince;
        CountryId = countryId;
    }

    public int Id { get; }
    public string? StreetAddress { get; }
    public string? PostalCode { get; }
    public string City { get; }
    public string? StateProvince { get; }
    public string CountryId { get; }
}