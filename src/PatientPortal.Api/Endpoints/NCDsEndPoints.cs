using PatientPortal.Api.UnitOfWorks;

namespace PatientPortal.Api.Endpoints
{
    public static class NCDsEndPoints
    {
        public static void MapNCDsEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });
        }
    }
}
