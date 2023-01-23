using Microsoft.AspNetCore.Mvc;
using WebApiBasics.Models;

namespace WebApiBasics.Controllers
{
  [Route("[controller]")]
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
  }
}
