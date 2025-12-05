using Microsoft.AspNetCore.Mvc;
using Practice.Models;

namespace Practice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private static List<Item> _items =
    [
        new() {Id = 1, Name = "Mercedes Petronas"},
        new() {Id = 2, Name = "Scuderia Ferrari"},
        new() {Id = 3, Name = "Red Bull Racing"}
    ];
    
    [HttpGet("")]
    public IActionResult GetItems()
    {
        return Ok(_items);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetItem(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null)
            return NotFound("Item not found");

        return Ok(item);
    }

    [HttpGet("search")]
    public IActionResult SearchItems([FromQuery] string name)
    {
        if (string.IsNullOrEmpty(name))
            return BadRequest("Name is empty");

        var items = _items
            .Where(item => item.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
        
        return Ok(items);
    }

    [HttpPost("")]
    public IActionResult CreateItem([FromBody] Item item)
    {
        if(string.IsNullOrEmpty(item.Name))
            return BadRequest("Name is empty");


        item.Id = _items.Count + 1;

        _items.Add(item);
        
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateItem(int id, [FromBody] Item item)
    {
        if(string.IsNullOrWhiteSpace(item.Name))
            return BadRequest("Name is empty");
        
        var updatedItem = _items.FirstOrDefault(i => i.Id == id);
        if(updatedItem is null)
            return NotFound("Item not found");

        updatedItem.Name = item.Name;
        return Ok(updatedItem);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteItem(int id)
    {
        var item = _items.FirstOrDefault(item => item.Id == id);
        if(item is null)
            return NotFound("Item not found");
        
        _items.Remove(item);
        
        return NoContent();
    }
}