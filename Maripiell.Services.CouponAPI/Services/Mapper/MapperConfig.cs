using AutoMapper;
using Maripiell.Services.CouponAPI.Domain.Dto;
using Maripiell.Services.CouponAPI.Domain.Models;

namespace Maripiell.Services.CouponAPI.Services.Mapper
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            });
        }
    }
}
