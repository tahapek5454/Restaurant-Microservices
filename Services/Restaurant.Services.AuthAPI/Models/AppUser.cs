using Microsoft.AspNetCore.Identity;

namespace Restaurant.Services.AuthAPI.Models
{
    public class AppUser: IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
