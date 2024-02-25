using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Contexts.Seeds
{
    public static class AllergySeeds
    {
        public static Allergy[] Allergies
        {
            get => new Allergy[]
            {
                new()
                {
                    Id = 1,
                    Name = "Drugs - Penicillin",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 2,
                    Name = "Drug - Others",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 3,
                    Name = "Animals",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 4,
                    Name = "Food",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 5,
                    Name = "Oinments",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 6,
                    Name = "Plant",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 7,
                    Name="Sprays",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 8,
                    Name="Others",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 9,
                    Name="No Allergies",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                }
            };
        }
    }
}
