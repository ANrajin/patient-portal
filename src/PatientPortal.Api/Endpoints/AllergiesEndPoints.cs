using PatientPortal.Api.UnitOfWorks;

namespace PatientPortal.Api.Endpoints
{
    public static class AllergiesEndPoints
    {
        public static void MapAllergiesEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                return Results.Ok();
            });
        }
    }
}
