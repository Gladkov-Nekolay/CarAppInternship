using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarAppCore.Entities
{
    public class Car
    {
        [Key]
        public long ID { set; get; }
        public long BrandID { set; get; }
        public Brand brand { set; get; }
        public long ModelID { set; get; }
        public ModelOfCar modelOfCar { set; get; }
        public DateTime ManufacturingDate { set; get; }
        //public double Price { set; get; } цену перенести в объявку
        public int Miliage { set; get; }
        public long BodyTypeID { set; get; }
        public BodyType bodyType { set; get; }
        public long EngineTypeID { set; get; }
        public EngineType engineType { set; get; }
        public double EngineVolume { set; get; }
        public long DriveTypeID { set; get; }
        public DriveType driveType { set; get; }
        public long TransmissionTypeID { set; get; }
        public TransmissionType transmissionType { set; get; } 
    }
}
