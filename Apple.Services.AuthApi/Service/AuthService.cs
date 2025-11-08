using Apple.Services.AuthApi.Data;
using Apple.Services.AuthApi.Model;
using Apple.Services.AuthApi.Model.Dto;
using Apple.Services.AuthApi.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Apple.Services.AuthApi.Service
{
    public class AuthService : IAuthService
    {
        public readonly AppDbContext _dbContext;
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegisterUser(RegistrationRequestDto dto)
        {
            ApplicationUser user = new()
            {
                Email = dto.Email,
                UserName = dto.Email,
                NormalizedEmail = dto.Email.ToUpper(),
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded)
                {
                    var response = await _dbContext.ApplicationUsers.FirstAsync(u => u.UserName == dto.Email);

                    UserDto userDto = new()
                    {
                        Id = response.Id,
                        Name = response.Name,
                        PhoneNumber = response.PhoneNumber,
                        Email = response.Email
                    };

                    return "";
                }
                else 
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return "Error Encounter";
        }
    }
}
