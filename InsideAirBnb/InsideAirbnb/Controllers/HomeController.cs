using InsideAirbnb.Models;
using InsideAirbnb.Models.ViewModels;
using InsideAirbnb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Neighbourhoods> repository;
        private readonly IRepository<Listings> listingRepo;

        public HomeController(IRepository<Neighbourhoods> repository, IRepository<Listings> listingRepo)
        {
            this.repository = repository;
            this.listingRepo = listingRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            NeighbourhoodsViewModel viewModel = new NeighbourhoodsViewModel() { neighbourhoods = repository.GetAll() };
            HomeViewModel homeViewModel = new HomeViewModel() { neighbourhoods = repository.GetAll(), listings = listingRepo.GetAll() };
            return View(homeViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = repository.GetById(id);
            if (product == null)
            {
                return NotFound("Het product is niet gevonden");
            }
            return Ok(product);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
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
