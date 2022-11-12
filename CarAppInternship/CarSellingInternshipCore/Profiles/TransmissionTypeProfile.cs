using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarAppCore.Entities;
using CarAppCore.Models;

namespace CarAppCore.Profiles
{
    public class TransmissionTypeProfile:Profile
    {
        public TransmissionTypeProfile() 
        {
            CreateMap<TransmissionType, TransmissionTypeCreationModel>().ForMember(u => u.Name, option => option.MapFrom(src => src.Name))
              .ReverseMap();
        }
    }
}
