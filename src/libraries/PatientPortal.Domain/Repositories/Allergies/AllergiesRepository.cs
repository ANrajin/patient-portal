using Microsoft.EntityFrameworkCore;
using PatientPortal.Domain.Contexts;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.Allergies
{
    public class AllergiesRepository(IApplicationDbContext dbContext) : IAllergiesRepository
    {
        private readonly DbSet<Allergy> _dbSet = dbContext.DbSet<Allergy>();

        public async Task<IReadOnlyCollection<Allergy>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
