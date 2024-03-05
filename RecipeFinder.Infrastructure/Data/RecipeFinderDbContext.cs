using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Infrastructure.Data.Models;
using RecipeFinder.Infrastructure.Data.SeedDatabase;

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
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DifficultyConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new RecipeConfiguration());

            builder.Entity<RecipeUser>().HasKey(rc => new { rc.RecipeId, rc.UserId });

            builder.Entity<RecipeUser>()
               .HasOne(e => e.Recipe)
               .WithMany(e => e.RecipesUsers)
               .OnDelete(DeleteBehavior.Restrict);

       

            base.OnModelCreating(builder);
        }

        // DbSets
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RecipeUser> RecipesUsers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Difficulty> Difficulties { get; set; }
       
    }
}
