using ApiCrud.Data;
using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

class GetProductByIdRepository : IGetProductByIdRepository
{
    private readonly MyDbContext _myDbContext;

    public GetProductByIdRepository(MyDbContext myDbContext) {
        _myDbContext = myDbContext;
    }

    public async Task<ProductModel> GetProducById(int id) {
         var response = await _myDbContext.Product.FirstAsync(key => key.Id == id);

        return response;
    }
}