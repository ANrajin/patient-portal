using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.DiseaseInformations
{
    public interface IDiseaseInformationsRepository
    {
        Task<IReadOnlyCollection<DiseaseInformation>> GetAllAsync
            (CancellationToken cancellationToken = default);
    }
}
