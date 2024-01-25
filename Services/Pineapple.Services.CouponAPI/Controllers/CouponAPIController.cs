using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pineapple.Services.CouponAPI.Data;
using Pineapple.Services.CouponAPI.Models;
using Pineapple.Services.CouponAPI.Models.Dto;

namespace Pineapple.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {

        private readonly AppDbContext _db;
        private readonly ResponceDto _responce;
        private readonly IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responce = new ResponceDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponceDto Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons.ToList();
                _responce.Data = _mapper.Map<IEnumerable<CouponDto>>(coupons);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponceDto GetById(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(x => x.CouponId == id);
                _responce.Data = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpGet]
        [Route("{code}")]
        public ResponceDto GetByCode(string code)
        {
            try
            {
                var coupon = _db.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                _responce.Data = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpPost]
        public ResponceDto Post([FromBody]CouponDto model)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(model);
                _db.Coupons.Add(coupon);
                _db.SaveChanges();

                _responce.Data = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpPut]
        public ResponceDto Put([FromBody] CouponDto model)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(model);
                var dbCoupon = _db.Coupons.First(x=>x.CouponId == coupon.CouponId);
                dbCoupon = coupon;
                _db.SaveChanges();

                _responce.Data = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponceDto Delete(int id)
        {
            try
            {
                var coupon = _db.Coupons.First(x => x.CouponId == id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }
    }
}
