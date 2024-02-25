namespace PatientPortal.Domain.Entities
{
    public sealed class NCDDetail : BaseEntity
    {
        public int PatientId { get; set; }

        public Patient? Patient { get; set; }

        public int NCDId { get; set; }

        public NCD? NCD { get; set; }
    }
}
