using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
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

            builder.HasData(new Ingredient[] { data.MoussakaPotato, data.MoussakaМeat, data.PancakesSugar, data.PancakesSalt, data.PancakesMilk, data.PancakesFlour, data.PancakesEgg, data.PancakesButter, data.PancakesBakingPowder });
        }
    }
}
