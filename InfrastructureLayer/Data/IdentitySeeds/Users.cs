using Microsoft.AspNetCore.Identity;

namespace InfrastructureLayer.Data.IdentitySeeds
{
    public static class Users
    {
        public static async Task CreateUser(UserManager<IdentityUser> userManager)
        {
            var User = new IdentityUser
            {
                UserName = "User@gmail.com",
                Email = "user@gmail.com"
            };
            await userManager.CreateAsync(User, "Ba$$am3324");
            await userManager.AddToRoleAsync(User, "User");
        }
        public static async Task CreateAdmin(UserManager<IdentityUser> userManager)
        {
            var User = new IdentityUser
            {
                UserName = "Admin@gmail.com",
                Email = "admin@gmail.com"
            };
            await userManager.CreateAsync(User, "Ba$$am3324");
            await userManager.AddToRolesAsync(User, new List<string> { "Admin", "User" });
        }
    }
}