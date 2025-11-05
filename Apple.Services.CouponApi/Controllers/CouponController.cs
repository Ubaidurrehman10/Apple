using Apple.Services.CouponApi.Data;
using Apple.Services.CouponApi.Model;
using Apple.Services.CouponApi.Model.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apple.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        public CouponController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x=>x.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                
                if (obj == null)
                    _response.IsSuccess = false;

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        [Route("AddCoupon")]
        public ResponseDto AddCoupon([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon data = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Add(data);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(data);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Route("UpdateCoupon")]
        public ResponseDto UpdateCoupon([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon data = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Update(data);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(data);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("DeleteCoupon/{id:int}")]
        public ResponseDto DeleteCoupon(int id)
        {
            try
            {
                var coupon = _db.Coupons.First(x => x.CouponId == id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}