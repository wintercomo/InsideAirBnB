using InsideAirbnb.Models;
using InsideAirbnb.Repositories;
using InsideAirbnb.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            if (RedisCacheService.GetInstance().KeyExists("Trends"))
            {
                geo = JsonConvert.DeserializeObject<object>(await RedisCacheService.GetInstance().StringGetAsync("Trends"));
                return Ok(geo);
            }
            try
            {
                geo = sumReviewsRepository.GetAll()
                .OrderBy(i => i.Date).GroupBy(item => item.Date).Distinct()
                .Select(item => { return new { x = item.First().Date, y = item.Count() }; });
                RedisCacheService.GetInstance().StringSet("Trends", JsonConvert.SerializeObject(geo), TimeSpan.FromDays(1));
                return Ok(geo);
            }
            catch (Exception err)
            {
                return Ok(err);
            }
        }

    }

}
