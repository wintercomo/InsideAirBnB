using InsideAirbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Repositories
{
    public class SummaryReviewRepository : IRepository<SummaryReviews>
    {
        private readonly insideAirBnbV2Context context;
        public SummaryReviewRepository(insideAirBnbV2Context context)
        {
            this.context = context;
        }
        public IEnumerable<SummaryReviews> GetAll()
        {
            return context.SummaryReviews;
        }

        public SummaryReviews GetById(int id)
        {
            return context.SummaryReviews.FirstOrDefault(item => item.ListingId == id);
        }
    }
}
