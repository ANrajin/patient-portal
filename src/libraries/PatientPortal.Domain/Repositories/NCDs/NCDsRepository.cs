using Microsoft.EntityFrameworkCore;
using PatientPortal.Domain.Contexts;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.NCDs
{
    public class NCDsRepository(IApplicationDbContext dbContext) : INCDsRepository
    {
        private readonly DbSet<NCD> _dbSet = dbContext.DbSet<NCD>();

        public async Task<IReadOnlyCollection<NCD>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
