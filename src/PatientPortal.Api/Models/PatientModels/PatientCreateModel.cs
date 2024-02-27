using FluentValidation;
using PatientPortal.Domain.Enums;

namespace PatientPortal.Api.Models.PatientModels
{
    public sealed record PatientCreateModel(
        string Name,
        int DiseasesId,
        Epilepsy Epilepsy,
        IList<int>? SelectedNcds,
        IList<int>? SelectedAllergies);

    public sealed class PatientCreateValidator : AbstractValidator<PatientCreateModel>
    {
        public PatientCreateValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(cascadeMode: CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Patient {PropertyName} is required!")
                .MaximumLength(255)
                .WithMessage("Patient {PropertyName} must not exceed 255 characters!");

            RuleFor(x => x.DiseasesId)
                .Cascade(cascadeMode: CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Patient {PropertyName} is required!");

            RuleFor(x => x.Epilepsy)
                .Cascade(cascadeMode: CascadeMode.Stop)
                .NotNull()
                .WithMessage("Patient {PropertyName} is required!");
        }
    }
}
