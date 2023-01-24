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
          Name = xContinent.Element("name").Value,
          Area = (int)xContinent.Element("area"),
          Id = xContinent.Attribute("id").Value
        })
        .ToList();
    }
  }
}
