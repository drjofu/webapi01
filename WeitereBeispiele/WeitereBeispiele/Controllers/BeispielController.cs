using Microsoft.AspNetCore.Mvc;

namespace WeitereBeispiele.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class BeispielController : ControllerBase
  {
    private readonly MyService myService;

    public BeispielController(MyService myService)
    {
      this.myService = myService;
    }

    [HttpGet("counter")]
    public int GetCounter()
    {
      return myService.Zähler;
    }

    [HttpGet("fehler")]
    public string Get()
    {
      throw new ApplicationException("ohh - so nicht...");

      return "Hallo Welt";
    }
  }
}
