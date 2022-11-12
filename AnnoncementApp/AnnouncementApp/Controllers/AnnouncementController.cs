using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementAppCore.Entities;
using AnnouncementAppCore.Models;
using AnnouncementAppCore.ServiceCore.AnnouncementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _service;
        public AnnouncementController(IAnnouncementService service) 
        {
            _service = service;
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> AddAnnouncementAsync(AnnouncementCreationModel announcementModel) 
        {
            await _service.AddAnnouncementAsync(announcementModel);
            return new OkResult();

        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> UpdateAnnouncementAsync(Announcement announcement) 
        {
            await _service.UpdateAnnouncementAsync(announcement);
            return new OkResult();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery] PaginationSettiongsModel paginationSettiongsModel) 
        {
            return new OkObjectResult(await _service.GetAllAsync(paginationSettiongsModel));
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetForAccountAnnouncementAsync([FromQuery] PaginationSettiongsModel paginationSettiongsModel, long ID) 
        {
            return new OkObjectResult(await _service.GetForAccountAnnouncementAsync(paginationSettiongsModel, ID));
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAnnouncementAsync(long ID) 
        {
            await _service.DeleteAnnouncementAsync(ID);
            return new OkResult();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetByIDAnnouncementAsync(long ID) 
        {
            return new OkObjectResult(await _service.GetByIDAnnouncementAsync(ID));
        }
    }
}
