namespace TokenProvider.Models
{
  public class JwtSettings
  {
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public IEnumerable<User> Users { get; set; }
  }

  public class User
  {
    public string Name { get; set; }
    public string Password { get; set; }
    public IEnumerable<UClaim> Claims { get; set; }
  }

  public class UClaim
  {
    public string Key { get; set; }
    public string Value { get; set; }
  }



}
