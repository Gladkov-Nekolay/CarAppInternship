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
    public class CarEFRepository:ICarRepository
    {
        private readonly CarAppContext _dbContext;
        public CarEFRepository(CarAppContext Context) 
        {
            _dbContext = Context;
        }

        public async Task AddCarAsync(Car car)
        {
            await _dbContext.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(long ID)
        {
            Car deletedCar = await _dbContext.Cars.FindAsync(ID);
            if (deletedCar != null)
            {
                throw new KeyNotFoundException();
            };
            _dbContext.Cars.Remove(deletedCar);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Car>> GetAllAsNotTrackingAsync(PaginationSettingsModel paginationSettings) 
        {
            return _dbContext.Cars.AsNoTracking().OrderBy(p => p.ID)
                                                 .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                                                 .Take(paginationSettings.PageSize).ToListAsync();
        }

        public Task<List<Car>> GetAllAsync(PaginationSettingsModel paginationSettings) 
        {
            return _dbContext.Cars.OrderBy(p => p.ID)
                                  .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                                  .Take(paginationSettings.PageSize).ToListAsync();
        }

        public async Task<Car> GetAsNoTrackingAsync(long id)
        {
            return await _dbContext.Cars.AsNoTracking().FirstOrDefaultAsync(p=>p.ID==id);
        }

        public async Task<Car> GetCarAsync(long ID)
        {
            return await _dbContext.Cars.FindAsync(ID);
        }

        public async Task UpdateCarAsync(Car car)
        {
            Car updatedCar = await _dbContext.Cars.FindAsync(car.ID);
            if (updatedCar == null) 
            {
                throw new KeyNotFoundException();
            }
            updatedCar = car;
            await _dbContext.SaveChangesAsync();

        }
    }
}
