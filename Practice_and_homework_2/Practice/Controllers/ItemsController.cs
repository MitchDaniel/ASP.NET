using Microsoft.AspNetCore.Mvc;

namespace Practice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetItems()
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetItem(int id)
    {
        return Ok(id);
    }
}