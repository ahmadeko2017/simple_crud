using DatabaseConectivity.DataAccessObject;
using DatabaseConectivity.Object;

var coutries = SimpleCrud.GetTable<Countries>("countries");
foreach (var country in coutries)
{
    Console.Write(country.Id + ", ");
    Console.Write(country.Name + ", ");
    Console.WriteLine(country.RegionId);
}