using MVC_Implementation.DataAccess;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class DepartmentController
{
    private DDepartment _departmentModel;
    private VDepartment _departmentView;


    public DepartmentController(DDepartment departmentModel, VDepartment departmentView)
    {
        _departmentModel = departmentModel;
        _departmentView = departmentView;
    }

    public void GetAll()
    {
        var results = _departmentModel.GetAll();
        if (results.Count is 0)
        {
            _departmentView.DataEmpty();
        }
        else
        {
            _departmentView.GetAll(results);
        }
    }

    public void Insert()
    {
        var region = _departmentView.InsertMenu();
        var result = _departmentModel.Insert(region);
        switch (result)
        {
            case -1 :
                _departmentView.Error();
                break;
            case 0 :
                _departmentView.Failure();
                break;
            default:
                _departmentView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _departmentView.UpdateMenu();
        var result = _departmentModel.Update(region);
        switch (result)
        {
            case -1:
                _departmentView.Error();
                break;
            case 0:
                _departmentView.Failure();
                break;
            default:
                _departmentView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _departmentView.DeleteMenu();
        var result = _departmentModel.Delete(region);
        switch (result)
        {
            case -1:
                _departmentView.Error();
                break;
            case 0:
                _departmentView.Failure();
                break;
            default:
                _departmentView.Success();
                break;
        }
    }

    public void GetById()
    {
        var job = _departmentView.GetByIdMenu();
        var result = _departmentModel.GetById(job);
        switch (result.Name)
        {
            case "error":
                _departmentView.Error();
                break;
            case "failure":
                _departmentView.Failure();
                break;
            default:
                _departmentView.GetById(result);
                break;
        }
    }
}