# JobCandidateHub
JobCandidateHub solution with C# &amp; .NET 



## Author

- [@sheriff-kurdi](https://www.github.com/sheriff-kurdi)



## Tech Stack

**DB:** PostgreSQL

**BE:** c#, Dotnet



## Used Tools

- [Dotnet](https://dotnet.microsoft.com/en-us/)

- [EFCore](https://learn.microsoft.com/en-us/ef/core/)

- [Swagger](https://github.com/swaggo/swag)

- [xUnit](https://xunit.net/)



## Running the application

To deploy this project

- create postgres database with name **job_candidate_hub**
    with credentials used in **appsettings.json.example**

- run the database migrations by
```bash
  make update-database
```
- run redis container and make sure of it's connection strings in **appsettings.json.example**
    
- navigate to API directory

```bash
  dotnet run
```



## Running Tests

To run tests, run the following command

```bash
  dotnet test
```



## Support

For support, email sheriff.kurdi@gmail.com




## 🔗 Links
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/sheriff-kurdi)
[![twitter](https://img.shields.io/badge/twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/sheriffKurdi)




## Linces

This project linced with MIT

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
