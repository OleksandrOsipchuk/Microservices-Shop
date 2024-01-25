using Pineapple.Web.Models;
using Pineapple.Web.Service.IService;
using Pineapple.Web.Utility;

namespace Pineapple.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly string _couponApiUrl = SD.CouponApiBase + "/api/coupon";
        private readonly IBaseService _baseService;
        public CouponService(IHttpClientFactory httpClientFactory, IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponceDto?> CreateCouponAsync(CouponDto couponDto)
        {
            var request = new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDto,
                Url = _couponApiUrl
            };

            return await _baseService.SendAsync(request);
        }

        public async Task<ResponceDto?> DeleteCouponAsync(int id)
        {
            var request = new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = _couponApiUrl + id
            };

            return await _baseService.SendAsync(request);
        }

        public async Task<ResponceDto?> GetAllCouponsAsync()
        {
            var request = new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = _couponApiUrl
            };

            return await _baseService.SendAsync(request);
        }

        public async Task<ResponceDto?> GetCouponByCodeAsync(string code)
        {
            var request = new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = _couponApiUrl + code
            };

            return await _baseService.SendAsync(request);
        }

        public async Task<ResponceDto?> GetCouponByIdAsync(int id)
        {
            var request = new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = _couponApiUrl + id
            };

            return await _baseService.SendAsync(request);
        }

        public async Task<ResponceDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            var request = new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDto,
                Url = _couponApiUrl
            };

            return await _baseService.SendAsync(request);
        }
    }
}
