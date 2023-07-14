using MVC_Implementation.Models;

namespace MVC_Implementation.View;

public class VLinq
{
    public void LinqMenu(List<Linq> lists)
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("    COUNTRIES TABLE");
        Console.WriteLine("========================");
        foreach (var list in lists)
        {
            Console.WriteLine($"id : {list.Id}");
            Console.WriteLine($"full_name : {list.FullName}");
            Console.WriteLine($"email : {list.Email}");
            Console.WriteLine($"phone_number : {list.PhoneNumber}");
            Console.WriteLine($"salary : {list.Salary}");
            Console.WriteLine($"department_name : {list.DepartmentName}");
            Console.WriteLine($"street_address : {list.StreetAddress}");
            Console.WriteLine($"country_name : {list.CountryName}");
            Console.WriteLine($"region_name : {list.RegionName}");
            Console.WriteLine("========================");
        }

        Console.ReadKey();
    }
}