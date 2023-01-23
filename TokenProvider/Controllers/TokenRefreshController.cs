using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenProvider.Models;

namespace TokenProvider.Controllers
{
  [Route("[controller]")]
  [ApiController]
  [Authorize]
  public class TokenRefreshController : ControllerBase
  {
    private readonly IConfiguration configuration;
    private readonly ILogger<TokenRefreshController> logger;
    private readonly JwtSettings jwtSettings;

    public TokenRefreshController(IConfiguration configuration, ILogger<TokenRefreshController> logger)
    {
      this.configuration = configuration;
      this.logger = logger;

      jwtSettings = new JwtSettings();
      configuration.GetSection("Jwt").Bind(jwtSettings);
    }

    [HttpPost()]
    [ProducesResponseType(401)]
    [ProducesResponseType(200)]
    public IActionResult RefreshToken()
    {
      logger.LogDebug("Refresh Token");

      var claims = this.User.Claims;
      if (claims != null)
        return Ok(new { token = BuildToken(claims, 25) });

      logger.LogError("Refresh Token unauthorized");

      return Unauthorized();
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
