using JobCandidateHub.API.ExceptionsHandling;

namespace JobCandidateHub.API.Configurations;

public static class ExceptionsHandlingConfig
{
    public static IServiceCollection AddCustomExceptionsHandling(this IServiceCollection services)
    {
        // you can chain the exception handling with orders.
        services.AddExceptionHandler<TimeOutExceptionHandler>();
        services.AddExceptionHandler<DefaultExceptionHandler>();
        return services;
    }
}
