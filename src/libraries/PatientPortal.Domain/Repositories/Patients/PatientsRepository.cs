﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Patient?> GetByIdAsync(int id, bool shouldTrack = false,
            CancellationToken cancellationToken = default)
        {
            if (shouldTrack)
                return await _dbSet.FindAsync([id], cancellationToken);

            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id), 
                cancellationToken);
        }

        public async Task<Patient?> GetPatientInfoAsync(int id)
        {
            return await _dbSet.AsQueryable()
                .Include(x => x.DiseaseInformation)
                .Include(x => x.NCDDetails)
                .ThenInclude(y => y.NCD)
                .Include(x => x.AllergiesDetails)
                .ThenInclude(y => y.Allergy)
                .Select(s => new Patient
                {
                    Id = s.Id,
                    Name = s.Name,
                    DiseaseInformation = new DiseaseInformation
                    {
                        Name = s.DiseaseInformation.Name
                    },
                    IsEpilepsy = s.IsEpilepsy,
                    NCDDetails = s.NCDDetails,
                    AllergiesDetails = s.AllergiesDetails,
                    CreatedAt = s.CreatedAt,
                })
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Patient?> GetPatientEditInfoAsync(int id, bool shouldTrack = false)
        {
            var query = _dbSet.AsQueryable();

            if (!shouldTrack)
            {
                query = query.AsNoTracking();
            }

            return await query
                .Include(x => x.NCDDetails)
                .Include(x => x.AllergiesDetails)
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task InsertAsync(Patient pateint)
        {
            await _dbSet.AddAsync(pateint);
        }

        public async Task DeleteAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                if (dbContext.Entry(patient).State == EntityState.Detached)
                {
                    _dbSet.Attach(patient);
                }
                _dbSet.Remove(patient);
            }, cancellationToken);
        }

        public async Task<(IReadOnlyCollection<Patient> data, int Total)> GetPaginatedAsync(int pageIndex, int pageSize)
        {
            var data = await _dbSet.AsNoTracking()
                .Include(x => x.DiseaseInformation)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new Patient
                {
                    Id = s.Id,
                    Name = s.Name,
                    DiseaseInformation = new DiseaseInformation
                    {
                        Name = s.DiseaseInformation.Name
                    },
                    IsEpilepsy = s.IsEpilepsy
                })
                .ToListAsync();

            var total = await _dbSet.CountAsync();

            return (data, total);
        }
    }
}
