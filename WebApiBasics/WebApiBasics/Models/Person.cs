using System.Collections.Concurrent;

namespace WebApiBasics.Models
{
  public class Person
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Wohnort { get; set; }
    public int Alter { get; set; }
  }

  public class Personenliste : ConcurrentDictionary<int, Person>
  {
    // nur zur Demo
    public static readonly Personenliste Instance= new Personenliste();

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
