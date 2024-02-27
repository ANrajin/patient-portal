using Microsoft.AspNetCore.Mvc.Rendering;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Web.Models.HomeModels
{
    public sealed class PatientEditModel(IUnitOfWorks unitOfWorks)
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IList<SelectListItem> EpilepcyList { get; set; } = [];

        public IList<SelectListItem> AllergiesList { get; set; } = [];

        public IList<SelectListItem> NcdList { get; set; } = [];

        public IList<SelectListItem> DiseasesInfoList { get; set; } = [];

        public async Task LoadModelData(int id)
        {
            var data = await unitOfWorks.PatientsRepository.GetPatientEditInfoAsync(id)
                ?? throw new ArgumentException("The patient not found by the id");

            var allergyTask = await unitOfWorks.AllergiesRepository.GetSelectListItemsAsync();
            var ncdTask = await unitOfWorks.NcdsRepository.GetSelectListItemsAsync();
            var diseaseInfoTask = await unitOfWorks.DiseaseInformationsRepository.GetSelectListItemsAsync();

            DiseasesInfoList = diseaseInfoTask.Select(s => new SelectListItem
            {
                Text = s.Text,
                Value = s.Value.ToString(),
                Selected = data.DiseaseInformationId.Equals(s.Value)
            }).ToList();

            NcdList = ncdTask.Select(s => new SelectListItem
            {
                Text = s.Text,
                Value = s.Value.ToString(),
                Selected = data.AllergiesDetails.Any(x => x.AllergyId.Equals(s.Value))
            }).ToList();

            AllergiesList = allergyTask.Select(s => new SelectListItem 
            { 
                Text = s.Text, 
                Value = s.Value.ToString(),
                Selected = data.AllergiesDetails.Any(x => x.AllergyId.Equals(s.Value))
            }).ToList();
        }
    }
}
