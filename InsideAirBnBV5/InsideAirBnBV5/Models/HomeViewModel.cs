using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirBnBV5.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Neighbourhoods> neighbourhoods{ get; set; }
        public IEnumerable<Listings> listings{ get; set; }
    }
}
