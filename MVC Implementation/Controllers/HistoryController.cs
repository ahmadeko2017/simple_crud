using MVC_Implementation.DataAccess;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class HistoryController
{
    private DHistory _historyModel;
    private VHistory _historyView;

    public HistoryController(DHistory historyModel, VHistory historyView)
    {
        _historyModel = historyModel;
        _historyView = historyView;
    }


    public void GetAll()
    {
        var results = _historyModel.GetAll();
        if (results.Count is 0)
        {
            _historyView.DataEmpty();
        }
        else
        {
            _historyView.GetAll(results);
        }
    }

    public void Insert()
    {
        var region = _historyView.InsertMenu();
        var result = _historyModel.Insert(region);
        switch (result)
        {
            case -1 :
                _historyView.Error();
                break;
            case 0 :
                _historyView.Failure();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _historyView.UpdateMenu();
        var result = _historyModel.Update(region);
        switch (result)
        {
            case -1:
                _historyView.Error();
                break;
            case 0:
                _historyView.Failure();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void Delete()
    {
        var (var1,var2) = _historyView.DeleteMenu();
        var result = _historyModel.Delete(var1, var2);
        switch (result)
        {
            case -1:
                _historyView.Error();
                break;
            case 0:
                _historyView.Failure();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void GetById()
    {
        var (var1,var2) = _historyView.GetByIdMenu();
        var result = _historyModel.GetById(var1, var2);
        switch (result.JobId)
        {
            case "error":
                _historyView.Error();
                break;
            case "failure":
                _historyView.Failure();
                break;
            default:
                _historyView.GetById(result);
                break;
        }
    }
}