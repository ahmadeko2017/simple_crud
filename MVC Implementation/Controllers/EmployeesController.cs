using MVC_Implementation.DataAccess;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class EmployeesController
{
    private DEmployee _employeeModel;
    private VEmployee _employeeView;

    public EmployeesController(DEmployee employeeModel, VEmployee employeeView)
    {
        _employeeModel = employeeModel;
        _employeeView = employeeView;
    }

    public void GetAll()
    {
        var results = _employeeModel.GetAll();
        if (results.Count is 0)
        {
            _employeeView.DataEmpty();
        }
        else
        {
            _employeeView.GetAll(results);
        }
    }

    public void Insert()
    {
        var region = _employeeView.InsertMenu();
        var result = _employeeModel.Insert(region);
        switch (result)
        {
            case -1 :
                _employeeView.Error();
                break;
            case 0 :
                _employeeView.Failure();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _employeeView.UpdateMenu();
        var result = _employeeModel.Update(region);
        switch (result)
        {
            case -1:
                _employeeView.Error();
                break;
            case 0:
                _employeeView.Failure();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _employeeView.DeleteMenu();
        var result = _employeeModel.Delete(region);
        switch (result)
        {
            case -1:
                _employeeView.Error();
                break;
            case 0:
                _employeeView.Failure();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void GetById()
    {
        var job = _employeeView.GetByIdMenu();
        var result = _employeeModel.GetById(job);
        switch (result.FirsName)
        {
            case "error":
                _employeeView.Error();
                break;
            case "failure":
                _employeeView.Failure();
                break;
            default:
                _employeeView.GetById(result);
                break;
        }
    }
}