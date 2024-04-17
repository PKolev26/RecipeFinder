using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Infrastructure.Data.SeedDatabase
{
    internal class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            var data = new SeedData();
            builder.HasData(new Recipe[] { data.Moussaka, data.Pancakes, data.HoneyGlazedChicken, data.MacaroniAndCheese, data.Cheesecake, data.ChocolateMousse, data.Brownies, data.Guacamole, data.Pretzels, data.CornbreadTacoBake, data.GrilledTriTipBeef, data.FishPuttanesca, data.VanillaCake });
        }
    }
}
