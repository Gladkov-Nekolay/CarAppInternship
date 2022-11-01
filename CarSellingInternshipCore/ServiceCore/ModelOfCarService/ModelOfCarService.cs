using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.ServiceCore.GenericTypeInterface;

namespace CarAppCore.ServiceCore.ModelOfCarService
{
    public class ModelOfCarService : GenericTypeService<ModelOfCar, IModelOfCarRepository>, IModelOfCarService
    {
        public ModelOfCarService(IModelOfCarRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
