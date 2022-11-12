using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppCore.Entities
{
    public class TransmissionType : GenericType
    {
        public List<Car> CarList { set; get; }
    }
}
