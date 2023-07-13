using MVC_Implementation.DataAccess;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class JobController
{
    private DJob _jobModel;
    private VJob _jobView;

    public JobController(DJob jobModel, VJob jobView)
    {
        _jobModel = jobModel;
        _jobView = jobView;
    }

    public void GetAll()
    {
        var results = _jobModel.GetAll();
        if (results.Count is 0)
        {
            _jobView.DataEmpty();
        }
        else
        {
            _jobView.GetAll(results);
        }
    }

    public void Insert()
    {
        var region = _jobView.InsertMenu();
        var result = _jobModel.Insert(region);
        switch (result)
        {
            case -1 :
                _jobView.Error();
                break;
            case 0 :
                _jobView.Failure();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _jobView.UpdateMenu();
        var result = _jobModel.Update(region);
        switch (result)
        {
            case -1:
                _jobView.Error();
                break;
            case 0:
                _jobView.Failure();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _jobView.DeleteMenu();
        var result = _jobModel.Delete(region);
        switch (result)
        {
            case -1:
                _jobView.Error();
                break;
            case 0:
                _jobView.Failure();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void GetById()
    {
        var job = _jobView.GetByIdMenu();
        var result = _jobModel.GetById(job);
        switch (result.Title)
        {
            case "error":
                _jobView.Error();
                break;
            case "failure":
                _jobView.Failure();
                break;
            default:
                _jobView.GetById(result);
                break;
        }
    }
}