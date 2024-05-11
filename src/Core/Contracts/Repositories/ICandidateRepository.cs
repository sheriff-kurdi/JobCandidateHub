using JobCandidateHub.Core.Entities;

namespace JobCandidateHub.Core.Contracts.Repositories
{
    public interface ICandidateRepository
    {
        Task SaveAsync(Candidate candidate, CancellationToken cancellationToken);
    }
}