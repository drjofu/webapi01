using Microsoft.AspNetCore.Mvc;
using WebApiBasics.Models;

namespace WebApiBasics.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class PersonenController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<Person> Get()
    {
      return Personenliste.Instance.Values;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetPerson(int id)
    {
      if (Personenliste.Instance.ContainsKey(id))
        //return new OkObjectResult(Personenliste.Instance[id]);
        return Ok(Personenliste.Instance[id]);

      //return new NotFoundResult();
      return NotFound($"Person mit Id {id} gibt es nicht");
    }

    [HttpPost]
    public IActionResult PostPerson( Person person)
    {
      int id = Personenliste.Instance.Keys.Max() + 1;
      person.Id = id;
      Personenliste.Instance.TryAdd(id, person);
      return Created($"personen/{id}", person);
    }
  }
}
