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
    public class ModelOfCarEFRepository : GenericEFRepository<ModelOfCar>, IModelOfCarRepository
    {
        public ModelOfCarEFRepository(CarAppContext context) : base(context)
        {
        }
    }
}
