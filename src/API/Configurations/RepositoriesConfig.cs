using JobCandidateHub.Core.Contracts.Repositories;
using Persistence.DataAccess;

namespace JobCandidateHub.API.Configurations;

public static class RepositoriesConfig
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        return services;
    }

}