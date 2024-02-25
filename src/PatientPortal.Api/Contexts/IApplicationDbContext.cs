using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace PatientPortal.Api.Contexts
{
    public interface IApplicationDbContext
    {
        public Task SaveAsync(CancellationToken cancellationToken = default);

        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;

        EntityEntry Entry(object entity);
    }
}
