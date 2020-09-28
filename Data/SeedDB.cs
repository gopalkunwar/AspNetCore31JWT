using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore31JWT.Data
{
    public class SeedDB
    {
         public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            if(!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "test@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "testuser"
                };
                userManager.CreateAsync(user, "#1234$");
            }
        } 
    }
}
