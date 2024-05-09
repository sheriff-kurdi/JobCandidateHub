using FluentValidation;

namespace JobCandidateHub.UseCases.Candidates.SaveCandidate;

public class SaveCandidateValidator : AbstractValidator<SaveCandidateRequest>
{
    public SaveCandidateValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required")
            .EmailAddress()
            .WithMessage("A valid email is required");
        RuleFor(x => x.Comment).NotEmpty();

    }
}
