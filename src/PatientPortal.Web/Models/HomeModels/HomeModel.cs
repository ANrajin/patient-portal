﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
            var allergyTask = unitOfWorks.AllergiesRepository.GetSelectListItemsAsync();
            var ncdTask = unitOfWorks.NcdsRepository.GetSelectListItemsAsync();
            var diseaseInfoTask = unitOfWorks.DiseaseInformationsRepository.GetSelectListItemsAsync();

            await Task.WhenAll(allergyTask, ncdTask, diseaseInfoTask);

            AllergiesList = allergyTask.Result.Select(s => new SelectListItem
            {
                Value = s.Value,
                Text = s.Text,
            }).ToList();

            NcdList = ncdTask.Result.Select(s => new SelectListItem
            {
                Value = s.Value,
                Text = s.Text,
            }).ToList();

            DiseasesInfoList = diseaseInfoTask.Result.Select(s => new SelectListItem
            {
                Value = s.Value,
                Text = s.Text,
            }).ToList();
        }
    }
}
