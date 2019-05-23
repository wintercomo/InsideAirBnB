using InsideAirbnb.Models;
using InsideAirbnb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    [Route("sum")]
    [ApiController]
    public class SummaryListingController : Controller
    {
        private readonly IRepository<SummaryListings> sumListingRepo;
        private readonly IRepository<Listings> listingsRepo;


        public SummaryListingController(IRepository<SummaryListings> repository, IRepository<Listings> listingsRepo)
        {
            this.sumListingRepo = repository;
            this.listingsRepo = listingsRepo;
        }
        public int? getReviews(int id)
        {
            int? value = listingsRepo.GetById(id).ReviewScoresRating;
            return value != null ? value : 0;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var features = from sumItem in sumListingRepo.GetAll()
                            join listItem in listingsRepo.GetAll() on sumItem.Id equals listItem.Id
                            select new { sumItem = sumItem, item= listItem };
            var geo = new
            {
                type = "FeatureCollection",
                features = features.Select(tt =>
                {
                    var item = tt.sumItem;
                    //var fullItem = listingsRepo.GetById(item.Id);
                    string availabilityStatus = "LOW"; // default
                    if (item.Availability365 > 60) availabilityStatus = "HIGH";
                    return new
                    {
                        type = "Feature",
                        geometry = new
                        {
                            type = "Point",
                            coordinates = new float[2] { float.Parse(item.Longitude.ToString().Insert(1, ".")), float.Parse(item.Latitude.ToString().Insert(2, ".")) }
                        },
                        properties = new
                        {
                            host_name = item.HostName,
                            id = item.Id,
                            calculated_host_listings_count = item.CalculatedHostListingsCount,
                            name = "'" + item.Name + "'",
                            neighbourhood = item.Neighbourhood,
                            room_type = item.RoomType,
                            price = item.Price,
                            minimum_nights = item.MinimumNights,
                            reviews_per_month = item.ReviewsPerMonth,
                            number_of_reviews = item.NumberOfReviews,
                            last_review = item.LastReview,
                            availabilityStatus,
                            availability_365 = item.Availability365,
                            review_rating = tt.item.ReviewScoresValue,
                        },
                    };
                })
            };
            return Ok(geo);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = listingsRepo.GetById(id);
            if (product == null)
            {
                return NotFound("Het product is niet gevonden");
            }
            return Ok(product.ReviewScoresRating);
        }
    }
}
