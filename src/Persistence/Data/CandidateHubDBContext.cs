using JobCandidateHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Persistence.Data;

public class CandidateHubDBContext(DbContextOptions<CandidateHubDBContext> options) : DbContext(options)
{
    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        //DatabaseSettings databaseSettings = configuration.Value;

        //options.UseSqlServer(databaseSettings.SqlServerConnectionString);
        //options.UseNpgsql(databaseSettings.PostgresConnectionString).UseSnakeCaseNamingConvention();

    }
}
