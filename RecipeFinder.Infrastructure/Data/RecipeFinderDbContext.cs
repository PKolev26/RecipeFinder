using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Data
{
    public class RecipeFinderDbContext : IdentityDbContext
    {
        public RecipeFinderDbContext(DbContextOptions<RecipeFinderDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
