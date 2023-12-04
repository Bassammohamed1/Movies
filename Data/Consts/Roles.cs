using Microsoft.AspNetCore.Identity;

namespace Movies.Data.Consts
{
    public static class Roles
    {
        public static async Task CreateAdmin(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }
        public static async Task CreateUser(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}