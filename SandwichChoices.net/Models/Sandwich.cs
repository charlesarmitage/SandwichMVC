using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SandwichChoices.net.Models
{
    public class SandwichDbContext : DbContext
    {
        public DbSet<Sandwich> Sandwiches { get; set; }
    }

    public class Sandwich
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public int FlavourRating { get; set; }
        public int Priority { get; set; }
        public string InventedBy { get; set; }
    }
}