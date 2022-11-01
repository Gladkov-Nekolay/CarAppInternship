using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.Models;

namespace CarAppCore.ServiceCore.GenericTypeInterface
{
    public abstract class GenericTypeService<TEntity,TRepository> : IGenericTypeService<TEntity> 
        where TEntity:GenericType
        where TRepository: IGenericTypeRepository<TEntity>
    {
        private protected readonly TRepository _Repository;
        private protected readonly IMapper _mapper;
        public GenericTypeService(TRepository repository, IMapper mapper) 
        {
            _Repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _Repository.AddAsync(entity);
        }

        public async Task DeleteAsync(long ID)
        {
            await _Repository.DeleteAsync(ID);
        }

        public async Task<List<TEntity>> GetAllAsNotTrackingAsync(PaginationSettingsModel paginationSettings)
        {
            return await _Repository.GetAllAsNotTrackingAsync(paginationSettings);
        }

        public async Task<List<TEntity>> GetAllAsync(PaginationSettingsModel paginationSettings)
        {
            return await _Repository.GetAllAsync(paginationSettings);
        }

        public async Task<TEntity> GetAsNoTrackingAsync(long id)
        {
            TEntity result = await _Repository.GetAsNoTrackingAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;
        }

        public async Task<TEntity> GetAsync(long id)
        {
            TEntity result = await _Repository.GetAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;
        }

        public async Task UpdateAsync(TEntity entity)
        {
             await _Repository.UpdateAsync(entity);
        }
    }
}
