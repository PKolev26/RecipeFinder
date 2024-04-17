using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Data.SeedDatabase
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            var data = new SeedData();

            builder.HasData(new Ingredient[] {  data.HoneyGlazedChickenChicken, data.MakaroniAndCheeseCheese, data.MakaroniAndCheeseMakaroni, data.CheesecakeCreamCheese, data.ChocolateMousseChocolate, data.BrowniesChocolate, data.GuacamoleAvocado, data.PretzelsFlour, data.CornbreadTacoBakeCornbread, data.GrilledTriTipBeefBeef, data.FishPuttanescaFish, data.VanillaCakeFlour });
        }
    }
}
