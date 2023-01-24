using Microsoft.AspNetCore.Mvc;
using WebApiBasics.Models;

namespace WebApiBasics.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class PersonenController : ControllerBase
  {
    private readonly Personenliste personenlisteViaDI;
    private readonly IServiceProvider serviceProvider;
    private readonly ILogger<PersonenController> logger;

    public PersonenController(Personenliste personenliste,
      IEnumerable<IBeispiel> beispiel,
      IServiceProvider serviceProvider,
      ILogger<PersonenController> logger)
    {
      this.personenlisteViaDI = personenliste;
      this.serviceProvider = serviceProvider;
      this.logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Person>> Get([FromServices] Personenliste liste)
    {
      logger.LogInformation("Lesen aller Personen");

      await Task.Delay(500);

      return liste.Values;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Person>> GetPerson(int id)
    {
      await Task.Delay(2000);

      var liste = serviceProvider.GetRequiredService<Personenliste>();
      var abc = serviceProvider.GetServices<IBeispiel>();

      if (liste.ContainsKey(id))
        //return new OkObjectResult(Personenliste.Instance[id]);
        return Ok(liste[id]);

      logger.LogDebug("ups - das sollte nicht aufgerufen werden. Id war {id}", id);

      //return new NotFoundResult();
      return NotFound($"Person mit Id {id} gibt es nicht");
    }

    [HttpPost]
    public ActionResult<Person> PostPerson(Person person)
    {
      //if(!ModelState.IsValid)
      //{
      //  return BadRequest(ModelState);
      //}

      int id = personenlisteViaDI.Keys.Max() + 1;
      person.Id = id;
      personenlisteViaDI.TryAdd(id, person);
      return Created($"personen/{id}", person);
    }
  }
}
