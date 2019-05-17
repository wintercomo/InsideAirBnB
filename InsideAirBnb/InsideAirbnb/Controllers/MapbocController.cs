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
    [Route("mapbox")]
    [ApiController]
    public class MapboxController : ControllerBase
    {
        private readonly IRepository<Neighbourhoods> repository;
        private readonly IRepository<Listings> listingRepo;

        public MapboxController(IRepository<Neighbourhoods> repository, IRepository<Listings> listingRepo)
        {
            this.repository = repository;
            this.listingRepo = listingRepo;
        }
        [HttpGet]
        public IActionResult GetAllData()
        {
            //var listings = listingRepo.GetAll();
            //var geo = "";
            //listings.Take(100).ToList().ForEach(item =>
            //{
            //    geo += @"{
            //            'type': 'Feature',
            //            'geometry': {
            //            'type': 'Point',
            //            'coordinates': [" + item.Longitude.ToString().Insert(1, ".") + ", " + item.Latitude.ToString().Insert(2, ".") + @"]
            //            },
            //            'properties': {
            //            'host_name': '" + item.HostName + @"',
            //            'id': '" + item.Id + @"',
            //            'calculated_host_listings_count' : '" + item.CalculatedHostListingsCount + @"',
            //            'name' : 'Name Bugged',
            //            'neighbourhood' : '" + item.Neighbourhood + @"',
            //            'room_type' : '" + item.RoomType + @"',
            //            'price' : '" + item.Price + @"',
            //            'minimum_nights' : '" + item.MinimumNights + @"',
            //            'reviews_per_month' : '" + item.ReviewsPerMonth + @"',
            //            'number_of_reviews' : '" + item.NumberOfReviews + @"',
            //            'last_review' : '" + item.LastReview + @"',
            //            'availability_365' : '" + item.Availability365 + @"',
            //        }},";
            //});
            //System.IO.File.Create(@"D:\path.json");
            //System.IO.File.WriteAllText(@"D:\path.json", geo);
            //string jsonFileContents = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"\sharedRooms_geojson.json");
            //object sharedRooms = JsonConvert.DeserializeObject(geo);
            return Ok(listingRepo.GetAll().Take(100).ToList());
        }
    }
}
