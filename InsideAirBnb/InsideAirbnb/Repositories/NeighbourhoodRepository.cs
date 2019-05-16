using InsideAirbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Repositories
{
    public class NeighbourhoodRepository : IRepository<Neighbourhoods>
    {
        private readonly insideAirBnbV2Context context;

        public NeighbourhoodRepository(insideAirBnbV2Context context)
        {
            this.context = context;
        }
        public IEnumerable<Neighbourhoods> GetAll()
        {
            return context.Neighbourhoods.ToList();
        }

        public Neighbourhoods GetById(int id)
        {
            return context.Neighbourhoods.FirstOrDefault(p => p.Id == id);
        }
    }
}
