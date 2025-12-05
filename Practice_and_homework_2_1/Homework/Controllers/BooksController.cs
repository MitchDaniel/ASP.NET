using Homework.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> _books =
    [
        new() { Id = 1, Title = "AtlasShrugged", Author = "AynRand", Year = 1957 },
        new() { Id = 2, Title = "Papillon", Author = "HenriCharrière", Year = 1969 },
        new() { Id = 3, Title = "SteveJobs", Author = "WalterIsaacson", Year = 2011 },
        new() { Id = 4, Title = "ElonMusk", Author = "WalterIsaacson", Year = 2023 }
    ];

    [HttpGet("")]
    public IActionResult GetAllBooks()
    {
        return Ok(_books);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBookById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if(book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpGet(("search"))]
    public IActionResult SearchBooks([FromQuery] string title,
                                     [FromQuery] string? author)
    {
        if (string.IsNullOrWhiteSpace(title))
            return BadRequest("Title is required");

        var queryBooks = _books.AsQueryable();

        queryBooks = queryBooks
            .Where(b =>
                b.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase));

        if (!string.IsNullOrWhiteSpace(author))
            queryBooks = queryBooks
                .Where(b =>
                    b.Author.Contains(author, StringComparison.CurrentCultureIgnoreCase));

        return Ok(queryBooks.ToList());
    }

    [HttpPost("")]
    public IActionResult CreateBook([FromBody] Book book)
    {
        if(string.IsNullOrWhiteSpace(book.Title))
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Title is empty");
            
        if(string.IsNullOrWhiteSpace(book.Author))
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Author is empty");
        
        if(book.Year < 1800)
            return Problem(statusCode: 400, detail: "Year can't be less than 1800");

        book.Id = _books.Count + 1;
        _books.Add(book);
        
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateBook(int id, [FromBody] Book book)
    {
        var bookToUpdate = _books.FirstOrDefault(b => b.Id == id);
        if (bookToUpdate is null)
            return Problem(statusCode: StatusCodes.Status404NotFound, detail: "Invalid id");
        
        if(string.IsNullOrWhiteSpace(book.Title))
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Title is empty");
            
        if(string.IsNullOrWhiteSpace(book.Author))
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Author is empty");
        
        if(book.Year < 1800)
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Year is less than 1800");
        
        bookToUpdate.Title = book.Title;
        bookToUpdate.Author = book.Author;
        bookToUpdate.Year = book.Year;
            
        return Ok(bookToUpdate);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book is null)
            return Problem(statusCode: StatusCodes.Status404NotFound, detail: "Invalid id");
        
        _books.Remove(book);
        
        return NoContent();
    }
}