using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientPortal.Api.Contexts.Seeds;
using PatientPortal.Api.Entities;

namespace PatientPortal.Api.Contexts.Configurations
{
    public sealed class NCDsConfigurations : IEntityTypeConfiguration<NCD>
    {
        public void Configure(EntityTypeBuilder<NCD> builder)
        {
            builder.ToTable(nameof(NCD).Pluralize());

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasData(NCDSeeds.NCDs);
        }
    }
}
