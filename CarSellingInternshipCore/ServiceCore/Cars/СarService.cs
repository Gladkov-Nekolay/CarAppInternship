using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.Models;

namespace CarAppCore.ServiceCore.Cars
{
    public class СarService: ICarService
    {
        private readonly ICarRepository _CarsRepository;
        private readonly IMapper Mapper;

        public СarService(ICarRepository CarsRepository, IMapper mapper)
        {
            _CarsRepository = CarsRepository;
            Mapper = mapper;
        }

        public async Task AddCarAsync(CarCreationModel model)
        {
            Car MapedCar = Mapper.Map<CarCreationModel, Car>(model);
            await _CarsRepository.AddCarAsync(MapedCar);
        }

        public async Task DeleteCarAsync(long ID)
        {
            await _CarsRepository.DeleteCarAsync(ID);
        }

        public async Task<List<Car>> GetAllAsNotTrackingAsync(PaginationSettingsModel paginationSettings)
        {
            return await _CarsRepository.GetAllAsNotTrackingAsync(paginationSettings);
        }

        public async Task<List<Car>> GetAllAsync(PaginationSettingsModel paginationSettings)
        {
            return await _CarsRepository.GetAllAsync(paginationSettings);
        }

        public async Task<Car> GetAsNoTrackingAsync(long id)
        {
            Car result = await _CarsRepository.GetAsNoTrackingAsync(id);
            if (result == null) 
            {
                throw new KeyNotFoundException();
            }
            return result;
        }

        public async Task<Car> GetCarAsync(long ID)
        {
            Car result = await _CarsRepository.GetCarAsync(ID);
            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;
        }

        public async Task UpdateCarAsync(Car car)// новую модель передать ?
        {
            await _CarsRepository.UpdateCarAsync(car);
        }
    }
}
