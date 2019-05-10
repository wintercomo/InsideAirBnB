using InsideAirBnBV5.Data;
using InsideAirBnBV5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Repositories
{
    public class NeighbourhoodsRepository : IRepository<Reviews>
    {
        private readonly ApplicationDbContext context;

        public NeighbourhoodsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Reviews> GetAll()
        {
            return context.Reviews.ToList();
        }

        public Reviews GetById(int id)
        {
            return context.Reviews.FirstOrDefault(p => p.Id == id);
        }
    }
}
