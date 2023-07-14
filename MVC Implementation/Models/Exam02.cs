namespace MVC_Implementation.Models;

public class Exam02
{
    public Exam02(string departmentName, int totalEmployee, int minSalary, int maxSalary, double aveSalary)
    {
        DepartmentName = departmentName;
        TotalEmployee = totalEmployee;
        MinSalary = minSalary;
        MaxSalary = maxSalary;
        AveSalary = aveSalary;
    }

    public string DepartmentName { get; set; }
    public int TotalEmployee { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public double AveSalary { get; set; }
}