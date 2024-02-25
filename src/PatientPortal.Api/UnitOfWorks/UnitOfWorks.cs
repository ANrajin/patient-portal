using PatientPortal.Api.Contexts;
using PatientPortal.Api.Repositories.Allergies;
using PatientPortal.Api.Repositories.DiseaseInformations;
using PatientPortal.Api.Repositories.NCDs;
using PatientPortal.Api.Repositories.Patients;

namespace PatientPortal.Api.UnitOfWorks
{
    public class UnitOfWorks(
        IApplicationDbContext applicationDbContext,
        IPatientsRepository patientsRepository,
        IAllergiesRepository allergiesRepository,
        IDiseaseInformationsRepository diseaseInformationsRepository,
        INCDsRepository ncdsRepository)
        : IUnitOfWorks
    {
        public IPatientsRepository PatientsRepository { get; } = patientsRepository;
        public IAllergiesRepository AllergiesRepository { get; } = allergiesRepository;
        public IDiseaseInformationsRepository DiseaseInformationsRepository { get; } = diseaseInformationsRepository;
        public INCDsRepository NcdsRepository { get; } = ncdsRepository;

        public async Task SaveAsync(CancellationToken cancellationToken = default) =>
            await applicationDbContext.SaveAsync(cancellationToken);
    }
}
