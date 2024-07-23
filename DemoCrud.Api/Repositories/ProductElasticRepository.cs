using Nest;

namespace DemoCrud.Api.Repositories;
public class ProductElasticRepository : IProductElasticRepository
{
    private readonly IElasticClient _elasticClient;
    private readonly string? _indexName;

    public ProductElasticRepository(IElasticClient elasticClient, IConfiguration configuration)
    {
        _elasticClient = elasticClient;
        _indexName = configuration["IndexSettings:ProductIndexName"];
    }

    public async Task<List<Product>> GetAllProducts()
    {
        var response = await _elasticClient.SearchAsync<Product>(x => x
            .Index(_indexName)
            .From(0)
            .Size(10)
            .Query(q => q
                .Prefix(p => p
                    .Field(f => f.Partnumber)
                    .Value("123")
                )
            )
        );

        if (response.IsValid)
        {
            return response.Documents.ToList();
        }

        return new List<Product>();
    }
}
