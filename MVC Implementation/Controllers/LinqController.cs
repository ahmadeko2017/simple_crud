using MVC_Implementation.DataAccess;
using MVC_Implementation.Models;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class LinqController
{
    private DEmployee _employee;
    private DDepartment _department;
    private DLocation _location;
    private DCountry _country;
    private DRegion _region;
    
    public LinqController(DEmployee employee, DDepartment department, DLocation location, DCountry country, DRegion region)
    {
        _employee = employee;
        _department = department;
        _location = location;
        _country = country;
        _region = region;
    }

    public List<Linq> Start()
    {
        var getEmployees = _employee.GetAll();
        var getDepartments = _department.GetAll();
        var getLocation = _location.GetAll();
        var getCountries = _country.GetAll();
        var getRegions = _region.GetAll();

        var filtered =
            (from e in getEmployees
                join d in getDepartments on e.DepartmentId equals d.Id
                join l in getLocation on d.LocationId equals l.Id
                join c in getCountries on l.CountryId equals c.Id
                join r in getRegions on c.RegionId equals r.Id
                select new Linq(e.Id, $"{e.FirstName} {e.LastName}", e.Email, e.PhoneNumber, e.Salary, d.Name,l.StreetAddress, c.Name, r.Name)).ToList();
        return filtered;
    }
}