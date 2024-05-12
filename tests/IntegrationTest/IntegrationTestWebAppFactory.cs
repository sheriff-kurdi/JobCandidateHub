using JobCandidateHub.Persistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;
using Testcontainers.Redis;


namespace JobCandidateHub.IntegrationTest;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresDbContainer = new PostgreSqlBuilder()
        .WithImage("mdillon/postgis")
        .WithDatabase("job_candidate_hub")
        .WithUsername("postgres")
        .WithPassword("123456789")
        .Build();

    private readonly RedisContainer _redisContainer = new RedisBuilder()
        .WithImage("redis:7.0")
        .Build();



    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var appDBContextDescriptor = services
            .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<CandidateHubDBContext>));

            if (appDBContextDescriptor != null)
            {
                services.Remove(appDBContextDescriptor);
            }

            services.AddDbContext<CandidateHubDBContext>(options =>
            {
                options.UseNpgsql(_postgresDbContainer.GetConnectionString())
                .UseSnakeCaseNamingConvention();
            });

            //TODO: needs to be refactored to not user service name by that way, just fast hack.
            var redisServiceName = "Microsoft.Extensions.Caching.Distributed.IDistributedCache";
            var appRedisDescriptor = services.Where(s => s.ServiceType.FullName!.Equals(redisServiceName)).FirstOrDefault();

            if (appRedisDescriptor != null)
            {
                services.Remove(appRedisDescriptor);
            }

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = _redisContainer.GetConnectionString();
                options.InstanceName = "JobCandidateHub_";
            });
        });
    }


    public async Task InitializeAsync()
    {
        await _postgresDbContainer.StartAsync();
        await _redisContainer.StartAsync();
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CandidateHubDBContext>();
        await dbContext.Database.MigrateAsync();

    }
    Task IAsyncLifetime.DisposeAsync()
    {
        return DisposeContainers();
    }
    async Task DisposeContainers()
    {
        await _postgresDbContainer.StopAsync();
        await _redisContainer.StopAsync();
    }
}