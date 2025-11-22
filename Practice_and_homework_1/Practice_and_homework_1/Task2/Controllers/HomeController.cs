using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok("Hello from ASP.NET Core! \nWelcome to my first ASP.NET Core app!");
    }
}