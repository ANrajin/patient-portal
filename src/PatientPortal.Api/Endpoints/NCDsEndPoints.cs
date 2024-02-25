using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Endpoints
{
    public static class NCDsEndPoints
    {
        public static void MapNCDsEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                var data = await unitOfWorks.NcdsRepository.GetAllAsync();

                return Results.Ok(data);
            });
        }
    }
}
