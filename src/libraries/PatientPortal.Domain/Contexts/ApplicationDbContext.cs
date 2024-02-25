using Microsoft.EntityFrameworkCore;

namespace PatientPortal.Domain.Contexts
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : DbContext(dbContextOptions), IApplicationDbContext
    {
        public async Task SaveAsync(CancellationToken cancellationToken)
            => await SaveChangesAsync(cancellationToken);

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
            => Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
