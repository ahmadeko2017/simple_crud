namespace DatabaseConectivity.Object;

public class Histories
{
    public Histories(DateTime startDate, int employeeId, DateTime? endDate, int departmentId, string jobId)
    {
        StartDate = startDate;
        EmployeeId = employeeId;
        EndDate = endDate;
        DepartmentId = departmentId;
        JobId = jobId;
    }

    public DateTime StartDate { get; }
    public int EmployeeId { get; }
    public DateTime? EndDate { get; }
    public int DepartmentId { get; }
    public string JobId { get; }
}