using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiBasics.Models;

namespace WebApiBasics.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class Beispiel : ControllerBase
  {
    private FirmaConfig firmaConfig;

    public Beispiel(IOptions<FirmaConfig> firmaOptions)
    {
      firmaConfig = firmaOptions.Value;
    }

    [HttpGet("firmaconfig")]
    public ActionResult<FirmaConfig> GetFirmaConfig()
    {
      return Ok(firmaConfig);
    }

    [HttpGet]
    public string Get()
    {
      return "Hallo Welt";
    }

    [HttpGet("hello")]
    public string SayHello(string? name)
    {
      return $"Hallo {name ?? "noname"}";
    }

    [HttpGet("add")]
    public int Add(int a, int b)
    {
      return a + b;
    }

    [HttpGet("person")]
    public Person GetPerson()
    {
      return new Person
      {
        Name = "Petra",
        Wohnort = "Köln",
        Id = 17
      };
    }

    [HttpGet("phello")]
    public string HelloPerson(Person person)
    {
      return $"Hallo {person.Name}";
    }

    [HttpGet("Peng")]
    public string Peng(ILogger<Beispiel> logger)
    {
      try
      {
        int i = 0;
        int n = 10 / i;
      }
      catch (Exception ex)
      {
        logger.LogCritical(ex, "Peng peng...");
      }

      return "Peng löst eine Exception aus";
    }

    [HttpGet("firma")]
    public string Firma(IConfiguration configuration)
    {
      FirmaConfig firmaConfig = new();
      configuration.GetSection("Firma").Bind(firmaConfig);

      int anzahlMitarbeiter = configuration.GetValue<int>("Firma:AnzahlMitarbeiter");
      return configuration["Firma:Passwort"];
    }
  }
}
