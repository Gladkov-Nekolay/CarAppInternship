using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using CarAppCore.Entities;
using CarAppCore.Models;

namespace CarAppCore.Profiles
{
    public class BodyTypeProfile:Profile
    {
        public BodyTypeProfile() 
        {
            CreateMap<BodyType, BodyTypeCreationModel>().ForMember(u=>u.Name, option=>option.MapFrom(src=>src.Name))
                                                        .ReverseMap();
            //CreateMap<BodyType, BodyTypeCreationModel>.ForMember();
        }
    }
}
