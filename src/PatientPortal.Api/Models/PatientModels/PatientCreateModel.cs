using PatientPortal.Domain.Enums;

namespace PatientPortal.Api.Models.PatientModels
{
    public sealed record PatientCreateModel(
        string Name,
        int DiseasesId,
        Epilepsy Epilepsy,
        IList<int>? SelectedNcds,
        IList<int>? SelectedAllergies);
}
