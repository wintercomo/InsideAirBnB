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
        public double PricePerNight()
        {
            double priceSum = AmountEntireHomeApartments().Select(item => item.Price).Sum(item => double.Parse(item.Substring(1)));
            return priceSum / this.listings.Count();
        }

        public IEnumerable<Listings> AmountEntireHomeApartments()
        {
            return this.listings.Where(listing => listing.RoomType == "Entire home/apt");
        }
        public IEnumerable<Listings> AmountSharedListings()
        {
            return this.listings.Where(listing => listing.RoomType == "Shared room");
        }
        public IEnumerable<Listings> AmountPrivateListings()
        {
            return this.listings.Where(listing => listing.RoomType == "Private room");
        }
    }
}
