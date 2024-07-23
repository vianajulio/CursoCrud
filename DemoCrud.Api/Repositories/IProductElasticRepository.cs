namespace DemoCrud.Api.Repositories;
public interface IProductElasticRepository
{
    Task<List<Product>> GetAllProducts();
}
