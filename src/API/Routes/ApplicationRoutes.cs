namespace JobCandidateHub.API.Routes;

public static class ApplicationRoutes
{
    public static void UseApplicationRoutes(this WebApplication app)
    {
        app.UseCandidatesRoutes();


    }
}
