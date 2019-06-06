using InsideAirbnb.Models;
using InsideAirbnb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    [Route("listings")]
    [ApiController]
    public class ListingController : Controller
    {
        public IRepository<Listings> _repository;

        public ListingController(IRepository<Listings> repository)
        {
            this._repository = repository;
        }
        public IActionResult Index()
        {
            var geo = new
            {
                type = "FeatureCollection",
                features = _repository.GetAll().Select(item =>
                {
                    double parsedInt = 0;
                    try
                    {
                        parsedInt = double.Parse(item.Price.Substring(1));
                    }
                    catch
                    {
                    }
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
                            neighbourhood = item.NeighbourhoodCleansed,
                            room_type = item.RoomType,
                            price = parsedInt,
                            minimum_nights = item.MinimumNights,
                            reviews_per_month = item.ReviewsPerMonth,
                            number_of_reviews = item.NumberOfReviews,
                            last_review = item.LastReview,
                            availability_365 = item.Availability365,
                            review_rating = item.ReviewScoresRating,
                        },
                    };
                }).ToList()
            };
            //object sharedRooms = JsonConvert.DeserializeObject(geo);
            return Ok(geo);
        }
    }
}
