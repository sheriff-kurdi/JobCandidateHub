using JobCandidateHub.Core.Entities;

namespace JobCandidateHub.UseCases.Candidates.SaveCandidate;

public record SaveCandidateRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Email { get; set; }
    public TimeSpan? BestCallTime { get; set; }
    public string? LinkedInProfileUrl { get; set; }
    public string? GitHubProfileUrl { get; set; }
    public required string Comment { get; set; }

    public Candidate ToCandidate()
    {
        return new Candidate()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            GitHubProfileUrl = GitHubProfileUrl,
            LinkedInProfileUrl = LinkedInProfileUrl,
            Comment = Comment

        };
    }
}


