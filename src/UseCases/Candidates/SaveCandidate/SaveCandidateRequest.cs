using JobCandidateHub.Core.Entities;

namespace JobCandidateHub.UseCases.Candidates.SaveCandidate;

public record SaveCandidateRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Email { get; set; }
    public Time? BestCallTime { get; set; }
    public string? LinkedInProfileUrl { get; set; }
    public string? GitHubProfileUrl { get; set; }
    public required string Comment { get; set; }

    public Candidate ToCandidate()
    {
        return new Candidate()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email.ToLower(),
            PhoneNumber = PhoneNumber,
            BestCallTime = BestCallTime != null ? new TimeOnly(BestCallTime.Hour, BestCallTime.Minutes) : null,
            GitHubProfileUrl = GitHubProfileUrl,
            LinkedInProfileUrl = LinkedInProfileUrl,
            Comment = Comment

        };
    }
}

public record Time
{
    public int Hour { get; set; }
    public int Minutes { get; set; }
    public required string TimeZone { get; set; }
}


