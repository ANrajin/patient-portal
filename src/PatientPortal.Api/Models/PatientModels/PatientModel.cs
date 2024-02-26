using FluentValidation.Results;
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

        public async Task<object> GetPatientsAsync(DatatableModel dataTableModel)
        {
            var (data, total) = await _unitOfWorks.PatientsRepository.GetPaginatedAsync(
                dataTableModel.PageIndex, 
                dataTableModel.PageSize);

            return new
            {
                recordsTotal = total,
                recordsFiltered = data.Count,
                data = (from item in data
                        select new string[]
                {
                    item.Name,
                    item.DiseaseInformation?.Name ?? "-",
                    item.IsEpilepsy.ToString(),
                    item.Id.ToString()
                }).ToArray()
            };
        }

        public async Task RemovePatientAsync(int id)
        {
            var patient = await _unitOfWorks.PatientsRepository.GetByIdAsync(id, true)
                ?? throw new ArgumentException("Patient not found by id");

            await _unitOfWorks.PatientsRepository.DeleteAsync(patient);
            await _unitOfWorks.SaveAsync();
        }

        internal IList<ValidationErrorModel> CreateValidationErrors(IList<ValidationFailure> errors)
        {
            return errors.Select(s => new ValidationErrorModel(s.PropertyName, s.ErrorMessage)).ToList();
        }
    }
}
