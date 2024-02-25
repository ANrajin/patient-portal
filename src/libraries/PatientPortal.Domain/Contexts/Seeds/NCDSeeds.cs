using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Contexts.Seeds
{
    public static class NCDSeeds
    {
        public static NCD[] NCDs
        {
            get => new NCD[]
            {
                new()
                {
                    Id = 1,
                    Name = "Asthma",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 2,
                    Name = "Cancer",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 3,
                    Name = "Disorders of ear",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 4,
                    Name = "Disorder of eye",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 5,
                    Name = "Mental illness",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                },
                new()
                {
                    Id = 6,
                    Name = "Oral health problems",
                    CreatedAt = new DateTime(2024, 02, 25, 11, 30, 00, DateTimeKind.Utc),
                }
            };
        }
    }
}
