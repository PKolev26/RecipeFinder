using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Infrastructure.Data.SeedDatabase
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[] { data.FirstCategory, data.SecondCategory, data.ThirdCategory });
        }
    }
}
