using Microsoft.AspNetCore.Identity;

namespace AspNetCore31JWT.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}