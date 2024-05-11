using System.Reflection;
using JobCandidateHub.Core;
using JobCandidateHub.UseCases;

namespace JobCandidateHub.API.Configurations;

public static class MediatorConfig
{
    private static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(UseCaseRoot).GetTypeInfo().Assembly;
        yield return typeof(CoreRoot).GetTypeInfo().Assembly;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(GetAssemblies().ToArray()));
        return services;
    }
}