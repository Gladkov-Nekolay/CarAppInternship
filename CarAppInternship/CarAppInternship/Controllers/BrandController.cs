using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Models;
using CarAppCore.ServiceCore.BrandService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService Service;
        private readonly IMapper Mapper;
        public BrandController(IBrandService BrandService, IMapper mapper)
        {
            Service = BrandService;
            Mapper = mapper;
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> AddAsync(BrandCreationModel entityModel)
        {
            var entity = Mapper.Map<BrandCreationModel, Brand>(entityModel);
            await Service.AddAsync(entity);
            return new OkResult();
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(long ID)
        {
            await Service.DeleteAsync(ID);
            return new OkResult();
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdateAsync(Brand entity)
        {
            await Service.UpdateAsync(entity);
            return new OkResult();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAsync(long id)
        {
            return new OkObjectResult(await Service.GetAsync(id));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAsNoTrackingAsync(long id)
        {
            return new OkObjectResult(await Service.GetAsNoTrackingAsync(id));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsNotTrackingAsync([FromQuery] PaginationSettingsModel paginationSettings)
        {
            return new OkObjectResult(await Service.GetAllAsNotTrackingAsync(paginationSettings));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery] PaginationSettingsModel paginationSettings)
        {
            return new OkObjectResult(await Service.GetAllAsync(paginationSettings));
        }
    }
}
