using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Neighbourhoods> neighbourhoods { get; set; }
        public IEnumerable<SummaryListings> listings { get; set; }

        public double apartmentsPercentage()
        {
            int amountEntireHomes =  this.listings.Where(listing => listing.RoomType == "Entire home/apt").Count();
            double percentage = (int)Math.Round((double)(100 * amountEntireHomes) / this.listings.Count());
            return percentage;
        }
        public double PricePerNight()
        {
            //double priceSum = AmountEntireHomeApartments().Select(item => item.Price).Sum(item => double.Parse(item.Substring(1)));
            return this.listings.Count();
        }

        public IEnumerable<SummaryListings> AmountEntireHomeApartments()
        {
            return this.listings.Where(listing => listing.RoomType == "Entire home/apt");
        }
        public IEnumerable<SummaryListings> AmountSharedListings()
        {
            return this.listings.Where(listing => listing.RoomType == "Shared room");
        }
        public IEnumerable<SummaryListings> AmountPrivateListings()
        {
            return this.listings.Where(listing => listing.RoomType == "Private room");
        }
        public IEnumerable<SummaryListings> TopHosts()
        {
            return this.listings.OrderByDescending(i => i.CalculatedHostListingsCount).GroupBy(item => item.HostName).Select(listing => listing.First()).Take(20);
        }
    }
}
