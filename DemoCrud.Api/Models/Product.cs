//namespace DemoCrud.Api.Models;
//public class Product
//{
//    public string? Partnumber { get; set; }
//    public Guid GrupoProdutoId { get; set; }
//    public string? DescricaoFrota { get; set; }
//    public DateTime DataCadastro { get; set; }
//    public string? Status { get; set; }
//    public Guid MercadoId { get; set; }

//    public Product(string partnumber, Guid grupoProdutoId, string descricaoFrota, DateTime dataCadastro, string status, Guid mercadoId)
//    {
//        Partnumber = partnumber;
//        GrupoProdutoId = grupoProdutoId;
//        DescricaoFrota = descricaoFrota;
//        DataCadastro = dataCadastro;
//        Status = status;
//        MercadoId = mercadoId;
//    }
//}

using Nest;

namespace DemoCrud.Api.Models
{
    [ElasticsearchType(Name = "produto")] // Nome do tipo no Elasticsearch
    public class Product
    {
        [Text(Name = "Partnumber")] // Mapeamento do campo Partnumber
        public string Partnumber { get; set; }

        [Keyword(Name = "GrupoProdutoId")] // Mapeamento do campo GrupoProdutoId
        public Guid GrupoProdutoId { get; set; }

        [Text(Name = "DescricaoFrota")] // Mapeamento do campo DescricaoFrota
        public string DescricaoFrota { get; set; }

        [Date(Name = "DataCadastro")] // Mapeamento do campo DataCadastro
        public DateTime DataCadastro { get; set; }

        [Keyword(Name = "Status")] // Mapeamento do campo Status
        public string Status { get; set; }

        [Keyword(Name = "MercadoId")] // Mapeamento do campo MercadoId
        public Guid MercadoId { get; set; }

        // Construtor padrão para a desserialização
        public Product() { }

        public Product(string partnumber, Guid grupoProdutoId, string descricaoFrota, DateTime dataCadastro, string status, Guid mercadoId)
        {
            Partnumber = partnumber;
            GrupoProdutoId = grupoProdutoId;
            DescricaoFrota = descricaoFrota;
            DataCadastro = dataCadastro;
            Status = status;
            MercadoId = mercadoId;
        }
    }
}
