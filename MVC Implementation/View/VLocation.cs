using MVC_Implementation.Models;
using MVC_Implementation.Utility;

namespace MVC_Implementation.View;

public class VLocation
{
    public void GetAll(List<Location> locations)
    {
        foreach (var location in locations)
        {
            GetById(location);
        }
    }
    public void GetById(Location location)
    {
        Console.WriteLine($" id = {location.Id}");
        Console.WriteLine($" street_address = {location.StreetAddress}");
        Console.WriteLine($" postal_code = {location.PostalCode}");
        Console.WriteLine($" city = {location.City}");
        Console.WriteLine($" state_province = {location.StateProvince}");
        Console.WriteLine($" country_id = {location.CountryId}");
        Console.WriteLine("========================");
    }
    public int Menu()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("    LOCATIONS TABLE");
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
    public Location InsertMenu()
    {
        Console.WriteLine("Insert Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id :");
        var streetAddress = GetInput.GetString("street_address : ");
        var postalCode = GetInput.GetString("postal_code : ");
        var city = GetInput.GetString("city : ");
        var stateProvince = GetInput.GetString("state_province : ");
        var countryId = GetInput.GetString("country_id");
        
        return new Location(id, streetAddress, postalCode, city, stateProvince, countryId);
    }
    public Location UpdateMenu()
    {
        Console.WriteLine("Update Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id :");
        var streetAddress = GetInput.GetString("street_address : ");
        var postalCode = GetInput.GetString("postal_code : ");
        var city = GetInput.GetString("city : ");
        var stateProvince = GetInput.GetString("state_province : ");
        var countryId = GetInput.GetString("country_id");

        return new Location(id, streetAddress, postalCode, city, stateProvince, countryId);
    }
    public int DeleteMenu()
    {
        Console.WriteLine("Delete Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id :");

        return id;
    }
    public int GetByIdMenu()
    {
        Console.WriteLine("Search Data");
        Console.WriteLine("===========");
        var id = GetInput.GetInt("id :");
        
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