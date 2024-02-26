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

            var data = PrepareEntity(patient);

            await _unitOfWorks.PatientsRepository.InsertAsync(data);
            await _unitOfWorks.SaveAsync();

            //var set = dbContext.DbSet<Patient>();

            //await set.AddAsync(data);
            //await dbContext.SaveAsync();
        }

        private static Patient PrepareEntity(PatientCreateModel patient)
        {
            var allergyDetails = new List<AllergiesDetail>();
            var ncdDetails = new List<NCDDetail>();

            if (patient.SelectedAllergies is not null)
            {
                foreach (var allergyId in patient.SelectedAllergies)
                {
                    allergyDetails.Add(new AllergiesDetail
                    {
                        AllergyId = allergyId,
                    });
                }
            }

            if (patient.SelectedNcds is not null)
            {
                foreach (var ncdId in patient.SelectedNcds)
                {
                    ncdDetails.Add(new NCDDetail
                    {
                        NCDId = ncdId
                    });
                }
            }

            return new Patient
            {
                Name = patient.Name,
                DiseaseInformationId = patient.DiseasesId,
                IsEpilepsy = patient.Epilepsy,
                NCDDetails = ncdDetails,
                AllergiesDetails = allergyDetails
            };
        }
    }
}
