using JobCandidateHub.Persistence.Configurations;

namespace JobCandidateHub.API.Configurations;

public static class SettingsConfig
{
    public static IServiceCollection AddSettings(this IServiceCollection services)
    {
        services.AddOptions<DatabaseSettings>()
            .BindConfiguration(DatabaseSettings.DatabaseSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return services;
    }
}