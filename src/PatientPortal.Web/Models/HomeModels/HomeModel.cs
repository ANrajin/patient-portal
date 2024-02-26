using Microsoft.AspNetCore.Mvc.Rendering;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Web.Models.HomeModels
{
    public sealed class HomeModel(IUnitOfWorks unitOfWorks)
    {
        public IList<SelectListItem> AllergiesList { get; set; } = [];

        public IList<SelectListItem> NcdList { get; set; } = [];

        public IList<SelectListItem> DiseasesInfoList { get; set; } = [];

        public async Task LoadModelData()
        {
            var allergyTask = await unitOfWorks.AllergiesRepository.GetSelectListItemsAsync();
            var ncdTask = await unitOfWorks.NcdsRepository.GetSelectListItemsAsync();
            var diseaseInfoTask = await unitOfWorks.DiseaseInformationsRepository.GetSelectListItemsAsync();

            AllergiesList = allergyTask.Select(s => new SelectListItem
            {
                Value = s.Value,
                Text = s.Text,
            }).ToList();

            NcdList = ncdTask.Select(s => new SelectListItem
            {
                Value = s.Value,
                Text = s.Text,
            }).ToList();

            DiseasesInfoList = diseaseInfoTask.Select(s => new SelectListItem
            {
                Value = s.Value,
                Text = s.Text,
            }).ToList();
        }
    }
}
