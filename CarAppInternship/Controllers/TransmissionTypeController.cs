using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Models;
using CarAppCore.ServiceCore.TransmissionTypeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionTypeController : ControllerBase
    {
        private readonly ITransmissionTypeService Service;
        private readonly IMapper Mapper;
        public TransmissionTypeController(ITransmissionTypeService TransmissionService, IMapper mapper)
        {
            Service = TransmissionService;
            Mapper = mapper;
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> AddAsync(TransmissionTypeCreationModel entityModel)
        {
            var entity = Mapper.Map<TransmissionTypeCreationModel, TransmissionType>(entityModel);
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
        public async Task<ActionResult> UpdateAsync(TransmissionType entity)
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
        public async Task<ActionResult> GetAllAsNotTrackingAsync([FromQuery]PaginationSettingsModel paginationSettings)
        {
            return new OkObjectResult(await Service.GetAllAsNotTrackingAsync(paginationSettings));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync( [FromQuery] PaginationSettingsModel paginationSettings)
        {
            return new OkObjectResult(await Service.GetAllAsync(paginationSettings));
        }
    }
}
