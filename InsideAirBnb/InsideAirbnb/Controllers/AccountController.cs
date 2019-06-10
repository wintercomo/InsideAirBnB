using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> PersonalInfoAsync([FromQuery]bool success)
        {
            if (success)
            {
                await HttpContext.SignOutAsync();
                return Redirect("/Home/Login");
            }
            return View(((ClaimsIdentity)User.Identity).Claims);
        }
        [HttpPost]
        public IActionResult EditPersonalInfo([FromForm]string username)
        {
            var currentUsername = ((ClaimsIdentity)User.Identity).Claims.First(claim => claim.Type == "name").Value;
            //return Redirect($"http://localhost:5000/edit?name={currentUsername}&newName={username}");
            return Redirect($"http://identityserver20190606022426.azurewebsites.net:80/edit?name={currentUsername}&newName={username}");
        }
    }
}
