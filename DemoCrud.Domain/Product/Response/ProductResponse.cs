namespace DemoCrud.Domain.Product.Response;
public class ProductResponse
{
    public string? Partnumber { get; set; }
    public Guid GrupoProdutoId { get; set; }
    public string? DescricaoFrota { get; set; }
    public DateTime DataCadastro { get; set; }
    public string? Status { get; set; }
}
