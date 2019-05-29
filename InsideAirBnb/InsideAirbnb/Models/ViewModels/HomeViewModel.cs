using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Neighbourhoods> neighbourhoods { get; set; }
        public IEnumerable<Listings> listings { get; set; }

        public double apartmentsPercentage()
        {
            int amountEntireHomes =  this.listings.Where(listing => listing.RoomType == "Entire home/apt").Count();
            double percentage = (int)Math.Round((double)(100 * amountEntireHomes) / this.listings.Count());
            return percentage;
        }

    }
}
