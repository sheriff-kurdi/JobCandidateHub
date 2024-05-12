using FluentValidation;
using JobCandidateHub.UseCases.Shared.Validators;
using UseCases.Shared.Validators;

namespace JobCandidateHub.UseCases.Candidates.SaveCandidate;

public class SaveCandidateValidator : AbstractValidator<SaveCandidateRequest>
{
    public SaveCandidateValidator()
    {
        //TODO: Validate Phone.
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress()
            .WithMessage("A valid email is required");
        RuleFor(x => x.Comment).NotEmpty();


        When(x => x.BestCallTime != null, () =>
        {
            RuleFor(x => x.BestCallTime)
                .SetValidator(new TimeValidator()!);
        });

        When(x => x.PhoneNumber != null, () =>
        {
            RuleFor(x => x.PhoneNumber)
                .SetValidator(new PhoneNumberValidator()!);
        });

    }


}
