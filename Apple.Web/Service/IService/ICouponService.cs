using Apple.Web.Models;

namespace Apple.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponByCodeAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto model);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto model);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}