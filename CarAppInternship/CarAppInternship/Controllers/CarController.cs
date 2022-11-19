using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAppCore.Entities;
using CarAppCore.Models;
using CarAppCore.ServiceCore.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService service)
        {
            carService = service;
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> AddCarAsync(CarCreationModel CarModel)
        {
            await carService.AddCarAsync(CarModel);
            return new OkResult();
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> UpdateCarAsync(Car car)
        {
            await carService.UpdateCarAsync(car);
            return new OkResult();
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCarAsync(long ID)
        {
            await carService.DeleteCarAsync(ID);
            return new OkResult();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetCarAsync(long ID)
        {
            return new OkObjectResult(await carService.GetCarAsync(ID));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAsNoTrackingAsync(long id)
        {
            return new OkObjectResult(await carService.GetAsNoTrackingAsync(id));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery] PaginationSettingsModel paginationSettings)
        {
            return new OkObjectResult(await carService.GetAllAsync(paginationSettings));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsNotTrackingAsync([FromQuery] PaginationSettingsModel paginationSettings)
        {
            return new OkObjectResult(await carService.GetAllAsNotTrackingAsync(paginationSettings));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> IsExistAsync(long ID) 
        {
            return new OkObjectResult(await carService.IsExistAsync(ID));
        }
    }
}
