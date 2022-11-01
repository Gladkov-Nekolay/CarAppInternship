using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.ServiceCore.GenericTypeInterface;

namespace CarAppCore.ServiceCore.BrandService
{
    public class BrandService : GenericTypeService<Brand, IBrantRepository>,IBrandService
    {
        public BrandService(IBrantRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
