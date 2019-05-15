using InsideAirBnBV5.Data;
using InsideAirBnBV5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Repositories
{
    public class ListingRepository : IRepository<Listings>
    {
        private readonly ApplicationDbContext context;

        public ListingRepository(ApplicationDbContext context)
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
