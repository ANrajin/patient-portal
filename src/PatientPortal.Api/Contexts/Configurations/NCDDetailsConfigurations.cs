using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientPortal.Api.Entities;

namespace PatientPortal.Api.Contexts.Configurations
{
    public sealed class NCDDetailsConfigurations : IEntityTypeConfiguration<NCDDetail>
    {
        public void Configure(EntityTypeBuilder<NCDDetail> builder)
        {
            builder.ToTable(nameof(NCDDetail).Pluralize());

            builder.HasKey(x => x.Id);
        }
    }
}
