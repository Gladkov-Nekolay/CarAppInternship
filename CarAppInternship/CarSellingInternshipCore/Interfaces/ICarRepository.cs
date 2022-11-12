using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAppCore.Entities;
using CarAppCore.Models;

namespace CarAppCore.Interface
{
    public interface ICarRepository
    {
        public Task AddCarAsync(Car car);
        public Task UpdateCarAsync(Car car);
        public Task DeleteCarAsync(long ID);
        public Task<Car> GetCarAsync(long ID);
        public Task<Car> GetAsNoTrackingAsync(long id);
        public Task<List<Car>> GetAllAsync(PaginationSettingsModel paginationSettings);
        public Task<List<Car>> GetAllAsNotTrackingAsync(PaginationSettingsModel paginationSettings);
    }
}
