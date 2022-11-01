using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.ServiceCore.GenericTypeInterface;

namespace CarAppCore.ServiceCore.TransmissionTypeService
{
    public class TransmissionTypeService : GenericTypeService<TransmissionType, ITransmissionTypeRepository>, ITransmissionTypeService
    {
        public TransmissionTypeService(ITransmissionTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
