using AutoMapper;
using BlogApp.Business.DTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
    public class UserMapProfiles:Profile
    {
        public UserMapProfiles()
        {
            CreateMap<AppUserDto, Account>();
            CreateMap<AppUserDto, Account>().ReverseMap();
        }
    }
}
