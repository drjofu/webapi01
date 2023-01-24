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
    public IEnumerable<Continent>GetContinents()
    {
      return world.GetContinents();
    }
  }
}
