using ApiCrud.Data;
using ApiCrud.Models;

class PatchProductRepository : IPatchProductRepository
{
    private readonly MyDbContext _myDbContext;

    public PatchProductRepository(MyDbContext myDbContext) {
        _myDbContext = myDbContext;
    }

    public async Task<ProductModel> UpdateProductFromId(int id, double price)
    {
        var response = await _myDbContext.Product.FindAsync(id);
        response!.Price = price;

        await _myDbContext.SaveChangesAsync();

        return response;
    }
}