using Microsoft.AspNetCore.Identity;

namespace InfrastructureLayer.Data.IdentitySeeds
{
    public static class Users
    {
        public static async Task CreateUser(UserManager<IdentityUser> userManager)
        {
            if (await userManager.FindByNameAsync("User@gmail.com") is null)
            {
                var User = new IdentityUser
                {
                    UserName = "User@gmail.com",
                    Email = "user@gmail.com"
                };
                await userManager.CreateAsync(User, "Ba$$am3324");
                await userManager.AddToRoleAsync(User, "User");
            }
            else
            {
                throw new Exception("User is exists!!");
            }
        }
        public static async Task CreateAdmin(UserManager<IdentityUser> userManager)
        {
            if (await userManager.FindByNameAsync("Admin@gmail.com") is null)
            {
                var User = new IdentityUser
                {
                    UserName = "Admin@gmail.com",
                    Email = "admin@gmail.com"
                };
                await userManager.CreateAsync(User, "Ba$$am3324");
                await userManager.AddToRolesAsync(User, new List<string> { "Admin", "User" });
            }
            else
            {
                throw new Exception("User is exists!!");
            }
        }
    }
}