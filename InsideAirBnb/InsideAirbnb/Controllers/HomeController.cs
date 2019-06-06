using InsideAirbnb.Models;
using InsideAirbnb.Models.ViewModels;
using InsideAirbnb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Neighbourhoods> neighbourhoodRepo;
        private readonly IRepository<Listings> listingRepo;

        public HomeController(IRepository<Neighbourhoods> repository, IRepository<Listings> listingRepo)
        {
            this.neighbourhoodRepo = repository;
            this.listingRepo = listingRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel() { neighbourhoods = neighbourhoodRepo.GetAll(), listings = listingRepo.GetAll() };
            return View(homeViewModel);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View(((ClaimsIdentity)User.Identity).Claims);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Claims()
        {
            return Ok("YOU ARE ADMIN");
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
    }
}
