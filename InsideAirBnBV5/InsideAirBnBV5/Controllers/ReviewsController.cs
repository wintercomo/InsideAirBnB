using InsideAirBnBV5.Data;
using InsideAirBnBV5.Models;
using InsideAirBnBV5.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Controllers
{
    [Route("reviews")]
    [ApiController]
    public class ReviewsController : Controller
    {
        public IRepository<ReviewsRepository> repository;

        public ReviewsController(IRepository<ReviewsRepository> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(repository.GetAll());
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
