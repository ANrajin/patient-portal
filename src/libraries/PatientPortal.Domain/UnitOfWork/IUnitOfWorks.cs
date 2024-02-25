using PatientPortal.Domain.Repositories.Allergies;
using PatientPortal.Domain.Repositories.DiseaseInformations;
using PatientPortal.Domain.Repositories.NCDs;
using PatientPortal.Domain.Repositories.Patients;

namespace PatientPortal.Domain.UnitOfWork
{
    public interface IUnitOfWorks
    {
        Task SaveAsync(CancellationToken cancellationToken = default);

        IPatientsRepository PatientsRepository { get; }

        IAllergiesRepository AllergiesRepository { get; }

        IDiseaseInformationsRepository DiseaseInformationsRepository { get; }

        INCDsRepository NcdsRepository { get; }
    }
}
