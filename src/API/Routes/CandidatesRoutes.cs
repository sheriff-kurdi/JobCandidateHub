using JobCandidateHub.UseCases.Candidates.SaveCandidate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Routes;

public static class CandidatesRoutes
{
    public static void UseCandidatesRoutes(this WebApplication app)
    {
        var candidatesGroup = app.MapGroup("/api/Candidates").WithTags("Candidates");

        candidatesGroup.MapPost("/", async ([FromBody] SaveCandidateRequest saveCandidateRequest, [FromServices] IMediator mediator) =>
       {
           await mediator.Send(new SaveCandidateCommand(saveCandidateRequest));
           return Results.Ok();
       });
    }
//dotnet ef migrations add InitialMigration --context CandidateHubDBContext -p ../Kurdi.Inventory.Persistence/Kurdi.Inventory.Persistence.csproj -o Data/Migrations

}
