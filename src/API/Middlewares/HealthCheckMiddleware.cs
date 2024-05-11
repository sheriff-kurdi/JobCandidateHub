using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace API.Middlewares;

public static class HealthCheckMiddleware
{
    public static void UseHealthCheckMiddleware(this WebApplication app)
    {
        app.MapHealthChecks("health", new HealthCheckOptions()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}
