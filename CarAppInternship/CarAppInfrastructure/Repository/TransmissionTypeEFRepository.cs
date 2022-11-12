using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppInfrastructure.Context;

namespace CarAppInfrastructure.Repository
{
    public class TransmissionTypeEFRepository : GenericEFRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeEFRepository(CarAppContext context) : base(context)
        {
        }
    }
}
