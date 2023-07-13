using MVC_Implementation.DataAccess;
using MVC_Implementation.View;

namespace MVC_Implementation.Controllers;

public class CountryController
{
    private DCountry _countryModel;
    private VCountry _countryView;

    public CountryController(DCountry countryModel, VCountry countryView)
    {
        _countryModel = countryModel;
        _countryView = countryView;
    }

    public void GetAll()
    {
        var results = _countryModel.GetAll();
        if (results.Count is 0)
        {
            _countryView.DataEmpty();
        }
        else
        {
            _countryView.GetAll(results);
        }
    }

    public void Insert()
    {
        var region = _countryView.InsertMenu();
        var result = _countryModel.Insert(region);
        switch (result)
        {
            case -1 :
                _countryView.Error();
                break;
            case 0 :
                _countryView.Failure();
                break;
            default:
                _countryView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _countryView.UpdateMenu();
        var result = _countryModel.Update(region);
        switch (result)
        {
            case -1:
                _countryView.Error();
                break;
            case 0:
                _countryView.Failure();
                break;
            default:
                _countryView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _countryView.DeleteMenu();
        var result = _countryModel.Delete(region);
        switch (result)
        {
            case -1:
                _countryView.Error();
                break;
            case 0:
                _countryView.Failure();
                break;
            default:
                _countryView.Success();
                break;
        }
    }

    public void GetById()
    {
        var job = _countryView.GetByIdMenu();
        var result = _countryModel.GetById(job);
        switch (result.Name)
        {
            case "error":
                _countryView.Error();
                break;
            case "failure":
                _countryView.Failure();
                break;
            default:
                _countryView.GetById(result);
                break;
        }
    }
}