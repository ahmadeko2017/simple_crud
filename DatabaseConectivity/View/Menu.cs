﻿using DatabaseConectivity.DataAccessObject;
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
        // ReSharper disable once FunctionNeverReturns
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
                        var countrie = SimpleCrud.GetTableById<Country, String>(table,
                            GetInput.GetString("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED COUNTRY");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id        = {countrie.Id}");
                        Console.WriteLine($" name      = {countrie.Name}");
                        Console.WriteLine($" region_id = {countrie.RegionId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "department" :
                        var department = SimpleCrud.GetTableById<Department, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("  SELECTED DEPARTMENT");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id          = {department.Id}");
                        Console.WriteLine($" name        = {department.Name}");
                        Console.WriteLine($" Location_id = {department.LocationId}");
                        Console.WriteLine($" manager_id  = {department.ManagerId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "employees" :
                        var employee = SimpleCrud.GetTableById<Employee, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED EMPLOYEES");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id             = {employee.Id}");
                        Console.WriteLine($" first_name     = {employee.FirsName}");
                        Console.WriteLine($" last_name      = {employee.LastName}");
                        Console.WriteLine($" email          = {employee.Email}");
                        Console.WriteLine($" phone_number   = {employee.PhoneNumber}");
                        Console.WriteLine($" hire_date      = {employee.HireDate}");
                        Console.WriteLine($" salary         = {employee.Salary}");
                        Console.WriteLine($" commission_pct = {employee.CommissionPct}");
                        Console.WriteLine($" manager_id     = {employee.ManagerId}");
                        Console.WriteLine($" job_id         = {employee.JobId}");
                        Console.WriteLine($" department_id  = {employee.DepartmentId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "histories" :
                        var historie = SimpleCrud.GetTableById<History, int>(table,
                            startDate:GetInput.GetDateTime("start_date : "),
                            employeeId:GetInput.GetInt("employee_id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("    SELECTED HISTORY");
                        Console.WriteLine("========================");
                        Console.WriteLine($" start_date    = {historie.StartDate}");
                        Console.WriteLine($" employee_id   = {historie.EmployeeId}");
                        Console.WriteLine($" end_date      = {historie.EndDate}");
                        Console.WriteLine($" department_id = {historie.DepartmentId}");
                        Console.WriteLine($" job_id        = {historie.JobId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "jobs" :
                        var job = SimpleCrud.GetTableById<Job, String>(table,
                            GetInput.GetString("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("     SELECTED JOB");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id         = {job.Id}");
                        Console.WriteLine($" title      = {job.Title}");
                        Console.WriteLine($" min_salary = {job.MinSalary}");
                        Console.WriteLine($" max_salary = {job.MaxSalary}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "locations" :
                        var location = SimpleCrud.GetTableById<Location, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED LOCATIONS");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id             = {location.Id}");
                        Console.WriteLine($" street_address = {location.StreetAddress}");
                        Console.WriteLine($" postal_code    = {location.PostalCode}");
                        Console.WriteLine($" city           = {location.City}");
                        Console.WriteLine($" state_province = {location.StateProvince}");
                        Console.WriteLine($" country_id     = {location.CountryId}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        break;
                    case "regions" :
                        var region = SimpleCrud.GetTableById<Region, int>(table,
                            GetInput.GetInt("id : "));
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("    SELECTED REGION");
                        Console.WriteLine("========================");
                        Console.WriteLine($" id = {region.Id}");
                        Console.WriteLine($" name = {region.Name}");
                        Console.WriteLine("========================");
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                }
    }

    private void GetAllData(string table)
    {
        switch (table)
                {
                    case "countries" :
                        var countries = SimpleCrud.GetTable<Country>(table);
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED COUNTRY");
                        Console.WriteLine("========================");
                        foreach (var country in countries)
                        {
                            Console.WriteLine($" id        = {country.Id}");
                            Console.WriteLine($" name      = {country.Name}");
                            Console.WriteLine($" region_id = {country.RegionId}");
                            Console.WriteLine("========================");
                        }
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "department" :
                        var departments = SimpleCrud.GetTable<Department>(table);
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("  SELECTED DEPARTMENT");
                        Console.WriteLine("========================");
                        foreach (var department in departments)
                        {
                            Console.WriteLine($" id          = {department.Id}");
                            Console.WriteLine($" name        = {department.Name}");
                            Console.WriteLine($" Location_id = {department.LocationId}");
                            Console.WriteLine($" manager_id  = {department.ManagerId}");
                            Console.WriteLine("========================");    
                        }
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "employees" :
                        var employees = SimpleCrud.GetTable<Employee>(table);
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED EMPLOYEES");
                        Console.WriteLine("========================");
                        foreach (var employee in employees)
                        {
                            Console.WriteLine($" id             = {employee.Id}");
                            Console.WriteLine($" first_name     = {employee.FirsName}");
                            Console.WriteLine($" last_name      = {employee.LastName}");
                            Console.WriteLine($" email          = {employee.Email}");
                            Console.WriteLine($" phone_number   = {employee.PhoneNumber}");
                            Console.WriteLine($" hire_date      = {employee.HireDate}");
                            Console.WriteLine($" salary         = {employee.Salary}");
                            Console.WriteLine($" commission_pct = {employee.CommissionPct}");
                            Console.WriteLine($" manager_id     = {employee.ManagerId}");
                            Console.WriteLine($" job_id         = {employee.JobId}");
                            Console.WriteLine($" department_id  = {employee.DepartmentId}");
                            Console.WriteLine("========================");    
                        }
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "histories" :
                        var histories = SimpleCrud.GetTable<History>(table);
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("    SELECTED HISTORY");
                        Console.WriteLine("========================");
                        foreach (var history in histories)
                        {
                            Console.WriteLine($" start_date    = {history.StartDate}");
                            Console.WriteLine($" employee_id   = {history.EmployeeId}");
                            Console.WriteLine($" end_date      = {history.EndDate}");
                            Console.WriteLine($" department_id = {history.DepartmentId}");
                            Console.WriteLine($" job_id        = {history.JobId}");
                            Console.WriteLine("========================");
                        }
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "jobs" :
                        var jobs = SimpleCrud.GetTable<Job>(table);
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("     SELECTED JOB");
                        Console.WriteLine("========================");
                        foreach (var job in jobs)
                        {
                            Console.WriteLine($" id         = {job.Id}");
                            Console.WriteLine($" title      = {job.Title}");
                            Console.WriteLine($" min_salary = {job.MinSalary}");
                            Console.WriteLine($" max_salary = {job.MaxSalary}");
                            Console.WriteLine("========================");
                        }
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                    case "locations" :
                        var locations = SimpleCrud.GetTable<Location>(table);
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("   SELECTED LOCATIONS");
                        Console.WriteLine("========================");
                        foreach (var location in locations)
                        {
                            Console.WriteLine($" id             = {location.Id}");
                            Console.WriteLine($" street_address = {location.StreetAddress}");
                            Console.WriteLine($" postal_code    = {location.PostalCode}");
                            Console.WriteLine($" city           = {location.City}");
                            Console.WriteLine($" state_province = {location.StateProvince}");
                            Console.WriteLine($" country_id     = {location.CountryId}");
                            Console.WriteLine("========================");    
                        }
                        Console.Write("\nPress Enter to Continue . . .");
                        break;
                    case "regions" :
                        var regions = SimpleCrud.GetTable<Region>(table);
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("    SELECTED REGION");
                        Console.WriteLine("========================");
                        foreach (var region in regions)
                        {
                            Console.WriteLine($" id = {region.Id}");
                            Console.WriteLine($" name = {region.Name}");
                            Console.WriteLine("========================");    
                        }
                        Console.Write("\nPress Enter to Continue . . .");
                        Console.ReadKey();
                        break;
                }
    }
}