using DatabaseConectivity.DataAccessObject;
using DatabaseConectivity.Object;
using DatabaseConectivity.Utility;

namespace DatabaseConectivity.View;

public class Menu
{
    public void App()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("      SIMPLE CRUD");
            Console.WriteLine("========================");
            Console.WriteLine(" [1] Insert");
            Console.WriteLine(" [2] Update");
            Console.WriteLine(" [3] Delete");
            Console.WriteLine(" [4] GetById");
            Console.WriteLine(" [5] SelectAll");
            Console.WriteLine(" [6] Exit");
            Console.WriteLine("========================");
            Console.Write("\nInsert Your Choice : ");
            var input = Console.ReadLine();
            string? table;
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      INSERT DATA");
                    Console.WriteLine("========================");
                    Console.ReadKey();
                    table = ListTable();
                    InsertTable(table);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      UPDATE DATA");
                    Console.WriteLine("========================");
                    Console.ReadKey();
                    table = ListTable();
                    UpdateTable(table);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      DELETE DATA");
                    Console.WriteLine("========================");
                    Console.ReadKey();
                    table = ListTable();
                    DeleteTable(table);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("        GET DATA");
                    Console.WriteLine("========================");
                    Console.ReadKey();
                    table = ListTable();
                    GetDataById(table);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      GET ALL DATA");
                    Console.WriteLine("========================");
                    Console.ReadKey();
                    table = ListTable();
                    GetAllData(table);
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("========================");
                    Console.WriteLine("      EXIT-PROGRAM");
                    Console.WriteLine("========================");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    App();
                    break;
            }
        }
    }

    public string ListTable()
    {
        while (true)
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
            Console.WriteLine(" [8] Back");
            Console.WriteLine("========================");
            Console.Write("\nInsert Your Choice : ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    return "countries";
                case "2":
                    Console.Clear();
                    return "departments";
                case "3":
                    Console.Clear();
                    return "employees";
                case "4":
                    Console.Clear();
                    return "histories";
                case "5":
                    Console.Clear();
                    return "jobs";
                case "6":
                    Console.Clear();
                    return "locations";
                case "7":
                    Console.Clear();
                    return "regions";
                case "8":
                    Console.Clear();
                    App();
                    break;
                default:
                    Console.Clear();
                    ListTable();
                    break;
            }
        }
    }

    private void InsertTable(string table)
    {
        switch (table)
                {
                    case "countries" :
                        SimpleCrud.InsertTable(table, 
                            idStr:GetInput.GetString("id : "),  
                            name:GetInput.GetString("name : "), 
                            regionId:GetInput.GetInt("region_id : "));
                        break;
                    case "department" :
                        SimpleCrud.InsertTable(table, 
                            idInt:GetInput.GetInt("id : "),
                            name:GetInput.GetString("name : "),
                            locationId:GetInput.GetInt("location_id : "),
                            managerId:GetInput.GetInt("manager_id : "));
                        break;
                    case "employees" :
                        SimpleCrud.InsertTable(table,
                            idInt:GetInput.GetInt("id : "),
                            firstName:GetInput.GetString("first_name : "),
                            lastName:GetInput.GetString("last_name : "),
                            email:GetInput.GetString("email : "),
                            phoneNumber:GetInput.GetString("phone_number : "),
                            hireDate:GetInput.GetDateTime("hire_date : "),
                            salary:GetInput.GetInt("salary : "),
                            commissionPct:GetInput.GetDecimal("commission_pct : "),
                            managerId:GetInput.GetInt("manager_id : "),
                            jobId:GetInput.GetString("job_id : "),
                            departmentId:GetInput.GetInt("department_id : "));
                        break;
                    case "histories" :
                        SimpleCrud.InsertTable(table,
                            startDate:GetInput.GetDateTime("start_date : "),
                            employeeId:GetInput.GetInt("employee_id : "),
                            endDate:GetInput.GetDateTime("end_date : "),
                            departmentId:GetInput.GetInt("department_id : "),
                            jobId:GetInput.GetString("job_id : "));
                        break;
                    case "jobs" :
                        SimpleCrud.InsertTable(table,
                            idStr:GetInput.GetString("id : "),
                            title:GetInput.GetString("title : "),
                            minSalary:GetInput.GetInt("min_salary : "),
                            maxSalary:GetInput.GetInt("max_salary : "));
                        break;
                    case "locations" :
                        SimpleCrud.InsertTable(table,
                            idInt:GetInput.GetInt("id : "),
                            streetAddress:GetInput.GetString("street_address : "),
                            postalCode:GetInput.GetString("postal_code : "),
                            city:GetInput.GetString("city : "),
                            stateProvince:GetInput.GetString("state_province : "),
                            countryId:GetInput.GetString("country_id : "));
                        break;
                    case "regions" :
                        SimpleCrud.InsertTable(table,
                            name:GetInput.GetString("name : "));
                        break;
                }
    }

    private void UpdateTable(string table)
    {
        switch (table)
                {
                    case "countries" :
                        SimpleCrud.UpdateTable(table, 
                            idStr:GetInput.GetString("id : "),  
                            name:GetInput.GetString("name : "), 
                            regionId:GetInput.GetInt("region_id : "));
                        break;
                    case "department" :
                        SimpleCrud.UpdateTable(table, 
                            idInt:GetInput.GetInt("id : "),
                            name:GetInput.GetString("name : "),
                            locationId:GetInput.GetInt("location_id : "),
                            managerId:GetInput.GetInt("manager_id : "));
                        break;
                    case "employees" :
                        SimpleCrud.UpdateTable(table,
                            idInt:GetInput.GetInt("id : "),
                            firstName:GetInput.GetString("first_name : "),
                            lastName:GetInput.GetString("last_name : "),
                            email:GetInput.GetString("email : "),
                            phoneNumber:GetInput.GetString("phone_number : "),
                            hireDate:GetInput.GetDateTime("hire_date : "),
                            salary:GetInput.GetInt("salary : "),
                            commissionPct:GetInput.GetDecimal("commission_pct : "),
                            managerId:GetInput.GetInt("manager_id : "),
                            jobId:GetInput.GetString("job_id : "),
                            departmentId:GetInput.GetInt("department_id : "));
                        break;
                    case "histories" :
                        SimpleCrud.UpdateTable(table,
                            startDate:GetInput.GetDateTime("start_date : "),
                            employeeId:GetInput.GetInt("employee_id : "),
                            endDate:GetInput.GetDateTime("end_date : "),
                            departmentId:GetInput.GetInt("department_id : "),
                            jobId:GetInput.GetString("job_id : "));
                        break;
                    case "jobs" :
                        SimpleCrud.UpdateTable(table,
                            idStr:GetInput.GetString("id : "),
                            title:GetInput.GetString("title : "),
                            minSalary:GetInput.GetInt("min_salary : "),
                            maxSalary:GetInput.GetInt("max_salary : "));
                        break;
                    case "locations" :
                        SimpleCrud.UpdateTable(table,
                            idInt:GetInput.GetInt("id : "),
                            streetAddress:GetInput.GetString("street_address : "),
                            postalCode:GetInput.GetString("postal_code : "),
                            city:GetInput.GetString("city : "),
                            stateProvince:GetInput.GetString("state_province : "),
                            countryId:GetInput.GetString("country_id : "));
                        break;
                    case "regions" :
                        SimpleCrud.UpdateTable(table,
                            idInt:GetInput.GetInt("id : "),
                            name:GetInput.GetString("name : "));
                        break;
                }
    }

    private void DeleteTable(string table)
    {
        SimpleCrud.DeleteTable(table);
    }

    private void GetDataById(string table)
    {
        switch (table)
                {
                    case "countries" :
                        var countries = SimpleCrud.GetTableById<Countries, String>(table,
                            GetInput.GetString("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED COUNTRY");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id = {countries.Id}");
                        Console.WriteLine($" name = {countries.Name}");
                        Console.WriteLine($" region_id = {countries.RegionId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "department" :
                        var departments = SimpleCrud.GetTableById<Departments, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("  SELECTED DEPARTMENT");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id          = {departments.Id}");
                        Console.WriteLine($" name        = {departments.Name}");
                        Console.WriteLine($" Location_id = {departments.LocationId}");
                        Console.WriteLine($" manager_id  = {departments.ManagerId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "employees" :
                        var employees = SimpleCrud.GetTableById<Employees, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED EMPLOYEES");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id             = {employees.Id}");
                        Console.WriteLine($" first_name     = {employees.FirsName}");
                        Console.WriteLine($" last_name      = {employees.LastName}");
                        Console.WriteLine($" email          = {employees.Email}");
                        Console.WriteLine($" phone_number   = {employees.PhoneNumber}");
                        Console.WriteLine($" hire_date      = {employees.HireDate}");
                        Console.WriteLine($" salary         = {employees.Salary}");
                        Console.WriteLine($" commission_pct = {employees.CommissionPct}");
                        Console.WriteLine($" manager_id     = {employees.ManagerId}");
                        Console.WriteLine($" job_id         = {employees.JobId}");
                        Console.WriteLine($" department_id  = {employees.DepartmentId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "histories" :
                        var histories = SimpleCrud.GetTableById<Histories, int>(table,
                            startDate:GetInput.GetDateTime("start_date : "),
                            employeeId:GetInput.GetInt("employee_id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("    SELECTED HISTORY");
                        Console.WriteLine("========================");
                        Console.WriteLine($" start_date    = {histories.StartDate}");
                        Console.WriteLine($" employee_id   = {histories.EmployeeId}");
                        Console.WriteLine($" end_date      = {histories.EndDate}");
                        Console.WriteLine($" department_id = {histories.DepartmentId}");
                        Console.WriteLine($" job_id        = {histories.JobId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "jobs" :
                        var jobs = SimpleCrud.GetTableById<Jobs, String>(table,
                            GetInput.GetString("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("     SELECTED JOB");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id         = {jobs.Id}");
                        Console.WriteLine($" title      = {jobs.Title}");
                        Console.WriteLine($" min_salary = {jobs.MinSalary}");
                        Console.WriteLine($" max_salary = {jobs.MaxSalary}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "locations" :
                        var locations = SimpleCrud.GetTableById<Locations, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED LOCATIONS");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id             = {locations.Id}");
                        Console.WriteLine($" street_address = {locations.StreetAddress}");
                        Console.WriteLine($" postal_code    = {locations.PostalCode}");
                        Console.WriteLine($" city           = {locations.City}");
                        Console.WriteLine($" state_province = {locations.StateProvince}");
                        Console.WriteLine($" country_id     = {locations.CountryId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        break;
                    case "regions" :
                        var regions = SimpleCrud.GetTableById<Regions, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("    SELECTED REGION");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id = {regions.Id}");
                        Console.WriteLine($" name = {regions.Name}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                }
    }
    private void GetAllData(string table){}
}