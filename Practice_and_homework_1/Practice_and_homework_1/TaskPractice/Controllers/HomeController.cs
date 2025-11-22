using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    // task 2
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok("Hello from ASP.NET Core! \nWelcome to my first ASP.NET Core app!");
    }

    // task 3
    [HttpGet("hello/{name}")]
    public IActionResult Get([FromRoute] string name)
    {
        return Ok($"Hello {name}");
    }
    
    // task 4
    [HttpGet("api/info")]
    public IActionResult GetInfo()
    {
        return Ok(new { message = "My first ASP.NET Core app is running!", time = DateTime.Now });
    }
}