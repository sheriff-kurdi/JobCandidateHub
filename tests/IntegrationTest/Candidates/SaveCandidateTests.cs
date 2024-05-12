using System.Net.Http.Json;
using JobCandidateHub.UseCases.Candidates.SaveCandidate;

namespace JobCandidateHub.IntegrationTest.Candidates;

public class SaveCandidateTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest
{
    [Fact]
    public async Task SaveCandidate_Test()
    {
        // Arrange
        var client = factory.CreateClient();
        string url = "/api/Candidates";
        var candidate = new SaveCandidateRequest
        {
            FirstName = "Sheriff",
            LastName = "Kurdi",
            Email = "sheriff.kurdi@gmail.com",//TODO: handle case sensitive!
            PhoneNumber = "+0201014409847",
            GitHubProfileUrl = "https://github.com/sheriff-kurdi",
            Comment = "comment" //TODO: handle empty!
        };

        JsonContent content = JsonContent.Create(candidate);

        // Act
        var response = await client.PostAsync(url, content);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
