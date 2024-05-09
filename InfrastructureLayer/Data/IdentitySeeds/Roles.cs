using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InfrastructureLayer.Data.IdentitySeeds
{
    public static class Roles
    {
        public static async Task CreateAdmin(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("Admin") is null)
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            else
                throw new Exception("Role is exists!!");
        }
        public static async Task CreateUser(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("User") is null)
                await roleManager.CreateAsync(new IdentityRole("User"));
            else
                throw new Exception("Role is exists!!");
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
