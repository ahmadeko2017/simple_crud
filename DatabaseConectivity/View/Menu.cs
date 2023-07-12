using DatabaseConectivity.DataAccessObject;

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
    public void InsertTable(string table){}
    public void UpdateTable(string table){}
    public void DeleteTable(string table){}
    public void GetDataById(string table){}
    public void GetAllData(string table){}
}