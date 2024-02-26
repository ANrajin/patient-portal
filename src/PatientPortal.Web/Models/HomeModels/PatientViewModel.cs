
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Web.Models.HomeModels
{
    public class PatientViewModel(IUnitOfWorks unitOfWorks)
    {
        public string Name { get; set; } = string.Empty;

        public string DiseasesName { get; set; } = string.Empty;

        public string Epilepcy { get; set; } = string.Empty;

        public IList<string> NcdDetails { get; set; } = [];

        public IList<string> AllergyDetails { get; set; } = [];

        public async Task LoadModelData(int id)
        {
            var data = await unitOfWorks.PatientsRepository.GetPatientInfoAsync(id)
                ?? throw new ArgumentException("The patient not found by the id");

            Name = data.Name;

            DiseasesName = data.DiseaseInformation?.Name ?? "No Disease";

            Epilepcy = data.IsEpilepsy.ToString();

            if(data.NCDDetails != null)
            {
                NcdDetails = data.NCDDetails.Select(s => s.NCD.Name).ToList();
            }

            if(data.AllergiesDetails != null)
            {
                AllergyDetails = data.AllergiesDetails.Select(s => s.Allergy.Name).ToList();
            }
        }
    }
}
