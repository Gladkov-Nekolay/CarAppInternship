using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementAppCore.Models
{
    public class AnnouncementCreationModel
    {
        [Required]
        public long OwnerID { set; get; }
        [Required]
        public bool IsSold { set; get; }
        [Required]
        public long CarID { set; get; }
        [Required]
        public string Description { set; get; } = "";
        [Required]
        public double Price { set; get; }
    }
}
