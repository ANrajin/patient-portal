using PatientPortal.Api.Entities;

namespace PatientPortal.Api.Contexts.Seeds
{
    public static class DiseaseInformationSeeds
    {
        public static DiseaseInformation[] DiseaseInformations
        {
            get => new DiseaseInformation[]
            {
                new()
                {
                    Id = 1,
                    Name = "Hypertension",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 2,
                    Name = "Influenza",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 3,
                    Name = "Arthritis",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 4,
                    Name = "Migraine",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 5,
                    Name = "Coronary Artery Disease",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                }
            };
        }
    }
}
