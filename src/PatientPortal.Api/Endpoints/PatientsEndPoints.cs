﻿using Microsoft.AspNetCore.Mvc;
using PatientPortal.Api.Models;
using PatientPortal.Api.Models.PatientModels;

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

            builder.MapPost("/", async ([FromBody]PatientCreateModel patient,
                IServiceScopeFactory serviceScopeFactory) =>
            {
                try
                {
                    var validator = new PatientCreateValidator();
                    var validate = validator.Validate(patient);

                    using var serviceScope = serviceScopeFactory.CreateScope();

                    var model = serviceScope.ServiceProvider.GetRequiredService<PatientModel>();

                    if (validate.IsValid)
                    {
                        await model.CreatePatient(patient);

                        return Results.Ok();
                    }

                    return Results.BadRequest(model.PrepareValidationErrors(validate.Errors));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex);
                    return Results.Problem();
                }
            });

            builder.MapPut("/{id:int}", async (int id, PatientCreateModel patient,
                IServiceScopeFactory serviceScopeFactory) =>
            {
                try
                {
                    var validator = new PatientCreateValidator();
                    var validate = validator.Validate(patient);

                    using var serviceScope = serviceScopeFactory.CreateScope();

                    var model = serviceScope.ServiceProvider.GetRequiredService<PatientModel>();

                    if (validate.IsValid)
                    {
                        await model.UpdatePatientAsync(id, patient);

                        return Results.NoContent();
                    }

                    return Results.BadRequest(model.PrepareValidationErrors(validate.Errors));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex);
                    return Results.Problem();
                }
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
