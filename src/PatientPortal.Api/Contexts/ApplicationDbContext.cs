using Microsoft.EntityFrameworkCore;

namespace PatientPortal.Api.Contexts
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) 
        : DbContext(dbContextOptions), IApplicationDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
