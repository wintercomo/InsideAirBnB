using InsideAirbnb.Models;
using InsideAirbnb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Controllers
{
    [Route("sumReviews")]
    [ApiController]
    public class SummaryReviewsController : Controller
    {
        public IRepository<SummaryReviews> sumReviewsRepository;
        public SummaryReviewsController(IRepository<SummaryReviews> sumReviewsRepository)
        {
            this.sumReviewsRepository = sumReviewsRepository;
        }
        public async Task<IActionResult> TrendsData([FromQuery]string neighbourhood, [FromQuery]bool ApartmentsOnly, [FromQuery]int maxPrice, [FromQuery]int minReviews, [FromQuery]bool onlyHighActive, [FromQuery]bool onlyMultiListings, [FromQuery]bool onlyRecentBooked)
        {
            object geo = null;
            try
            {
                //return this.listings.OrderByDescending(i => i.CalculatedHostListingsCount).GroupBy(item => item.HostName).Select(listing => listing.First()).Take(20);

                geo = sumReviewsRepository.GetAll()
                .OrderBy(i => i.Date).GroupBy(item => item.Date).Distinct()
                .Take(100)
                .Select(item => { return new { x = item.First().Date, y = item.Count() }; });
                return Ok(geo);
                //RedisCacheService.GetInstance().StringSet(filterString, JsonConvert.SerializeObject(geo), TimeSpan.FromDays(1));
            }
            catch (Exception err)
            {

                return Ok(err);
            }
        }

    }

}
