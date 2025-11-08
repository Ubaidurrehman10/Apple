using Microsoft.AspNetCore.Identity;

namespace Apple.Services.AuthApi.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
