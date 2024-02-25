using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Endpoints
{
    public static class DiseasesInformationsEndPoints
    {
        public static void MapDiseasesInformationsEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/", async (IUnitOfWorks unitOfWorks) =>
            {
                var data = await unitOfWorks.DiseaseInformationsRepository.GetAllAsync();

                return Results.Ok(data);
            });
        }
    }
}
