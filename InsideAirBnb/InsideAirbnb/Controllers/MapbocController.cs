using InsideAirbnb.Models;
using InsideAirbnb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    [Route("test")]
    [ApiController]
    public class MapboxController : ControllerBase
    {
        private readonly IRepository<Neighbourhoods> repository;
        private readonly IRepository<SummaryListings> listingRepo;

        public MapboxController(IRepository<Neighbourhoods> repository, IRepository<SummaryListings> listingRepo)
        {
            this.repository = repository;
            this.listingRepo = listingRepo;
        }
        [HttpGet]
        public IActionResult GetAllData()
        {
            try
            {
                var features = listingRepo.GetAll();
                var geo = new
                {
                    type = "FeatureCollection",
                    features = features.Select(tt =>
                    {
                        var item = tt;
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
                                host_id = item.HostId,
                                id = item.Id,
                                calculated_host_listings_count = item.CalculatedHostListingsCount,
                                name = "'" + item.Name + "'",
                                neighbourhood = item.Neighbourhood,
                                room_type = item.RoomType,
                                price = tt.Price,
                                minimum_nights = item.MinimumNights,
                                reviews_per_month = item.ReviewsPerMonth,
                                number_of_reviews = item.NumberOfReviews,
                                last_review = item.LastReview,
                                availabilityStatus,
                                availability_365 = item.Availability365,
                                review_rating = 0,
                            },
                        };
                    })
                };
                return Ok(geo);
            }
            catch (Exception err)
            {

                return Ok(err);
            }
        }
    }
}
