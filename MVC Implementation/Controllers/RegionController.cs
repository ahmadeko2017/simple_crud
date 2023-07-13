using MVC_Implementation.DataAccess;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class RegionController
{
    private DRegion _regionModel;
    private VRegion _regionView;

    public RegionController(DRegion regionModel, VRegion regionView)
    {
        _regionModel = regionModel;
        _regionView = regionView;
    }

    public void GetAll()
    {
        var results = _regionModel.GetAll();
        if (results.Count is 0)
        {
            _regionView.DataEmpty();
        }
        else
        {
            _regionView.GetAll(results);
        }
    }

    public void Insert()
    {
        var region = _regionView.InsertMenu();
        var result = _regionModel.Insert(region);
        switch (result)
        {
            case -1 :
                _regionView.Error();
                break;
            case 0 :
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _regionView.UpdateMenu();
        var result = _regionModel.Update(region);
        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _regionView.DeleteMenu();
        var result = _regionModel.Delete(region);
        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void GetById()
    {
        var region = _regionView.GetByIdMenu();
        var result = _regionModel.GetById(region);
        switch (result.Name)
        {
            case "error":
                _regionView.Error();
                break;
            case "failure":
                _regionView.Failure();
                break;
            default:
                _regionView.GetById(result);
                break;
        }
    }
}