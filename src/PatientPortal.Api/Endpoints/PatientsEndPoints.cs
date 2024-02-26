using Microsoft.AspNetCore.Mvc;
using PatientPortal.Api.Models.PatientModels;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Endpoints
{
    public static class PatientsEndPoints
    {
        public static void MapPatientEndPoints(this IEndpointRouteBuilder builder,
            ILogger logger)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });

            builder.MapGet("/{id:int}", async (int id, IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });

            builder.MapPost("/", async ([FromBody]PatientCreateModel patient,
                IServiceScopeFactory serviceScopeFactory) =>
            {
                try
                {
                    using var serviceScope = serviceScopeFactory.CreateScope();

                    var model = serviceScope.ServiceProvider.GetRequiredService<PatientModel>();

                    await model.CreatePatient(patient);

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex);
                    return Results.Problem();
                }
            });

            builder.MapPut("/{id:int}", async (int id, IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });

            builder.MapDelete("/{id:int}", async (int id, IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });
        }
    }
}
