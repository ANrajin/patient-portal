using Microsoft.AspNetCore.Mvc;
using PatientPortal.Api.Models.PatientModels;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Endpoints
{
    public static class PatientsEndPoints
    {
        public static void MapPatientEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });

            builder.MapGet("/{id:int}", async (int id, IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });

            builder.MapPost("/", async ([FromBody]PatientCreateModel model) =>
            {
                return Results.Ok();
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
