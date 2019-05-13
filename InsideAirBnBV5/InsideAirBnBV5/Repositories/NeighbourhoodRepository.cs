using InsideAirBnBV5.Data;
using InsideAirBnBV5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Repositories
{
    public class NeighbourhoodRepository : IRepository<Neighbourhoods>
    {
        private readonly ApplicationDbContext context;

        public NeighbourhoodRepository(ApplicationDbContext context)
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
