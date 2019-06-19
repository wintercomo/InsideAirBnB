using InsideAirbnb.Models;
using InsideAirbnb.Repositories;
using InsideAirbnb.Services;
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

        public SummaryListingController(IRepository<SummaryListings> repository)
        {
            this.sumListingRepo = repository;
        }
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            Console.WriteLine(monthsApart);
            return Math.Abs(monthsApart);
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync([FromQuery]string neighbourhood, [FromQuery]bool ApartmentsOnly, [FromQuery]int maxPrice, [FromQuery]int minReviews, [FromQuery]bool onlyHighActive, [FromQuery]bool onlyMultiListings, [FromQuery]bool onlyRecentBooked)
        {
            object geo = null;
            var filterString = neighbourhood + ApartmentsOnly + maxPrice + minReviews + onlyHighActive + onlyMultiListings + onlyRecentBooked;
            if (RedisCacheService.GetInstance().KeyExists(filterString))
            {
                geo = JsonConvert.DeserializeObject<object>(await RedisCacheService.GetInstance().StringGetAsync(filterString));
                return Ok(geo);
            }
            try
            {
                //var features = from sumItem in sumListingRepo.GetAll()
                //               join listItem in listingsRepo.GetAll() on sumItem.Id equals listItem.Id
                //               select new { sumItem = sumItem, item = listItem };
                var features = sumListingRepo.GetAll();
                geo = new
                {
                    type = "FeatureCollection",
                    features = features
                        .Where(l => l.Price < maxPrice || maxPrice == 0)
                        .Where(listing => listing.Neighbourhood == neighbourhood || neighbourhood == null)
                        .Where(l => l.RoomType == "Entire home/apt" || !ApartmentsOnly)
                        .Where(l => l.NumberOfReviews >= minReviews)
                        .Where(l => l.Availability365 > 60 || !onlyHighActive) // or is !onlyHighActive then = .Where(true)
                        .Where(l => l.CalculatedHostListingsCount > 1 || !onlyMultiListings)
                        .Where(l => l.LastReview != null && GetMonthDifference((DateTime)l.LastReview, DateTime.Now) >= -6 || !onlyRecentBooked)
                        .Select(item =>
                    { //Create the geoJson object
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
                                price = item.Price,
                                minimum_nights = item.MinimumNights,
                                reviews_per_month = item.ReviewsPerMonth,
                                number_of_reviews = item.NumberOfReviews,
                                last_review = item.LastReview,
                                availabilityStatus,
                                availability_365 = item.Availability365,
                            },
                        };
                    })
                };
                RedisCacheService.GetInstance().StringSet(filterString, JsonConvert.SerializeObject(geo), TimeSpan.FromDays(1));
                return Ok(geo);
            }
            catch (Exception err)
            {

                return Ok(err);
            }
        }
    }
}
