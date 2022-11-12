using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAppCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAppInfrastructure.Context
{
    public class CarAppContext:DbContext
    {
        public CarAppContext(DbContextOptions<CarAppContext> options) : base(options)
        {
        }
        public DbSet<BodyType> BodyTypes { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<Car> Cars { set; get; }
        public DbSet<DriveType> DriveTypes { set; get; }
        public DbSet<EngineType> EngineTypes { set; get; }
        public DbSet<ModelOfCar> ModelsOfCars { set; get; }
        public DbSet<TransmissionType> TransmissionTypes { set; get; }
    }
}
