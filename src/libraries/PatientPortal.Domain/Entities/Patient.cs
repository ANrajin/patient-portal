using PatientPortal.Domain.Enums;

namespace PatientPortal.Domain.Entities
{
    public sealed class Patient : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public Epilepsy IsEpilepsy { get; set; }

        public IList<NCDDetail>? NCDDetails { get; set; } = new List<NCDDetail>();

        public IList<AllergiesDetail>? AllergiesDetails { get; set; } = new List<AllergiesDetail>();
    }
}
