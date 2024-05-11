using JobCandidateHub.Persistence.Configurations;
using JobCandidateHub.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.API.Configurations;

public static class DatabaseConfig
{
    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        var databaseSettings = new DatabaseSettings();
        builder.Configuration.GetSection(DatabaseSettings.DatabaseSection).Bind(databaseSettings);
        builder.Services.AddDbContext<CandidateHubDBContext>(options =>
            options
            .UseNpgsql(databaseSettings.PostgresConnectionString)
            .UseSnakeCaseNamingConvention());

        return builder;
    }
}