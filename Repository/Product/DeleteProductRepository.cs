using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

class DeleteProductRepository : IDeleteProductRepository
{
    private readonly MyDbContext _myDbContext;

    public DeleteProductRepository(MyDbContext myDbContext){
        _myDbContext = myDbContext;
    }

    public async Task DeleteProductFromId(int id) {
        var response = await _myDbContext.Product.FirstAsync(key => key.Id == id);
            _myDbContext.Product.Remove(response);
            await _myDbContext.SaveChangesAsync();
    }
}