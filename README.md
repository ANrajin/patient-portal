# Patient Portal
This is a small patient information portal that is developed using C# 12, Asp .NET Core MVC, Asp .NET Core Web API, EF Core and MSSQL server.

### Folder Structure
- src
    - PatientPortal.Domain
    - PatientPortal.Api
    - PatientPortal.Web

- tests
    - PatientPortal.Api.Tests

### Migration Commands

```bash
dotnet ef migrations add CreateApplicationsTable -p src/libraries/PatientPortal.Domain -c ApplicationDbContext -s src/PatientPortal.Api
```

```bash
dotnet ef database update -p src/libraries/PatientPortal.Domain -c ApplicationDbContext -s src/PatientPortal.Api
```

