using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.ExceptionsHandling;

public class TimeOutExceptionHandler(ILogger<DefaultExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "A timeout occurred");

        if (exception is TimeoutException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500",
                Title = "An unexpected error occurred",
                Detail = "contact us for more details",
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            });
            return true;
        }
        return false;
    }
}
