using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.Patients
{
    public interface IPatientsRepository
    {
        Task<IReadOnlyCollection<Patient>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Patient?> GetByIdAsync(Guid id, bool shouldTrack = false, 
            CancellationToken cancellationToken = default);

        Task InsertAsync(Patient pateint,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(Patient book,
            CancellationToken cancellationToken = default);
    }
}
