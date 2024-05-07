using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InfrastructureLayer.Data.IdentitySeeds
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
        private static List<string> GetAllPermissions(string model)
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
            list.AddRange(GetAllPermissions("Movies"));
            list.AddRange(GetAllPermissions("Actors"));
            list.AddRange(GetAllPermissions("Producers"));
            return list;
        }
    }
}
