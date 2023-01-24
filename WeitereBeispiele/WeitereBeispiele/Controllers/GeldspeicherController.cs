using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeitereBeispiele.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GeldspeicherController : ControllerBase
  {
    private static double inhalt = 99999999;

    [Authorize(policy: "GeldspeicherR")]
    [HttpGet]
    public ActionResult<double> Get()
    {
      return Ok(inhalt);
    }

    [Authorize(policy: "GeldspeicherRW")]
    [HttpPost]
    public ActionResult<double> Post(double transfer)
    {
      inhalt += transfer;
      return Ok(inhalt);
    }
  }
}
