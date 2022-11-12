using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.ServiceCore.GenericTypeInterface;

namespace CarAppCore.ServiceCore.EngineTypeService
{
    public class EngineTypeService : GenericTypeService<EngineType, IEngineTypeRepository>, IEngineTypeService
    {
        public EngineTypeService(IEngineTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
