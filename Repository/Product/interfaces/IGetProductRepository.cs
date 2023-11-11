using ApiCrud.Models;

public interface IGetProductRepository {
     Task<List<ProductModel>> GetProducAllAsync();
}