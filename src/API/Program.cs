using API.Middlewares;
using JobCandidateHub.API.Configurations;
using JobCandidateHub.API.Routes;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

#region services injection
builder.Services.AddMediator();
builder.Services.AddFluentValidation();
builder.Services.AddSettings();
builder.Services.AddCustomExceptionsHandling();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.AddDatabase();
builder.AddRedis();
#endregion


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(opt => { });
app.UseHttpsRedirection();
app.UseHealthCheckMiddleware();


app.UseApplicationRoutes();


app.Run();

// for exposing to Integration test
public partial class Program { }

