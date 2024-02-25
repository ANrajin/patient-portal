using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Contexts.Configurations
{
    public sealed class AllergiesDetailsConfigurations
        : IEntityTypeConfiguration<AllergiesDetail>
    {
        public void Configure(EntityTypeBuilder<AllergiesDetail> builder)
        {
            builder.ToTable(nameof(AllergiesDetail).Pluralize());

            builder.HasKey(x => x.Id);
        }
    }
}
