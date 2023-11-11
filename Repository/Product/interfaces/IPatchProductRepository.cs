using ApiCrud.Models;

public interface IPatchProductRepository {
    Task<ProductModel> UpdateProductFromId(int id, double price);
}