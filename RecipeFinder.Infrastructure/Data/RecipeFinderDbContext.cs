using Microsoft.AspNetCore.Identity;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecipeMaker>().HasKey(rc => new { rc.MakerId, rc.RecipeId });

            builder.Entity<RecipeMaker>()
               .HasOne(r => r.Recipe)
               .WithMany(r => r.RecipesMakers)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        // DbSets
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RecipeMaker> RecipesMakers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
