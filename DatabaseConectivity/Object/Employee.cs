namespace DatabaseConectivity.Object;

public class Employee
{
    public Employee(int id, string firsName, string lastName, string email, string phoneNumber, DateTime hireDate, int? salary, decimal? commissionPct, int? managerId, string jobId, int departmentId)
    {
        Id = id;
        FirsName = firsName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        HireDate = hireDate;
        Salary = salary;
        CommissionPct = commissionPct;
        ManagerId = managerId;
        JobId = jobId;
        DepartmentId = departmentId;
    }

    public int Id { get; }
    public string FirsName { get; }
    public string? LastName { get; }
    public string Email { get; }
    public string? PhoneNumber { get; }
    public DateTime HireDate { get; }
    public int? Salary { get; }
    public decimal? CommissionPct { get; }
    public int? ManagerId { get; }
    public string JobId { get; }
    public int DepartmentId { get; }
}