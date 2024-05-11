using JobCandidateHub.Core.Contracts.Repositories;
using JobCandidateHub.Core.Entities;
using JobCandidateHub.Persistence.Data;
using JobCandidateHub.Persistence.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Persistence.DataAccess
{
    public class CandidateRepository(CandidateHubDBContext candidateHubDBContext, IDistributedCache cache) : ICandidateRepository
    {
        public async Task SaveAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            var cachedCandidate = await cache.GetRecordAsync<Candidate>(candidate.Email, cancellationToken).ConfigureAwait(false);
            if (cachedCandidate is not null)
            {
                candidateHubDBContext.Candidates.Update(candidate);
            }
            else
            {
                if (candidateHubDBContext.Candidates.Any(candidate => candidate.Email == candidate.Email))
                {
                    candidateHubDBContext.Candidates.Update(candidate);
                }
                else
                {
                    candidateHubDBContext.Candidates.Add(candidate);
                }
            }

            await candidateHubDBContext.SaveChangesAsync(cancellationToken);

            await cache.SetRecordAsync(candidate.Email, candidate, cancellationToken).ConfigureAwait(false);
        }
    }
}