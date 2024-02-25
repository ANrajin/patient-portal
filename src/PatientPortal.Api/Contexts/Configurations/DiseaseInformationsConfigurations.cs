using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientPortal.Api.Contexts.Seeds;
using PatientPortal.Api.Entities;

namespace PatientPortal.Api.Contexts.Configurations
{
    public sealed class DiseaseInformationsConfigurations 
        : IEntityTypeConfiguration<DiseaseInformation>
    {
        public void Configure(EntityTypeBuilder<DiseaseInformation> builder)
        {
            builder.ToTable(nameof(DiseaseInformation).Pluralize());

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasData(DiseaseInformationSeeds.DiseaseInformations);
        }
    }
}
