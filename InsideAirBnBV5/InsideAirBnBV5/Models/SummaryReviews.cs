using System;
using System.Collections.Generic;

namespace InsideAirBnBV5.Models
{
    public partial class SummaryReviews
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
    }
}
