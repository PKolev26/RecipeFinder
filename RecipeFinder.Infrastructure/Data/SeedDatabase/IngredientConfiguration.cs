using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Infrastructure.Data.SeedDatabase
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            var data = new SeedData();

            builder.HasData(new Ingredient[] { data.HoneyGlazedChickenChicken, data.MakaroniAndCheeseCheese, data.MakaroniAndCheeseMakaroni, data.CheesecakeCreamCheese, data.ChocolateMousseChocolate, data.BrowniesChocolate, data.GuacamoleAvocado, data.PretzelsFlour, data.CornbreadTacoBakeCornbread, data.GrilledTriTipBeefBeef, data.FishPuttanescaFish, data.VanillaCakeFlour });
        }
    }
}
