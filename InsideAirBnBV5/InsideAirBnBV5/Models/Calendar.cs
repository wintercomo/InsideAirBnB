using System;
using System.Collections.Generic;

namespace InsideAirBnBV5.Models
{
    public partial class Calendar
    {
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public string Available { get; set; }
        public string Price { get; set; }
        public int Id { get; set; }
        public string TestString { get; set; }

        public virtual Listings Listing { get; set; }
    }
}
