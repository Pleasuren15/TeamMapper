### Command Dump

#### Entity Framework Core

- The following commands must be ran on the root of the project
- *dotnet ef migrations add InitialCreate --project src/team-mapper-infrastructure --startup-project src/team-mapper-api --output-dir Migrations*
- *dotnet ef database update --project src/team-mapper-infrastructure --startup-project src/team-mapper-api*