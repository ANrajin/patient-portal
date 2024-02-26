using PatientPortal.Domain.Entities;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Models.PatientModels
{
    public sealed class PatientModel(
        IUnitOfWorks unitOfWorks)
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task CreatePatient(PatientCreateModel patient)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(patient));

            var entity = new Patient
            {
                Name = patient.Name,
                DiseaseInformationId = patient.DiseasesId,
                IsEpilepsy = patient.Epilepsy,
            };

            await _unitOfWorks.PatientsRepository.InsertAsync(entity);
        }
    }
}
