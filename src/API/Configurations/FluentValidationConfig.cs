using System.Reflection;
using FluentValidation;
using JobCandidateHub.UseCases;

namespace JobCandidateHub.API.Configurations;

public static class FluentValidationConfig
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(UseCaseRoot).GetTypeInfo().Assembly,
            includeInternalTypes: true);
        return services;
    }
}