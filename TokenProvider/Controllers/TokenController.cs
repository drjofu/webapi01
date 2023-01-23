using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenProvider.Models;

namespace TokenProvider.Controllers
{
  /// <summary>
  /// Einfaches Beispiel für Authentifizierung von Benutzern und Erstellen eines Bearer Tokens
  /// Achtung: Nur zur Demo! Benutzerverwaltung nicht praxistauglich!!!
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class TokenController : ControllerBase
  {
    private readonly IConfiguration configuration;
    private readonly ILogger<TokenController> logger;
    private readonly JwtSettings jwtSettings;

    public TokenController(IConfiguration configuration, ILogger<TokenController> logger)
    {
      this.configuration = configuration;
      this.logger = logger;

      jwtSettings = new JwtSettings();
      configuration.GetSection("Jwt").Bind(jwtSettings);
    }

    [AllowAnonymous]
    [HttpGet]
    public string Hallo()
    {
      return "Hallo Welt";
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public IActionResult CreateToken([FromBody] LoginModel login)
    {
      logger.LogDebug($"Anmeldung {login.Username} von {HttpContext.Connection?.RemoteIpAddress}, local: {HttpContext.Connection?.LocalIpAddress}");

      var claims = Authenticate(login);

      if (claims != null)
        return Ok(new { token = BuildToken(claims, 30) });

      logger.LogError("unauthorized");
      return Unauthorized();
    }

    private IEnumerable<Claim> Authenticate(LoginModel login)
    {
      // Ist der User in der Liste?
      var user = jwtSettings.Users.FirstOrDefault(u => u.Name.ToLower() == login.Username?.ToLower().Trim());

      if (user == null) return null; // User unbekannt

      if (login.Password == user.Password)
      {
        return GetClaims(login.Username); // ok, Claims aus Config-Datei nehmen
      }

      return null; // Falsches Passwort
    }


    private IEnumerable<Claim> GetClaims(string username)
    {
      var claims = jwtSettings.Users
        .FirstOrDefault(u => u.Name.ToLower().Trim() == username.ToLower())?
        .Claims?.Select(c => new Claim(c.Key, c.Value)).ToList();
      claims.Add(new Claim(ClaimTypes.Name, username));
      return claims;
    }

    private string BuildToken(IEnumerable<Claim> claims, int minutes)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        jwtSettings.Issuer,
        jwtSettings.Audience,
        expires: DateTime.UtcNow.AddMinutes(minutes),
        signingCredentials: creds,
        claims: claims);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }




  }
}
