using System.ComponentModel.DataAnnotations;

namespace WebApiBasics.Models
{
  public class FirmaConfig
  {
    public string Name { get; set; }

    [Required]
    public string Adresse { get; set; }
    public int AnzahlMitarbeiter { get; set; }
    public string Passwort { get; set; }
  }
}
