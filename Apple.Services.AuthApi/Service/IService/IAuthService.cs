using Apple.Services.AuthApi.Model.Dto;

namespace Apple.Services.AuthApi.Service.IService
{
    public interface IAuthService
    {
        Task<string> RegisterUser(RegistrationRequestDto dto);
        Task<LoginResponseDto> Login(LoginRequestDto dto);
    }
}