using AutoMapper;
using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserCreationDTO, User>()
            .ForMember(dest => dest.FIRST_NAME, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LAST_NAME, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.USER_NAME, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.PASSWORD, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.DATE_CREATE, opt => opt.MapFrom(src => src.DateCreate));

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
