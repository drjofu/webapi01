using Microsoft.AspNetCore.Mvc;
using WebApiBasics.Models;

namespace WebApiBasics.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class BeispielController
  {
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
    public string Peng(ILogger<BeispielController> logger)
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
      return configuration["Firma:Name"];
    }
  }
}
