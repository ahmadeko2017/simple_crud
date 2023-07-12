using System.Diagnostics;
using DatabaseConectivity.DataAccessObject;
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

    private void UpdateTable(string table){}
    private void DeleteTable(string table){}
    private void GetDataById(string table){}
    private void GetAllData(string table){}
}