using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsideAirBnBV5.Models;
using InsideAirBnBV5.Data;
using InsideAirBnBV5.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace InsideAirBnBV5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IRepository<NeighbourhoodRepository> neighbourhoodRepository { get; set; }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                neighbourhoods = _context.Neighbourhoods,
                listings = _context.SummaryListings
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
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
