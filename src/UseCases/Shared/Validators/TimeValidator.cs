using FluentValidation;
using JobCandidateHub.UseCases.Candidates.SaveCandidate;

namespace UseCases.Shared.Validators;
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
    public static bool ValidTimeZone(string? timeZone)
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
