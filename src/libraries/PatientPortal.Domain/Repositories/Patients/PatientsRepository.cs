using Microsoft.EntityFrameworkCore;
using PatientPortal.Domain.Contexts;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.Patients
{
    public sealed class PatientsRepository(IApplicationDbContext dbContext) : IPatientsRepository
    {
        private readonly DbSet<Patient> _dbSet = dbContext.DbSet<Patient>();

        public async Task<IReadOnlyCollection<Patient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Patient?> GetByIdAsync(Guid id, bool shouldTrack = false,
            CancellationToken cancellationToken = default)
        {
            if (shouldTrack)
                return await _dbSet.FindAsync([id], cancellationToken);

            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id), 
                cancellationToken);
        }

        public async Task InsertAsync(Patient pateint, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(pateint, cancellationToken);
        }

        public async Task DeleteAsync(Patient book, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                if (dbContext.Entry(book).State == EntityState.Detached)
                {
                    _dbSet.Attach(book);
                }
                _dbSet.Remove(book);
            }, cancellationToken);
        }
    }
}
