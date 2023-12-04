using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Consts;
using Movies.ViewModels;
using System.Data;

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
    }
}
