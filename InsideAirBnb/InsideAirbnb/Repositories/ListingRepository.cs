using InsideAirbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Repositories
{
    public class ListingRepository : IRepository<Listings>
    {
        private readonly insideAirBnbV2Context context;

        public ListingRepository(insideAirBnbV2Context context)
        {
            this.context = context;
        }
        public IEnumerable<Listings> GetAll()
        {
            return context.Listings;
        }

        public Listings GetById(int id)
        {
            return context.Listings.FirstOrDefault(p => p.Id == id);
        }
    }
}
