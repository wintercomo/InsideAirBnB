using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityServer.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.Quickstart.UI;

namespace IdentityServerAspNetIdentity.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [Route("/edit")]
        [HttpGet]
        public async Task<IActionResult> EditAsync([FromQuery]string name, [FromQuery]string newName)
        {
            var claims = ((ClaimsIdentity)User.Identity).Claims;
            string CurrentUserName = User.Identity.Name;
            if (CurrentUserName == name)
            {
            Claim claim = User.Claims.First();
            ApplicationUser user = await _userManager.FindByNameAsync(name);
            user.UserName = newName;
            await _userManager.UpdateAsync(user);
                return Redirect("https://localhost:44307/Account/PersonalInfo?success=true");
            }
            return Redirect("https://localhost:44307/Account/PersonalInfo?success=fail");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
