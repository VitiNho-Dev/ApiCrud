namespace ApiCrud.Models;

public class ProductModel
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public double Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}