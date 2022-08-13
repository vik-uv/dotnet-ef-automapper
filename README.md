# dotnet-ef-automapper
It's a test projec to check the possibility of .NET libraries:

- Entity Framework Core (connection to MS SQL)
- AutoMapper (with DTO models projecting on EF)
- CQRS pattern based on MediatR (very simple implementation, only one pipeline)

## How to start the application
You need add a connection string to *application.json* file and after create the database 

`dotnet ef database update`

When you start the project, you run check API methods in Swagger. Generated SQL queries are available in console logs.