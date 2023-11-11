using ApiCrud.Data;
using ApiCrud.Models;
using ApiCrud.Request;

class PostProductRepository : IPostProductRepository
{
    private readonly MyDbContext _myDbContext;

    public PostProductRepository(MyDbContext myDbContext) {
        _myDbContext = myDbContext;
    }

    public async Task CreateProduct(CreateProductRequest request)
    {
        ProductModel productModel =
            new()
            {
                Name = request.Name,
                Price = request.Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

        await _myDbContext.AddAsync(productModel);
        await _myDbContext.SaveChangesAsync();
    }
}