using Microsoft.EntityFrameworkCore;
using PatientPortal.Api.Contexts;

var builder = WebApplication.CreateBuilder(args);

const string connectionStrName = "PatientPortalDb";

var connectionString = builder.Configuration.GetConnectionString(connectionStrName);

builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddSingleton<EntityInterceptor>();

builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    var entityInterceptor = sp.GetService<EntityInterceptor>()!;

    options.UseSqlServer(connectionString)
        .AddInterceptors(entityInterceptor);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
{
    return Results.Ok();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
