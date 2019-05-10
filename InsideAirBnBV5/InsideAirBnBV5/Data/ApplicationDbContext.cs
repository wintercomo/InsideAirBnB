using System;
using System.Collections.Generic;
using System.Text;
using InsideAirBnBV5.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InsideAirBnBV5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Listings> Listings { get; set; }
        public virtual DbSet<Neighbourhoods> Neighbourhoods { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SummaryListings> SummaryListings { get; set; }
        public virtual DbSet<SummaryReviews> SummaryReviews { get; set; }


    }
}
