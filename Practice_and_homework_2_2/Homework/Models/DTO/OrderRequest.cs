namespace Homework.Models.DTO;

public class OrderRequest
{
    public required string Number { get; set; }
    
    public required decimal Total { get; set; }
}