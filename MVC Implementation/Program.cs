using MVC_Implementation.Controllers;
using MVC_Implementation.DataAccess;
using MVC_Implementation.Models;
using MVC_Implementation.Utility;
using MVC_Implementation.View;

public class Program
{
    public static void Main()
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        bool ulang = true;
        do
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("       TABLE LIST");
            Console.WriteLine("========================");
            Console.WriteLine(" [1] Countries");
            Console.WriteLine(" [2] Departments");
            Console.WriteLine(" [3] Employees");
            Console.WriteLine(" [4] Histories");
            Console.WriteLine(" [5] Jobs");
            Console.WriteLine(" [6] Location");
            Console.WriteLine(" [7] Regions");
            Console.WriteLine(" [8] Linq");
            Console.WriteLine(" [9] Exit");
            Console.WriteLine("========================");

            try
            {
                int pilihMenu = GetInput.GetInt("Insert Your Choice : ");
                Console.WriteLine("========================");

                switch (pilihMenu)
                {
                    case 1 :
                        CountryMenu();
                        break;
                    case 2 :
                        DepartmentMenu();
                        break;
                    case 3 :
                        EmployeeMenu();
                        break;
                    case 4 :
                        HistoryMenu();
                        break;
                    case 5 :
                        JobsMenu();
                        break;
                    case 6 :
                        LocationMenu();
                        break;
                    case 7:
                        RegionMenu();
                        break;
                    case 8 :
                        LinqMenu();
                        break;
                    case 9:
                        ulang = false;
                        break;
                    default:
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

    private static void LinqMenu()
    {
        VLinq vLinq = new VLinq();
        vLinq.LinqMenu();
    }

    private static void CountryMenu()
    {
        DCountry country = new DCountry();
        VCountry vCountry = new VCountry();
        CountryController countryController = new CountryController(country, vCountry);

        bool isTrue = true;
        do
        {
            int pilihMenu = vCountry.Menu();
            switch (pilihMenu)
            {
                case 1:
                    countryController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    countryController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    countryController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    countryController.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    countryController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }


    private static void DepartmentMenu()
    {
        DDepartment department = new DDepartment();
        VDepartment vDepartment = new VDepartment();
        DepartmentController departmentController = new DepartmentController(department, vDepartment);

        bool isTrue = true;
        do
        {
            int pilihMenu = vDepartment.Menu();
            switch (pilihMenu)
            {
                case 1:
                    departmentController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    departmentController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    departmentController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    departmentController.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    departmentController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void EmployeeMenu()
    {
        DEmployee employee = new DEmployee();
        VEmployee vEmployee = new VEmployee();
        EmployeeController employeeController = new EmployeeController(employee, vEmployee);

        bool isTrue = true;
        do
        {
            int pilihMenu = vEmployee.Menu();
            switch (pilihMenu)
            {
                case 1:
                    employeeController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    employeeController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    employeeController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    employeeController.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    employeeController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void HistoryMenu()
    {
        DHistory history = new DHistory();
        VHistory vHistory = new VHistory();
        HistoryController historyController = new HistoryController(history, vHistory);

        bool isTrue = true;
        do
        {
            int pilihMenu = vHistory.Menu();
            switch (pilihMenu)
            {
                case 1:
                    historyController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    historyController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    historyController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    historyController.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    historyController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void JobsMenu()
    {
        DJob job = new DJob();
        VJob vJob = new VJob();
        JobController jobController = new JobController(job, vJob);

        bool isTrue = true;
        do
        {
            int pilihMenu = vJob.Menu();
            switch (pilihMenu)
            {
                case 1:
                    jobController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    jobController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    jobController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    jobController.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    jobController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void LocationMenu()
    {
        DLocation location = new DLocation();
        VLocation vLocation = new VLocation();
        LocationController locationController = new LocationController(location, vLocation);

        bool isTrue = true;
        do
        {
            int pilihMenu = vLocation.Menu();
            switch (pilihMenu)
            {
                case 1:
                    locationController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    locationController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    locationController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    locationController.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    locationController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void RegionMenu()
    {
        DRegion region = new DRegion();
        VRegion vRegion = new VRegion();
        RegionController regionController = new RegionController(region, vRegion);

        bool isTrue = true;
        do
        {
            int pilihMenu = vRegion.Menu();
            switch (pilihMenu)
            {
                case 1:
                    regionController.Insert();
                    PressAnyKey();
                    break;
                case 2:
                    regionController.Update();
                    PressAnyKey();
                    break;
                case 3:
                    regionController.Delete();
                    PressAnyKey();
                    break;
                case 4:
                    regionController.GetById();
                    PressAnyKey();
                    break;
                case 5:
                    regionController.GetAll();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }
    
    private static void InvalidInput()
    {
        Console.WriteLine("Your input is not valid!");
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}