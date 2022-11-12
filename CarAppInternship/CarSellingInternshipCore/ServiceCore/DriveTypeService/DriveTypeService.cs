using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Interface;
using CarAppCore.ServiceCore.GenericTypeInterface;

namespace CarAppCore.ServiceCore.DriveTypeService
{
    public class DriveTypeService : GenericTypeService<DriveType, IDriveTypeRepository>, IDriveTypeService
    {
        public DriveTypeService(IDriveTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
