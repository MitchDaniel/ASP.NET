using Microsoft.AspNetCore.Mvc;
using Practice.Models;

namespace Practice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private static List<Item> _items =
    [
        new(1, "MercedesPetronas"),
        new(2, "ScuderiaFerrari"),
        new(3, "RedBullRacing")
    ];
    
    [HttpGet("")]
    public IActionResult GetItems()
    {
        return Ok(_items);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetItem(int id)
    {
        if(id > _items.Count || id < 1)
            return NotFound("Item not found");
        return Ok(_items[id - 1]);
    }

    [HttpGet("search")]
    public IActionResult SearchItems([FromQuery] string? name)
    {
        if (name is null)
            return BadRequest("Name is empty");

        return Ok(_items
                    .Where(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .ToList());
    }

    [HttpPost("")]
    public IActionResult CreateItem([FromQuery] string name)
    {
        if(string.IsNullOrEmpty(name))
            return BadRequest("Name is empty");
        
        var newItem = new Item(_items.Count + 1, name);
        _items.Add(newItem);
        return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateItem(int id, [FromQuery] string name)
    {
        if(id > _items.Count || id < 1)
            return NotFound("Item not found");
        
        if(string.IsNullOrEmpty(name))
            return BadRequest("Name is empty");
        
        var updatedItem = new Item(id, name);
        _items[id - 1] = updatedItem;
        return Ok(updatedItem);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteItem(int id)
    {
        if(id > _items.Count || id < 1)
            return NotFound("Item not found");
        
        _items.RemoveAt(id - 1);
        
        for(int i = id - 1; i < _items.Count; i++)
        {
            var tempItem = _items[i];
            _items[i] = new Item(tempItem.Id - 1, tempItem.Name);
        }
        
        return NoContent();
    }
    
}