namespace PatientPortal.Api.Entities
{
    public sealed class AllergiesDetail : BaseEntity
    {
        public int PatientId { get; set; }

        public Patient? Patient { get; set; }

        public int AllergyId { get; set; }

        public Allergy? Allergy { get; set; }
    }
}
