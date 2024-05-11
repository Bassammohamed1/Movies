using CoreLayer.Models.ViewModels;
using InfrastructureLayer.Data.IdentitySeeds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Authorize("Permission.Roles.View")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [Authorize("Permission.Roles.Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(data.Name))
                {
                    ModelState.AddModelError("Name", "Role is Exist");
                    return View("Index", _roleManager.Roles);
                }
                else
                {
                    await _roleManager.CreateAsync(new IdentityRole(data.Name.Trim()));
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Index", _roleManager.Roles);
            }
        }
        [Authorize("Permission.Roles.ManagePermissions")]
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
                return NotFound();
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var allClaims = Roles.getAllPermission();
            allClaims.Add("Permission.Movies.Details");
            allClaims.Add("Permission.Movies.Filter");
            allClaims.Add("Permission.Roles.Add");
            allClaims.Add("Permission.Roles.View");
            allClaims.Add("Permission.Roles.ManagePermissions");
            allClaims.Add("Permission.Users.View");
            allClaims.Add("Permission.Users.ManageRoles");
            allClaims.Add("Permission.Orders.View");
            var allPermissions = allClaims.Select(p => new PermissionsViewModel { Name = p }).ToList();
            foreach (var permission in allPermissions)
            {
                if (roleClaims.Any(c => c.Type == "Permission" && c.Value == permission.Name))
                {
                    permission.IsSelected = true;
                }
            }
            var result = new RolesPermissionsViewModel()
            {
                RoleId = roleId,
                RoleName = role.Name,
                Permissions = allPermissions
            };
            return View(result);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ManagePermissions(RolesPermissionsViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role is null)
                return NotFound();
            var allClaims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in allClaims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var allPermissions = model.Permissions.Where(x => x.IsSelected).ToList();
            foreach (var permission in allPermissions)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", permission.Name));
            }
            return RedirectToAction("Index");
        }
    }
}
