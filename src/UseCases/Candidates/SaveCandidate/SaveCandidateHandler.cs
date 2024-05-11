using FluentValidation;
using FluentValidation.Results;
using JobCandidateHub.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace JobCandidateHub.UseCases.Candidates.SaveCandidate;

public class SaveCandidateHandler(ICandidateRepository candidateRepository, IValidator<SaveCandidateRequest> validator)
    : ICommandHandler<SaveCandidateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SaveCandidateCommand request, CancellationToken cancellationToken)
    {
        //validating.
        ValidationResult validationResult = await validator.ValidateAsync(request.SaveCandidateRequest, cancellationToken).ConfigureAwait(false);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        //saving logic.
        await candidateRepository.SaveAsync(request.SaveCandidateRequest.ToCandidate(), cancellationToken).ConfigureAwait(false);

        //result.
        var message = $"Candidate {request.SaveCandidateRequest.FirstName} {request.SaveCandidateRequest.LastName} has been saved successfully";
        return Result.SuccessWithMessage(message);
    }
}
