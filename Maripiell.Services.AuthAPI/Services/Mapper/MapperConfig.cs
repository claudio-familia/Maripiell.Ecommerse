using AutoMapper;
using Maripiell.Services.AuthAPI.Domain.Dto;
using Maripiell.Services.AuthAPI.Domain.Models;

namespace Maripiell.Services.AuthAPI.Services.Mapper
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDto>().ReverseMap();
                config.CreateMap<User, LoginDto>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                    .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"));
            });
        }
    }
}
