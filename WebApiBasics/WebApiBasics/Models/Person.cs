using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using System.Text.Json.Serialization;

namespace WebApiBasics.Models
{
  public class Person
  {
    public int Id { get; set; }

    [StringLength(10, MinimumLength = 2)]
    public string? Name { get; set; }

    [Required()]
    public string? Wohnort { get; set; }

    [Range(18, 120)]
    [EvenNumber]
    public int Alter { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public string Passwort { get; set; } = "Ganz geheim";

    //[JsonIgnore]
    //public Firma Firma { get; set; }
  }

  //public class Firma
  //{
  //  public int Id { get; set; }

  //  [JsonIgnore]
  //  public List<Person> Mitarbeiter { get; set; }
  //}

  public class Personenliste : ConcurrentDictionary<int, Person>
  {
    //// nur zur Demo
    //public static readonly Personenliste Instance = new Personenliste();

    public Personenliste()
    {
      TryAdd(1, new Person { Id = 1, Name = "Petra", Alter = 44, Wohnort = "Köln" });
      TryAdd(2, new Person { Id = 2, Name = "Micky", Alter = 55, Wohnort = "Entenhausen" });
      TryAdd(3, new Person { Id = 3, Name = "Dagobert", Alter = 78, Wohnort = "Entenhausen" });
      TryAdd(4, new Person { Id = 4, Name = "Klaus", Alter = 24, Wohnort = "Bonn" });
      TryAdd(5, new Person { Id = 5, Name = "Karl", Alter = 19, Wohnort = "Ulm" });
    }
  }
}


public interface IBeispiel { }
public class A : IBeispiel { }
public class B : IBeispiel { }
public class C : IBeispiel { }
