namespace ApiCrud.Request;

public class CreateProductRequest
{
    public required string Name { get; set; }
    public required double Price { get; set; }
}