using MVC_Implementation.Controllers;
using MVC_Implementation.DataAccess;
using MVC_Implementation.Models;
using MVC_Implementation.Utility;

namespace MVC_Implementation.View;

public class VLinq
{
    public void LinqMenu()
    {
        var dEmployee = new DEmployee();
        var dDepartment = new DDepartment();
        var dLocation = new DLocation();
        var dCountry = new DCountry();
        var dRegion = new DRegion();
        var vLinq = new VLinq();
        var linqController = new LinqController(dEmployee, dDepartment, dLocation, dCountry, dRegion);
        
        
        bool ulang = true;
        do
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("       LINQ MENU");
            Console.WriteLine("========================");
            Console.WriteLine(" [1] LINQ 01");
            Console.WriteLine(" [2] LINQ 02");
            Console.WriteLine("========================");
            try
            {
                int pilihMenu = GetInput.GetInt("Insert Your Choice : ");
                Console.WriteLine("========================");
                switch (pilihMenu)
                {
                    case 1 :
                        var exam01 = linqController.Exam01();
                        vLinq.Linq01(exam01);
                        break;
                    case 2 :
                        var exam02 = linqController.Exam02();
                        vLinq.Linq02(exam02);
                        break;
                    default :
                        Console.WriteLine("Silahkan Pilih Nomor 1-7");
                        break;
                }
            }
            catch 
            {
                Console.WriteLine("Input Hanya diantara 1-7!");
            }
        } while (ulang);
    }
    public void Linq01(IEnumerable<Exam01> lists)
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("       LINQ TABLE");
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

    public void Linq02(IEnumerable<Exam02> lists)
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("       LINQ TABLE");
        Console.WriteLine("========================");
        foreach (var list in lists)
        {
            Console.WriteLine($"department_name : {list.DepartmentName}");
            Console.WriteLine($"total_employee : {list.TotalEmployee}");
            Console.WriteLine($"min_salary : {list.MinSalary}");
            Console.WriteLine($"max_salary : {list.MaxSalary}");
            Console.WriteLine($"ave_salary : {list.AveSalary}");
            Console.WriteLine("========================");
        }
        
        Console.ReadKey();
    }
}