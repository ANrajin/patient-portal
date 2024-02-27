using Microsoft.EntityFrameworkCore;
using PatientPortal.Domain.BusinessObjects;
using PatientPortal.Domain.Contexts;
using PatientPortal.Domain.Entities;

namespace PatientPortal.Domain.Repositories.DiseaseInformations
{
    public class DiseaseInformationsRepository(IApplicationDbContext dbContext) 
        : IDiseaseInformationsRepository
    {
        private readonly DbSet<DiseaseInformation> _dbSet = dbContext.DbSet<DiseaseInformation>();

        public async Task<IReadOnlyCollection<DiseaseInformation>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IList<SelectListItemsBO>> GetSelectListItemsAsync()
        {
            return await _dbSet.AsNoTracking()
                .Select(s => new SelectListItemsBO
                {
                    Text = s.Name,
                    Value = s.Id
                }).ToListAsync();
        }
    }
}
