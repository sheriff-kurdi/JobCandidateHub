using JobCandidateHub.Persistence.Configurations;

namespace JobCandidateHub.API.Configurations;

public static class RedisConfig
{
    public static WebApplicationBuilder AddRedis(this WebApplicationBuilder builder)
    {
        // you can chain the exception handling with orders.
        var databaseSettings = new DatabaseSettings();
        builder.Configuration.GetSection(DatabaseSettings.DatabaseSection).Bind(databaseSettings);
        builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = databaseSettings.RedisConnectionString;
                options.InstanceName = "JobCandidateHub_";
            });
        return builder;
    }
}
