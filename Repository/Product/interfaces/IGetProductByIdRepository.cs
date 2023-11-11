using ApiCrud.Models;

public interface IGetProductByIdRepository {
    Task<ProductModel> GetProducById(int id);
}