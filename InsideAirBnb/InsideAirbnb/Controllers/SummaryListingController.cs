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
        private readonly IRepository<SummaryListings> repository;
        private readonly IRepository<Listings> listingsRepo;


        public SummaryListingController(IRepository<SummaryListings> repository, IRepository<Listings> listingsRepo)
        {
            this.repository = repository;
            this.listingsRepo = listingsRepo;
        }
        public void GetReview_rating(int id)
        {
            var wantedItem = listingsRepo.GetById(2818).ReviewScoresRating;
            //return wantedItem.ReviewScoresRating;
        }
        [Route("/test")]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(listingsRepo.GetById(2818));
        }
        [HttpGet]
        public IActionResult Index()
        {
            var geo = new
            {
                type = "FeatureCollection",
                features = repository.GetAll().Select(item =>
                {
                    var fullItem = listingsRepo.GetById(item.Id);
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
                            availability_365 = item.Availability365,
                            review_rating = fullItem.ReviewScoresRating !=null ? fullItem.ReviewScoresRating : 0,
                        },
                    };
                })
            };
            return Ok(geo);
        }

    }
}
