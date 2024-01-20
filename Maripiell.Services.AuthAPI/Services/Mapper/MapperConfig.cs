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
            });
        }
    }
}
