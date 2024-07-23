namespace DemoCrud.Api.Services;
public interface IProductService
{
    Task<List<Product>> GetAllProducts();
}
