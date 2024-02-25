using Microsoft.EntityFrameworkCore;
using PatientPortal.Api.Contexts;
using PatientPortal.Api.Endpoints;
using PatientPortal.Api.Repositories.Allergies;
using PatientPortal.Api.Repositories.DiseaseInformations;
using PatientPortal.Api.Repositories.NCDs;
using PatientPortal.Api.Repositories.Patients;
using PatientPortal.Api.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

const string connectionStrName = "PatientPortalDb";

var connectionString = builder.Configuration.GetConnectionString(connectionStrName);

//DBContext
builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddSingleton<EntityInterceptor>();

builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    var entityInterceptor = sp.GetService<EntityInterceptor>()!;

    options.UseSqlServer(connectionString)
        .AddInterceptors(entityInterceptor);
});

//Dependencies
builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();
builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();
builder.Services.AddScoped<IAllergiesRepository, AllergiesRepository>();
builder.Services.AddScoped<IDiseaseInformationsRepository, DiseaseInformationsRepository>();
builder.Services.AddScoped<INCDsRepository, NCDsRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Register Minimal API EndPoints
app
    .MapGroup("patients")
    .WithTags("Patients")
    .WithOpenApi()
    .MapPatientEndPoints();

app
    .MapGroup("allergies")
    .WithTags("Allergies")
    .WithOpenApi()
    .MapAllergiesEndPoints();

app
    .MapGroup("diseases-informations")
    .WithTags("Diseases Informations")
    .WithOpenApi()
    .MapDiseasesInformationsEndPoints();

app
    .MapGroup("ncds")
    .WithTags("NCDs")
    .WithOpenApi()
    .MapNCDsEndPoints();

app.Run();
