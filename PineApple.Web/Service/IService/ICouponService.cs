using Pineapple.Web.Models;

namespace Pineapple.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponceDto?> GetAllCouponsAsync();
        Task<ResponceDto?> GetCouponByIdAsync(int id);
        Task<ResponceDto?> GetCouponByCodeAsync(string code);
        Task<ResponceDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponceDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponceDto?> DeleteCouponAsync(int id);

    }
}
