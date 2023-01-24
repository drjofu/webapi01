using System.Xml.Linq;

namespace MondialApiBeispiel.Models
{
  public class World
  {
    private readonly string path;

    public World(IConfiguration configuration)
    {
      path = configuration["Mondial:Path"];
    }

    public IEnumerable<Continent> GetContinents()
    {
      XDocument xDoc = XDocument.Load(path);

      return xDoc
        .Root
        .Elements("continent")
        .Select(xContinent => new Continent
        {
          Name = (string)xContinent.Element("name"),
          Area = (int)xContinent.Element("area"),
          Id = xContinent.Attribute("id").Value
        })
        .ToList();
    }

    public IEnumerable<Country> GetCountriesByContinentId(string continentId)
    {
      XDocument xDoc = XDocument.Load(path);
      return xDoc
        .Root
        .Elements("country")
        .Where(xCountry => xCountry.Element("encompassed").Attribute("continent").Value == continentId)
        .Select(xCountry => new Country
        {
          Name = (string)xCountry.Element("name"),
          CarCode = (string)xCountry.Attribute("car_code"),
          Area = (double)xCountry.Attribute("area")
        })
        .ToList();
    }
  }
}
