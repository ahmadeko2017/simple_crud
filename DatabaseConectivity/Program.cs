using DatabaseConectivity.DataAccesObject;
using DatabaseConectivity.Object;

var coutries = SimpleCRUD.GetTable<Countries>("countries");
foreach (var country in coutries)
{
    Console.Write(country.Id + ", ");
    Console.Write(country.Name + ", ");
    Console.WriteLine(country.RegionId);
}