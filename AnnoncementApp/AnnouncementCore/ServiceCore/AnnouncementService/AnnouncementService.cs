using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnouncementAppCore.Entities;
using AnnouncementAppCore.Interfaces;
using AnnouncementAppCore.Models;
using AutoMapper;

namespace AnnouncementAppCore.ServiceCore.AnnouncementService
{
    public class AnnouncementService:IAnnouncementService
    {
        private readonly IAnnouncementRepository _Repository;
        private readonly IMapper Mapper;
        public AnnouncementService(IAnnouncementRepository announcementRepository,IMapper mapper) 
        {
            _Repository = announcementRepository;
            Mapper = mapper;
        }

        public async Task AddAnnouncementAsync(AnnouncementCreationModel announcement)
        {
            Announcement MappedAnnouncement=Mapper.Map<AnnouncementCreationModel,Announcement>(announcement);
            await _Repository.AddAnnouncementAsync(MappedAnnouncement);
        }

        public async Task DeleteAnnouncementAsync(long ID)
        {
            await _Repository.DeleteAnnouncementAsync(ID);
        }

        public async Task<List<Announcement>> GetAllAsync(PaginationSettiongsModel paginationSettiongsModel)
        {
            return await _Repository.GetAllAsync(paginationSettiongsModel);
        }

        public async Task<Announcement> GetByIDAnnouncementAsync(long ID)
        {
            return await _Repository.GetByIDAnnouncementAsync(ID);
        }

        public async Task<List<Announcement>> GetForAccountAnnouncementAsync(PaginationSettiongsModel paginationSettiongsModel,long ID)
        {
            return await _Repository.GetForAccountAnnouncementAsync(paginationSettiongsModel, ID);
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            await _Repository.UpdateAnnouncementAsync(announcement);
        }
    }
}
