using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.Models;
using CarAppInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CarAppInfrastructure.Repository
{
    public abstract class GenericEFRepository<T> : IGenericTypeRepository<T> where T : GenericType
    {
        private protected readonly CarAppContext _context = null!;
        private protected readonly DbSet<T> _table = null!;
        public GenericEFRepository(CarAppContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long Id)
        {
            T DeletedEntity = await _table.FindAsync(Id);
            if (DeletedEntity == null)
            {
                throw new KeyNotFoundException();
            };
            _table.Remove(DeletedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsNotTrackingAsync(PaginationSettingsModel paginationSettings)
        {
            return await _table.AsNoTracking().OrderBy(p => p.ID)
                                 .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                                 .Take(paginationSettings.PageSize)
                                 .ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(PaginationSettingsModel paginationSettings)
        {
            return await _table.OrderBy(p => p.ID)
                               .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                               .Take(paginationSettings.PageSize)
                               .ToListAsync();
        }

        public async Task<T> GetAsNoTrackingAsync(long id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(p=>p.ID==id);
        }

        public async Task<T> GetAsync(long id)
        {
            return await _table.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task UpdateAsync(T entity)
        {
            T UpdatedEntity = await _table.FindAsync(entity.ID);
            if (UpdatedEntity == null)
            {
                throw new KeyNotFoundException();
            }
            UpdatedEntity = entity;
            await _context.SaveChangesAsync();
        }
    }
    
}
