using DemoCrud.Api.Repositories;

namespace DemoCrud.Api.Services;
public class ProductService(IProductElasticRepository productElasticRepository) : IProductService
{
    public Task<List<Product>> GetAllProducts() => productElasticRepository.GetAllProducts();
}
