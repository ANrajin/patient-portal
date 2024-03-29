﻿using FluentValidation.Results;
using PatientPortal.Domain.Entities;
using PatientPortal.Domain.UnitOfWork;

namespace PatientPortal.Api.Models.PatientModels
{
    public class PatientModel(
        IUnitOfWorks unitOfWorks)
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task CreatePatient(PatientCreateModel patient)
        {
            ArgumentNullException.ThrowIfNull(patient);

            var data = PrepareEntity(patient);

            await _unitOfWorks.PatientsRepository.InsertAsync(data);
            await _unitOfWorks.SaveAsync();
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

        public async Task UpdatePatientAsync(int id, PatientCreateModel patient)
        {
            ArgumentNullException.ThrowIfNull(patient);

            var entity = await _unitOfWorks.PatientsRepository.GetPatientEditInfoAsync(id, true)
                                ?? throw new ArgumentException("Patient not found by id");

            var data = PrepareEntity(patient);

            entity.Name = data.Name;
            entity.DiseaseInformationId = data.DiseaseInformationId;
            entity.IsEpilepsy = data.IsEpilepsy;
            entity.NCDDetails = data.NCDDetails;
            entity.AllergiesDetails = data.AllergiesDetails;

            await _unitOfWorks.SaveAsync();
        }

        public async Task RemovePatientAsync(int id)
        {
            var patient = await _unitOfWorks.PatientsRepository.GetByIdAsync(id, true)
                ?? throw new ArgumentException("Patient not found by id");

            await _unitOfWorks.PatientsRepository.DeleteAsync(patient);
            await _unitOfWorks.SaveAsync();
        }

        public IList<ValidationErrorModel> PrepareValidationErrors(IList<ValidationFailure> errors)
        {
            return errors.Select(s => new ValidationErrorModel(s.PropertyName, s.ErrorMessage)).ToList();
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
