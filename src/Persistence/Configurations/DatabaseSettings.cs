

namespace JobCandidateHub.Persistence.Configurations;

public class DatabaseSettings
{
    //TODO: use user secret for database connection string
    public const string DatabaseSection = "Database";
    public string PostgresConnectionString { get; set; } = string.Empty;
    public string SqlServerConnectionString { get; set; } = string.Empty;
    public string RedisConnectionString { get; set; } = string.Empty;

}
