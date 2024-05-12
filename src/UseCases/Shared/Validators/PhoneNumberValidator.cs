using FluentValidation;

namespace JobCandidateHub.UseCases.Shared.Validators;

public class PhoneNumberValidator : AbstractValidator<string>
{
    public PhoneNumberValidator()
    {
        RuleFor(phoneNumber => phoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+(?:[0-9]?){6,14}[0-9]$").WithMessage("Invalid phone number format, Please insert valid phone number with the country code.");
    }
}