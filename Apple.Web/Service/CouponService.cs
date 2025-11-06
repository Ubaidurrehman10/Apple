using Apple.Web.Models;
using Apple.Web.Service.IService;
using Apple.Web.Utility;

namespace Apple.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetail.ApiType.Get,
                Url = StaticDetail.CouponApiBaseUrl + "/api/coupon/GetAll"
            });
        }

        public async Task<ResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetail.ApiType.Get,
                Url = StaticDetail.CouponApiBaseUrl + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetail.ApiType.Get,
                Url = StaticDetail.CouponApiBaseUrl + "/api/coupon/GetById/" + id
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetail.ApiType.Delete,
                Url = StaticDetail.CouponApiBaseUrl + "/api/coupon/DeleteCoupon/" + id
            });
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto model)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetail.ApiType.Post,
                Data = model,
                Url = StaticDetail.CouponApiBaseUrl + "/api/coupon/AddCoupon"
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto model)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetail.ApiType.Put,
                Data = model,
                Url = StaticDetail.CouponApiBaseUrl + "/api/coupon/UpdateCoupon"
            });
        }
    }
}