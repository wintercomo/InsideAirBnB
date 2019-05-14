using InsideAirBnBV5.Models;
using InsideAirBnBV5.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Controllers
{
    [Route("reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IRepository<Reviews> repository;

        public ReviewController(IRepository<Reviews> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(repository.GetAll());
        }
    }
}
