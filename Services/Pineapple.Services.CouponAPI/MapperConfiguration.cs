using AutoMapper;
using Pineapple.Services.CouponAPI.Models;
using Pineapple.Services.CouponAPI.Models.Dto;

namespace Pineapple.Services.CouponAPI
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration() 
        {
            CreateMap<Coupon, CouponDto>()
                .ReverseMap();
        }
    }
}
