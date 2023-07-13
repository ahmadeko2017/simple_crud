using MVC_Implementation.DataAccess;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class LocationController
{
    private DLocation _locationModel;
    private VLocation _locationView;

    public LocationController(DLocation locationModel, VLocation locationView)
    {
        _locationModel = locationModel;
        _locationView = locationView;
    }
    
    public void GetAll()
    {
        var results = _locationModel.GetAll();
        if (results.Count is 0)
        {
            _locationView.DataEmpty();
        }
        else
        {
            _locationView.GetAll(results);
        }
    }

    public void Insert()
    {
        var region = _locationView.InsertMenu();
        var result = _locationModel.Insert(region);
        switch (result)
        {
            case -1 :
                _locationView.Error();
                break;
            case 0 :
                _locationView.Failure();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _locationView.UpdateMenu();
        var result = _locationModel.Update(region);
        switch (result)
        {
            case -1:
                _locationView.Error();
                break;
            case 0:
                _locationView.Failure();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _locationView.DeleteMenu();
        var result = _locationModel.Delete(region);
        switch (result)
        {
            case -1:
                _locationView.Error();
                break;
            case 0:
                _locationView.Failure();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void GetById()
    {
        var location = _locationView.GetByIdMenu();
        var result = _locationModel.GetById(location);
        switch (result.StreetAddress)
        {
            case "error":
                _locationView.Error();
                break;
            case "failure":
                _locationView.Failure();
                break;
            default:
                _locationView.GetById(result);
                break;
        }
    }
}