using Microsoft.AspNetCore.Mvc;
using PatientPortal.Api.Models;
using PatientPortal.Api.Models.PatientModels;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Endpoints
{
    public static class PatientsEndPoints
    {
        public static void MapPatientEndPoints(this IEndpointRouteBuilder builder,
            ILogger logger)
        {
            builder.MapGet("/", async (HttpRequest request,
                IServiceScopeFactory serviceScopeFactory) =>
            {
                var dataTableModel = new DatatableModel(
                    Convert.ToInt32(request.Query["start"]),
                    Convert.ToInt32(request.Query["length"]));

                using var serviceScope = serviceScopeFactory.CreateScope();

                var model = serviceScope.ServiceProvider.GetRequiredService<PatientModel>();

                var data = await model.GetPatientsAsync(dataTableModel);

                return Results.Ok(data);
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

            builder.MapDelete("/{id:int}", async (int id,
                IServiceScopeFactory serviceScopeFactory) =>
            {
                try
                {
                    using var serviceScope = serviceScopeFactory.CreateScope();

                    var model = serviceScope.ServiceProvider.GetRequiredService<PatientModel>();

                    await model.RemovePatientAsync(id);

                    return Results.NoContent();
                }
                catch(Exception ex)
                {
                    logger.LogError(ex.Message, ex);
                    return Results.Problem();
                }
            });
        }
    }
}
