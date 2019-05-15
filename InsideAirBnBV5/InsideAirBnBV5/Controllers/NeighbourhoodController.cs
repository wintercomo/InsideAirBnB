using InsideAirBnBV5.Models;
using InsideAirBnBV5.Models.Viewmodels;
using InsideAirBnBV5.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Controllers
{
    [Route("neighbourhoods")]
    public class NeighbourhoodController : Controller
    {
        private readonly IRepository<Neighbourhoods> repository;

        public NeighbourhoodController(IRepository<Neighbourhoods> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            NeighbourhoodsViewModel viewModel = new NeighbourhoodsViewModel() { neighbourhoods = repository.GetAll() };
            return View(viewModel);
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
