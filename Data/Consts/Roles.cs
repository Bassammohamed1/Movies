using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            /* var role = await roleManager.FindByNameAsync("Admin");
             await roleManager.SeedPermissionsForAdmin(role, "Movies");
             await roleManager.SeedPermissionsForAdmin(role, "Actors");
             await roleManager.SeedPermissionsForAdmin(role, "Producers");*/
        }
        public static async Task CreateUser(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
            /*var role = await roleManager.FindByNameAsync("User");
            await roleManager.SeedPermissionsForUser(role, "Movies");*/
        }
        /* private static async Task SeedPermissionsForAdmin(this RoleManager<IdentityRole> roleManager, IdentityRole role, string model)
         {
             List<string> allPermissions = GetAllPermissionForAdmin(model);
             allPermissions.Add("Permission.Movies.Details");
             allPermissions.Add("Permission.Movies.Filter");
             allPermissions.Add("Permission.Roles.Add");
             allPermissions.Add("Permission.Roles.View");
             allPermissions.Add("Permission.Roles.ManagePermissions");
             allPermissions.Add("Permission.Users.View");
             allPermissions.Add("Permission.Users.ManageRoles");
             foreach (string permission in allPermissions)
             {
                 await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
             }
         }*/
        private static List<string> GetAllPermissionForAdmin(string model)
        {
            return new List<string>()
             {
                 $"Permission.{model}.View",
                 $"Permission.{model}.Add",
                 $"Permission.{model}.Update",
                 $"Permission.{model}.Delete"
             };
        }
        /* private static async Task SeedPermissionsForUser(this RoleManager<IdentityRole> roleManager, IdentityRole role, string model)
         {
             List<string> allPermissions = GetAllPermissionForUser(model);
             foreach (string permission in allPermissions)
             {
                 await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
             }
         }
         private static List<string> GetAllPermissionForUser(string model)
         {
             return new List<string>()
             {
                 $"Permission.{model}.Filter",
                 $"Permission.{model}.Details",
                 $"Permission.{model}.View"
             };
         }*/
        public static List<string> getAllPermission()
        {
            var list = new List<string>();
            list.AddRange(GetAllPermissionForAdmin("Movies"));
            list.AddRange(GetAllPermissionForAdmin("Actors"));
            list.AddRange(GetAllPermissionForAdmin("Producers"));
            return list;
        }
    }
}