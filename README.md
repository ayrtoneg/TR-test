## Technologies implemented:

- .NET Core 3.1
- ASP.NET MVC Core 
- ASP.NET WebApi Core
- Entity Framework Core 3.1
- .NET Core Native DI
- FluentValidator
- MediatR
- Swagger UI
- NUnit

## Architecture:

- Microservice architecture with logical separation using SOLID and Clean Code
- Domain Driven Design
- CQRS
- Unit of Work
- Repository

## How to use:

**Manually**
- You will need the latest Visual Studio 2019, the latest .NET Core SDK and Sql Server 2018 or latest.
- Create a new database called LegalCase or adjust the database in the connection string.
- Open Package Manager Console
- Type "Add-Migration Initial"
- Type "Update-Database"
- Run project

**Docker**
- Open Command Line Interface and go to the "docker" path in the project
- Type "docker-compose -f officeslegalcase.yml up --build"

## How to test:
- Open Package Manager Console
- Select "OLC.Test" project 
- Type "dotnet test"
