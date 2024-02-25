using PatientPortal.Api.UnitOfWorks;

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

            builder.MapPost("/", async (IUnitOfWorks unitOfWorks) =>
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
