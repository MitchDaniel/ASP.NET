using Microsoft.AspNetCore.Mvc;

namespace TaskHomework.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
   [HttpGet("")]
   public IActionResult Index()
   {
      return Ok("Welcome to MyHomeWeb!");
   }

   [HttpGet("hello/{name}")]
   public IActionResult Hello([FromRoute] string name)
   {
      return Ok($"Hello, {name}");
   }

   [HttpGet("api/status")]
   public IActionResult GetStatus()
   {
      return Ok(new { message = "Welcome to MyHomeWeb!", time = DateTime.Now });
   }
}