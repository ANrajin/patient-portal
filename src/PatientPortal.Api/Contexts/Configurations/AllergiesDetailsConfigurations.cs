using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientPortal.Api.Entities;

namespace PatientPortal.Api.Contexts.Configurations
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
