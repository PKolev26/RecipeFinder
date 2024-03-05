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
            builder.Entity<RecipeMaker>().HasKey(rc => new {  rc.RecipeId, rc.MakerId });
            builder.Entity<RecipeMaker>()
            .HasOne(sc => sc.Recipe)
            .WithMany(s => s.RecipesMakers)
            .HasForeignKey(sc => sc.RecipeId);
            builder.Entity<RecipeMaker>()
             .HasOne(sc => sc.Maker)
             .WithMany(s => s.RecipesMakers)
             .HasForeignKey(sc => sc.MakerId);

            builder.Entity<RecipeMaker>()
               .HasOne(e => e.Recipe)
               .WithMany(e => e.RecipesMakers)
               .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(builder);
        }

        // DbSets
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RecipeMaker> RecipesMakers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Difficulty> Difficulties { get; set; }
        public virtual DbSet<Maker> Makers { get; set; }
    }
}
