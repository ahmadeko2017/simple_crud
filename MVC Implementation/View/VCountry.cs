using MVC_Implementation.Models;
using MVC_Implementation.Utility;

namespace MVC_Implementation.View;

public class VCountry
{
    public void GetAll(List<Country> countries)
    {
        foreach (var country in countries)
        {
            GetById(country);
        }
    }
    public void GetById(Country country)
    {
        Console.WriteLine($" id = {country.Id}");
        Console.WriteLine($" name = {country.Name}");
        Console.WriteLine($" region = {country.RegionId}");
        Console.WriteLine("========================");
    }
    public int Menu()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("    COUNTRIES TABLE");
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
    public Country InsertMenu()
    {
        Console.WriteLine("Insert Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");
        var name = GetInput.GetString("name : ");
        var regionId = GetInput.GetInt("region_id : ");

        return new Country(id, name, regionId);
    }
    public Country UpdateMenu()
    {
        Console.WriteLine("Update Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");
        var name = GetInput.GetString("name : ");
        var regionId = GetInput.GetInt("region_id : ");

        return new Country(id, name, regionId);
    }
    public string DeleteMenu()
    {
        Console.WriteLine("Delete Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");

        return id;
    }
    public string GetByIdMenu()
    {
        Console.WriteLine("Search Data");
        Console.WriteLine("===========");
        var id = GetInput.GetString("id : ");
        
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