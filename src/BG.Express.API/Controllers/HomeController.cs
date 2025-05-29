using Microsoft.AspNetCore.Mvc;

namespace BG.Express.API.Controllers;

[Route("")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var deployment = Environment.GetEnvironmentVariable("DEPLOYMENT_INFO");
        return Ok($"V:{deployment} Warmed up sucessfully {DateTime.Now}");
    }
}
