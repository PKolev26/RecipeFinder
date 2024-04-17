using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Infrastructure.Data.SeedDatabase
{
    internal class DifficultyConfiguration : IEntityTypeConfiguration<Difficulty>
    {
        public void Configure(EntityTypeBuilder<Difficulty> builder)
        {
            var data = new SeedData();
            builder.HasData(new Difficulty[] { data.Beginner, data.Intermediate, data.Advanced, data.Expert, data.MasterChef });
        }
    }
}
