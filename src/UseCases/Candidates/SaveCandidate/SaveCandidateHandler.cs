using FluentValidation;
using FluentValidation.Results;
using JobCandidateHub.Persistence.Data;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.UseCases.Candidates.SaveCandidate;

public class SaveCandidateHandler(CandidateHubDBContext candidateHubDBContext, IValidator<SaveCandidateRequest> validator)
    : ICommandHandler<SaveCandidateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SaveCandidateCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request.SaveCandidateRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        //TODO: saving logic.
        if (candidateHubDBContext.Candidates.Any(candidate => candidate.Email == request.SaveCandidateRequest.Email))
        {
            candidateHubDBContext.Candidates.Update(request.SaveCandidateRequest.ToCandidate());
        }

        candidateHubDBContext.Candidates.Add(request.SaveCandidateRequest.ToCandidate());

        await candidateHubDBContext.SaveChangesAsync(cancellationToken);
        var message = $"Candidate {request.SaveCandidateRequest.FirstName} {request.SaveCandidateRequest.LastName} has been saved successfully";
        return Result.Success(message);
    }
}
