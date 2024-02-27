using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.Patients
{
    public interface IPatientsRepository
    {
        Task<IReadOnlyCollection<Patient>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<(IReadOnlyCollection<Patient> data, int Total)> GetPaginatedAsync(int pageIndex, int pageSize);

        Task<Patient?> GetByIdAsync(int id, bool shouldTrack = false, 
            CancellationToken cancellationToken = default);

        Task<Patient?> GetPatientInfoAsync(int id);

        Task<Patient?> GetPatientEditInfoAsync(int id);

        Task InsertAsync(Patient pateint);

        Task DeleteAsync(Patient book,
            CancellationToken cancellationToken = default);
    }
}
