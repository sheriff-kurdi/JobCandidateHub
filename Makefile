add-migration:
	dotnet ef migrations add $(name) --context CandidateHubDBContext -p src/Persistence -o Data/Migrations --startup-project src/API

update-database:
	dotnet ef database update --context  CandidateHubDBContext  -p src/Persistence --startup-project src/API
