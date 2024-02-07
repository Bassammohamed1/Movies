using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Consts;
using Movies.IdentityViewModels;
using Movies.ViewModels;
using System.Data;
using System.Security.Claims;

namespace Movies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
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
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
                return NotFound();
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var allClaims = Roles.getAllPermission();
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
