using JobCandidateHub.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobCandidateHub.Persistence.Data.Configurations;

public class CandidatesConfigurations : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.HasKey(candidate => candidate.Email);
    }
}
