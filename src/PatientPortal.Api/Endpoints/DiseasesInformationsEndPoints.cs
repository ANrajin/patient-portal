using PatientPortal.Api.UnitOfWorks;

namespace PatientPortal.Api.Endpoints
{
    public static class DiseasesInformationsEndPoints
    {
        public static void MapDiseasesInformationsEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });
        }
    }
}
