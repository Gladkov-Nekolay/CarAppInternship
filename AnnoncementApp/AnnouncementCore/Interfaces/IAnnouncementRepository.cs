﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnouncementAppCore.Entities;
using AnnouncementAppCore.Models;

namespace AnnouncementAppCore.Interfaces
{
    public interface IAnnouncementRepository
    {
        public Task AddAnnouncementAsync(Announcement announcement);
        public Task UpdateAnnouncementAsync(Announcement announcement);
        public Task<List<Announcement>> GetAllAsync(PaginationSettiongsModel paginationSettiongsModel);
        public Task<List<Announcement>> GetForAccountAnnouncementAsync(PaginationSettiongsModel paginationSettiongsModel, long ID);
        public Task DeleteAnnouncementAsync(long ID);
        public Task<Announcement> GetByIDAnnouncementAsync(long ID);

    }
}
