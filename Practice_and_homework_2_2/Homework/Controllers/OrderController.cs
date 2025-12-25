using Homework.Models.DTO;
using Homework.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private static List<Order> _orders = 
    [
        new() {Id = 1, Number = "ORD001", Total = 100.50m, CreatedAt = DateTime.UtcNow },
        new() {Id = 2, Number = "ORD002", Total = 250.00m, CreatedAt = DateTime.UtcNow },
        new() {Id = 3, Number = "ORD003", Total = 75.25m, CreatedAt = DateTime.UtcNow },
        new() {Id = 4, Number = "ORD004", Total = 300.00m, CreatedAt = DateTime.UtcNow },
    ];
    
    [HttpGet]
    public IActionResult GetAllOrders()
    {
        return Ok(_orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order is null)
            return NotFound("Order not found");
        
        return Ok(order);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderRequest newOrder)
    {
        var order = new Order
        {
            Id =  _orders.Any() ? _orders.Max(o => o.Id) + 1 : 1,
            Number = newOrder.Number,
            Total = newOrder.Total,
            CreatedAt = DateTime.UtcNow,
        };
        
        _orders.Add(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, [FromBody] OrderRequest order)
    {
        var existingOrder = _orders.FirstOrDefault(o => o.Id == id);
        if (existingOrder is null)
            return NotFound("Order not found");
        
        existingOrder.Number = order.Number;
        existingOrder.Total = order.Total;
        
        return Ok(existingOrder);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order is null)
            return NotFound("Order not found");
        
        _orders.Remove(order);
        return NoContent();
    }
    
    [HttpGet("search")]
    public IActionResult SearchOrders([FromQuery] string number, [FromQuery] decimal? minTotal)
    {
        IEnumerable<Order> filteredOrders = _orders;

        if (!string.IsNullOrEmpty(number))
        {
            filteredOrders = filteredOrders
                .Where(o => o.Number.Contains(number, StringComparison.OrdinalIgnoreCase));
        }

        if (minTotal is not null) 
        {
            filteredOrders = filteredOrders
                .Where(o => o.Total >= minTotal.Value);
        }

        return Ok(filteredOrders);
    }
}