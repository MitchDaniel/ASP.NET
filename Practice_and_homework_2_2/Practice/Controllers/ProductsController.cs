using Microsoft.AspNetCore.Mvc;
using Practice.Models.DTO;
using Practice.Models.Entities;

namespace Practice;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> _products =
    [
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Smartphone", Price = 499.99m },
        new Product { Id = 3, Name = "Tablet", Price = 299.99m }
    ];
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_products);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        
        if (product is null)
            return Problem("Product not found", 
                            statusCode: StatusCodes.Status404NotFound);
        
        return Ok(product);
    }

    [HttpGet("search")]
    public IActionResult SearchProductsByName([FromQuery] string? name)
    {
        if (string.IsNullOrEmpty(name))
            return Problem("Product name is required", 
                            statusCode: StatusCodes.Status400BadRequest);
        
        var products = _products
            .Where(p => p.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
         
        return Ok(products);
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] ProductRequest product)
    {
        if (string.IsNullOrEmpty(product.Name))
            return Problem("Product name is required", 
                            statusCode: StatusCodes.Status400BadRequest);
        
        var newProduct = new Product()
        {
            Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1,
            Name = product.Name,
            Price = product.Price
        };

        _products.Add(newProduct);
        
        return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, [FromBody] ProductRequest product)
    {
        if (string.IsNullOrEmpty(product.Name))
            return Problem("Product name is required", 
                            statusCode: StatusCodes.Status400BadRequest);
        
        var existingProduct = _products.FirstOrDefault(p => id == p.Id);
        
        if (existingProduct is null)
            return Problem("Product not found", 
                            statusCode: StatusCodes.Status404NotFound);
        
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        
        return Ok(existingProduct);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var existingProduct = _products.FirstOrDefault(p => id == p.Id);
 
        if(existingProduct is null)
            return Problem("Product not found", 
                            statusCode: StatusCodes.Status404NotFound);
        
        _products.Remove(existingProduct);
        
        return NoContent();
    }
}