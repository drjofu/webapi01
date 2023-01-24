using Microsoft.AspNetCore.Mvc;
using MondialApiBeispiel.Models;

namespace MondialApiBeispiel.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class WorldController : ControllerBase
  {
    private readonly World world;

    public WorldController(World world)
    {
      this.world = world;
    }

    [HttpGet]
    public IEnumerable<Continent> GetContinents()
    {
      return world.GetContinents();
    }

    [HttpGet("countries")]
    public ActionResult<IEnumerable<Country>> GetCountries(string continentId)
    {
      var countries = world.GetCountriesByContinentId(continentId);
      if(countries.Any()) 
        return Ok(countries);

      return NotFound($"Continent mit id {continentId} gibt es nicht");
    }
  }
}
