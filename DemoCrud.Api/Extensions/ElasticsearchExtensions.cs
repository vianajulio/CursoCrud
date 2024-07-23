using Elasticsearch.Net;
using Nest;

namespace DemoCrud.Api.Extensions;
public static class ElasticsearchExtensions
{
    public static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        // Configurações appsettings.json
        ArgumentException.ThrowIfNullOrEmpty("ElasticsearchSettings:CloundId");
        ArgumentException.ThrowIfNullOrEmpty("ElasticsearchSettings:Username");
        ArgumentException.ThrowIfNullOrEmpty("ElasticsearchSettings:Password");

        var cloundId = configuration["ElasticsearchSettings:CloundId"];
        var basicAuthUser= configuration["ElasticsearchSettings:Username"];
        var basicAuthPassword= configuration["ElasticsearchSettings:Password"];

        //config de autenticacao
        var settings = new ConnectionSettings(new CloudConnectionPool(cloundId,
            new BasicAuthenticationCredentials(basicAuthUser,basicAuthPassword)));

        settings.EnableHttpCompression();

        var client = new ElasticClient(settings);

        services.AddSingleton<IElasticClient>(client);

        return services;
    }
}
