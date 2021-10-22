using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities.Identity;

namespace WebShop.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Jeff",
                    Email = "jeff@test.com",
                    UserName = "jeff@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

            
        }
    }
}
