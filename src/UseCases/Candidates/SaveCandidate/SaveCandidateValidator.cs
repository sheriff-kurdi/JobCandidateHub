using FluentValidation;

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
public class TimeValidator : AbstractValidator<Time>
{

    public TimeValidator()
    {
        RuleFor(x => x.Hour).LessThanOrEqualTo(24).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Minutes).LessThanOrEqualTo(60).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TimeZone).Must(x => ValidTimeZone(x)).WithMessage("Invalid timezone.");

    }

    /// <summary>
    /// to populate list of time zones for user
    ///var timezones =TimeZoneInfo.GetSystemTimeZones().Select(timeZone=> timeZone.Id);
    /// </summary>
    private static bool ValidTimeZone(string? timeZone)
    {
        if (timeZone is null) return true;
        try
        {
            TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
public class PhoneNumberValidator : AbstractValidator<string>
{
    public PhoneNumberValidator()
    {
        RuleFor(phoneNumber => phoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+(?:[0-9]?){6,14}[0-9]$").WithMessage("Invalid phone number format, Please insert valid phone number with the country code.");
    }
}