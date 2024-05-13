using Microsoft.Azure.Cosmos;

namespace ApplicationFormAPI.Infrastructure._DI
{
    public static class CosmosDb
    {
        public static void ConfigureCosmos(this IServiceCollection serviceCollection, IConfiguration _config)
        {
            serviceCollection.AddOptions<CosmosConfig>().BindConfiguration("CosmosDB");
            var cosmosConfig = new CosmosConfig();
            _config.GetSection("CosmosDB").Bind(cosmosConfig);

            if (string.IsNullOrEmpty(cosmosConfig.Endpoint) || string.IsNullOrEmpty(cosmosConfig.PrimaryKey)
                || string.IsNullOrEmpty(cosmosConfig.DatabaseId))
            {
                throw new Exception("Unable to read cosmos database config");
            }

            var cosmosClient = new CosmosClient(cosmosConfig.Endpoint, cosmosConfig.PrimaryKey, new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
                }
            });

            serviceCollection.AddSingleton(cosmosClient);

            serviceCollection.AddSingleton<CosmosDbUnitOfWork>();
        }
    }

    public class CosmosConfig
    {
        public string? Endpoint { get; set; }
        public string? PrimaryKey { get; set; }
        public string? DatabaseId { get; set; }
        public string? ContainerId { get; set; }
    }

}
