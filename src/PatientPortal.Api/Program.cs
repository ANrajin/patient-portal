using PatientPortal.Api.Endpoints;
using PatientPortal.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomainServices(builder.Configuration);

//Dependencies
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE");
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

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
