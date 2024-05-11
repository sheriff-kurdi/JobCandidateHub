using JobCandidateHub.UseCases.Candidates.SaveCandidate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Routes;

public static class CandidatesRoutes
{
    public static void UseCandidatesRoutes(this WebApplication app)
    {
        var candidatesGroup = app.MapGroup("/api/Candidates").WithTags("Candidates");

        candidatesGroup.MapPost("/", SaveCandidateAsync)
            .WithName("Save Candidate")
            .WithOpenApi();
    }

    private static async Task<IResult> SaveCandidateAsync([FromBody] SaveCandidateRequest saveCandidateRequest, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new SaveCandidateCommand(saveCandidateRequest));
        if (!result.IsSuccess)
        {
            return Results.BadRequest(result.Errors);
        }
        return Results.Ok(result.SuccessMessage);
    }
}
