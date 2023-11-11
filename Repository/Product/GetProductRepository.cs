using ApiCrud.Data;
using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

class GetProductRepository : IGetProductRepository
{
    private readonly MyDbContext _myDbContext;

    public GetProductRepository(MyDbContext myDbContext) {
        _myDbContext = myDbContext;
    }

    public async Task<List<ProductModel>> GetProducAllAsync() {
        var response = await _myDbContext.Product.ToListAsync();

        return response;
    }
}