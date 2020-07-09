using System;
using API.Dtos.AppUserDtos;
using API.Dtos.AuthDtos;
using API.Models;
using AutoMapper;

namespace API.Extentions
{
    public class AutoMapperConfig : Profile 
    {
        public AutoMapperConfig()
        {
            CreateMap<AppUser, AppUserForListDto>();

            CreateMap<AppUser, AppUserForDetailedDto>();

            CreateMap<AppUserForRegisterDto, AppUser>();
        }
    }
}
