using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AnnouncementAppCore.Entities;
using AnnouncementAppCore.Interfaces;
using AnnouncementAppCore.Models;
using Microsoft.Extensions.Configuration;

namespace AnnouncementAppInfrastructure
{
    public class AnnouncementRepository:IAnnouncementRepository
    {
        private readonly string _connectionString;
        public AnnouncementRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        private Announcement MapToAnnouncement(SqlDataReader reader)
        {
            return new Announcement()
            {
                ID = (long)reader["ID"],
                OwnerID = (long)reader["OwnerID"],
                IsSold = (bool)reader["IsSold"],
                CarID = (long) reader["CarID"],
                Description = reader ["Description"].ToString(),
                Price = (double) reader ["Price"]
            };
        }
        public async Task AddAnnouncementAsync(Announcement announcement)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddAnnouncement", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@OwnerID", announcement.OwnerID));
                    cmd.Parameters.Add(new SqlParameter("@IsSold", announcement.IsSold));
                    cmd.Parameters.Add(new SqlParameter("@CarID", announcement.CarID));
                    cmd.Parameters.Add(new SqlParameter("@Description", announcement.Description));
                    cmd.Parameters.Add(new SqlParameter("@Price", announcement.Price));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task DeleteAnnouncementAsync(long ID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAnnouncement", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task<List<Announcement>> GetAllAsync(PaginationSettiongsModel paginationSettiongsModel)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllAnnouncement", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PageNum", paginationSettiongsModel.PageNumber));
                    cmd.Parameters.Add(new SqlParameter("@PageSize", paginationSettiongsModel.PageSize));
                    var response = new List<Announcement>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToAnnouncement(reader));
                        }
                    }

                    return response;
                }
            }
        }
        public async Task<Announcement> GetByIDAnnouncementAsync(long ID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetByIDAnnouncement", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    Announcement response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToAnnouncement(reader);
                        }
                    }
                    return response;
                }
            }
        }

        public async Task<List<Announcement>> GetForAccountAnnouncementAsync(PaginationSettiongsModel paginationSettiongsModel,long ID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetForAccountAnnouncement", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AccountID", ID ));
                    cmd.Parameters.Add(new SqlParameter("@PageNum", paginationSettiongsModel.PageNumber));
                    cmd.Parameters.Add(new SqlParameter("@PageSize", paginationSettiongsModel.PageSize));
                    var response = new List<Announcement>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToAnnouncement(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateAnnouncement", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", announcement.ID));
                    cmd.Parameters.Add(new SqlParameter("@OwnerID", announcement.OwnerID));
                    cmd.Parameters.Add(new SqlParameter("@IsSold", announcement.IsSold));
                    cmd.Parameters.Add(new SqlParameter("@CarID", announcement.CarID));
                    cmd.Parameters.Add(new SqlParameter("@Description", announcement.Description));
                    cmd.Parameters.Add(new SqlParameter("@Price", announcement.Price));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
    }
}
