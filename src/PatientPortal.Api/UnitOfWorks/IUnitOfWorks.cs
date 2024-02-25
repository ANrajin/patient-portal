using PatientPortal.Api.Repositories.Allergies;
using PatientPortal.Api.Repositories.DiseaseInformations;
using PatientPortal.Api.Repositories.NCDs;
using PatientPortal.Api.Repositories.Patients;

namespace PatientPortal.Api.UnitOfWorks
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
