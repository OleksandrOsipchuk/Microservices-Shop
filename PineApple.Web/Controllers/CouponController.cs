using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pineapple.Web.Models;
using Pineapple.Web.Service.IService;

namespace Pineapple.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<CouponDto> coupons = new();

            var responce = await _couponService.GetAllCouponsAsync();

            if (responce != null && responce.IsSuccess)
            {
                coupons = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responce.Data));
            }
            else
            {
                TempData["error"] = responce?.Message;
            }

            return View(coupons);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                var responce = await _couponService.CreateCouponAsync(model);
                if (responce != null && responce.IsSuccess)
                {
                    TempData["success"] = "Successfuly created";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = responce?.Message;
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var responce = await _couponService.GetCouponByIdAsync(id);

            if (responce != null && responce.IsSuccess)
            {
                CouponDto coupon = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responce.Data));
                return View(coupon);
            }
            else
            {
                TempData["error"] = responce?.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CouponDto model)
        {
            var responce = await _couponService.DeleteCouponAsync(model.CouponId);
            if (responce != null && responce.IsSuccess)
            {
                TempData["success"] = "Successfuly deleted";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = responce?.Message;
            }

            return View(model);
        }
    }
}
