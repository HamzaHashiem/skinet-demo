using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Hamza",
                    Email = "hamza@test.com",
                    UserName = "hamza@test.com",
                    Address = new Address
                    {
                        FirstName = "Hamza",
                        LastName = "Hashem",
                        Street = "street 10",
                        City = "Abu Dhabi",
                        State = "Abu Dhabi",
                        ZipCode = "01010"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}