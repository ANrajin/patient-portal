using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Contexts.Configurations
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
