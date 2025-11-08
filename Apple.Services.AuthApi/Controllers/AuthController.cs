using Apple.Services.AuthApi.Model.Dto;
using Apple.Services.AuthApi.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Apple.Services.AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        public AuthController(IAuthService authService) 
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequestDto dto)
        {
            var errorMessage = await _authService.RegisterUser(dto);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login()
        {
            return Ok();
        }
    }
}