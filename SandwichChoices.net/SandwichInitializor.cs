using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SandwichChoices.net.Models;

namespace SandwichChoices.net
{
    public class SandwichInitializor : DropCreateDatabaseIfModelChanges<Models.SandwichDbContext>
    {
        protected override void Seed(Models.SandwichDbContext context)
        {
            context.Sandwiches.Add(new Sandwich { Name = "Cheese", Ingredients = "Cheese", FlavourRating = 9, Priority = 7, InventedBy = "Caesar Augustus"});
            context.Sandwiches.Add(new Sandwich { Name = "Cheese & Pickle", Ingredients = "Cheese, Pickle", FlavourRating = 10, Priority = 10, InventedBy = "Benjamin Franklin"});
            context.Sandwiches.Add(new Sandwich { Name = "Cheese & Tomato", Ingredients = "Cheese, Tomato", FlavourRating = 8, Priority = 6, InventedBy = "Simon Cowell"});
            base.Seed(context);
        }
    }
}