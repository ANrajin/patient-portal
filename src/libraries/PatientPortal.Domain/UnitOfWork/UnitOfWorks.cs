using PatientPortal.Domain.Contexts;
using PatientPortal.Domain.Repositories.Allergies;
using PatientPortal.Domain.Repositories.DiseaseInformations;
using PatientPortal.Domain.Repositories.NCDs;
using PatientPortal.Domain.Repositories.Patients;

namespace PatientPortal.Domain.UnitOfWork
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
