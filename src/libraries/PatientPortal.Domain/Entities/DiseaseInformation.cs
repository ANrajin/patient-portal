namespace PatientPortal.Domain.Entities
{
    public sealed class DiseaseInformation : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public IList<Patient> Patients { get; set; } = [];
    }
}
