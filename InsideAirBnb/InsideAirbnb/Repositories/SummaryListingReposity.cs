using InsideAirbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Repositories
{
    public class SummaryListingReposity : IRepository<SummaryListings>
    {
        private readonly insideAirBnbV2Context context;

        public SummaryListingReposity(insideAirBnbV2Context context)
        {
            this.context = context;
        }

        IEnumerable<SummaryListings> IRepository<SummaryListings>.GetAll()
        {
            return context.SummaryListings;
        }

        SummaryListings IRepository<SummaryListings>.GetById(int id)
        {
            return context.SummaryListings.FirstOrDefault(p => p.Id == id);
        }
    }
}
