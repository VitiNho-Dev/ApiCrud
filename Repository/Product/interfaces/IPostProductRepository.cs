using ApiCrud.Request;

public interface IPostProductRepository {
    Task CreateProduct(CreateProductRequest request);
}