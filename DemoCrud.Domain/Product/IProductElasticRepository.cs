using DemoCrud.Domain.Product.Response;

namespace DemoCrud.Domain.Product;
public interface IProductElasticRepository
{
    Task<IEnumerable<ProductResponse>> GetAllProducts();
}
