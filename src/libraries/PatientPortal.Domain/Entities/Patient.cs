using PatientPortal.Domain.Enums;

namespace PatientPortal.Domain.Entities
{
    public sealed class Patient : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int DiseaseInformationId { get; set; }

        public DiseaseInformation? DiseaseInformation { get; set; }

        public Epilepsy IsEpilepsy { get; set; }

        public IList<NCDDetail>? NCDDetails { get; set; } = [];

        public IList<AllergiesDetail>? AllergiesDetails { get; set; } = [];
    }
}
