using InsideAirbnb.Models;
using InsideAirbnb.Models.ViewModels;
using InsideAirbnb.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Neighbourhoods> neighbourhoodRepo;
        private readonly IRepository<SummaryListings> listingRepo;

        public HomeController(IRepository<Neighbourhoods> repository, IRepository<SummaryListings> listingRepo)
        {
            this.neighbourhoodRepo = repository;
            this.listingRepo = listingRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // localhost/alle data
            Response.Headers.Add("X-Frame-Options", "DENY");
    //        HttpContext.Response.Cookies.Append(
    //"CookieKey",
    //"CookieValue",
    //new CookieOptions
    //{
    //    HttpOnly = true
    //});
            HomeViewModel homeViewModel = new HomeViewModel() { neighbourhoods = neighbourhoodRepo.GetAll(), listings = listingRepo.GetAll() };
            return View(homeViewModel);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View(((ClaimsIdentity)User.Identity).Claims);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize]
        public IActionResult Login()
        {
            
            return Redirect("/home");
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/home");
        }
        [Authorize]
        public IActionResult Secure()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    return errorText;
                }
                throw;
            }
        }
    }
}
