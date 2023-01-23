namespace Common.Models
{
  public class LoginModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class BearerToken
  {
    public string Token { get; set; }
  }

}
