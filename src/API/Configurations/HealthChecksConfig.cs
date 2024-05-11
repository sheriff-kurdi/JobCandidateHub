using JobCandidateHub.Persistence.Data;

namespace JobCandidateHub.API.Configurations;

public static class HealthChecksConfig
{
    public static IServiceCollection AddConfiguredHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<CandidateHubDBContext>();
        return services;
    }

}
