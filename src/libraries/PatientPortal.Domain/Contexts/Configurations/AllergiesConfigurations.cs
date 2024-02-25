using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientPortal.Domain.Contexts.Seeds;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Contexts.Configurations
{
    public sealed class AllergiesConfigurations : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.ToTable(nameof(Allergy).Pluralize());

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasData(AllergySeeds.Allergies);
        }
    }
}
