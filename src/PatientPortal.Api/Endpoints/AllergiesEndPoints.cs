using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Endpoints
{
    public static class AllergiesEndPoints
    {
        public static void MapAllergiesEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                var data = await unitOfWorks.AllergiesRepository.GetAllAsync();

                return Results.Ok(data);
            });
        }
    }
}
