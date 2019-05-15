using InsideAirBnBV5.Models;
using InsideAirBnBV5.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Controllers
{
    [Route("listings")]
    [ApiController]
    public class ListingController : Controller
    {
        private readonly IRepository<Listings> repository;

        public ListingController(IRepository<Listings> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(repository.GetAll());
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
    }
}
