using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace JobCandidateHub.UseCases.Candidates.SaveCandidate;

public record SaveCandidateCommand(SaveCandidateRequest SaveCandidateRequest) : ICommand<Result<string>>;

