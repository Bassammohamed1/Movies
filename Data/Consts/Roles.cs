using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Movies.Data.Consts
{
    public static class Roles
    {
        public static async Task CreateAdmin(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            var role = await roleManager.FindByNameAsync("Admin");
            await roleManager.SeedPermissionsForAdmin(role, "Movies");
            await roleManager.SeedPermissionsForAdmin(role, "Actors");
            await roleManager.SeedPermissionsForAdmin(role, "Producers");
        }
        public static async Task CreateUser(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
        private static async Task SeedPermissionsForAdmin(this RoleManager<IdentityRole> roleManager, IdentityRole role, string model)
        {
            List<string> allPermissions = GetAllPermission(model);
            foreach (string permission in allPermissions)
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
        private static List<string> GetAllPermission(string model)
        {
            return new List<string>()
            {
                $"Permission.{model}.View",
                $"Permission.{model}.Add",
                $"Permission.{model}.Update",
                $"Permission.{model}.Delete"
            };
        }
        public static List<string> getAllPermission()
        {
            var list = new List<string>();
            list.AddRange(GetAllPermission("Movies"));
            list.AddRange(GetAllPermission("Actors"));
            list.AddRange(GetAllPermission("Producers"));
            return list;
        }
    }
}