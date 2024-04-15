using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Tests
{
    public class IngredientServiceUnitTests
    {
        private RecipeFinderDbContext dbContext;

        private IngredientService ingredientService;

        private IRepository repository;

        private ApplicationUser User1;

        private Recipe Recipe1;

        [SetUp]
        public async Task SetUp()
        {
            User1 = new ApplicationUser
            {
                Id = "ba5ef817-fc4c-4c34-bf61-b1f495b010fd",
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                NormalizedUserName = "USER@GMAIL.COM",
                FirstName = "User",
                LastName = "User"
            };

            Recipe1 = new Recipe
            {
                Id = 1,
                Name = "Recipe1",
                Instructions = "Instructions",
                CategoryId = 1,
                CookId = User1.Id,
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            var options = new DbContextOptionsBuilder<RecipeFinderDbContext>()
                .UseInMemoryDatabase(databaseName: "RecipeFinderInMemoryDb" + Guid.NewGuid().ToString())
            .Options;

            dbContext = new RecipeFinderDbContext(options);

            await dbContext.AddAsync(User1);

            await dbContext.AddAsync(Recipe1);

            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            ingredientService = new IngredientService(repository);
        }

        [Test]
        public async Task AddAsync_ShouldAddIngredient()
        {
            var model = new IngredientsAddViewModel
            {
                Name = "Ingredient3",
                Quantity = 1,
                Unit = "kg",
                RecipeId = Recipe1.Id
            };

            await ingredientService.AddAsync(model, Recipe1.Id);

            var ingredient = await dbContext.Ingredients.FirstOrDefaultAsync(i => i.Name == "Ingredient3");

            Assert.IsNotNull(ingredient);
            Assert.AreEqual("Ingredient3", ingredient.Name);
            Assert.AreEqual(1, ingredient.Quantity);
            Assert.AreEqual("kg", ingredient.Unit);
            Assert.AreEqual(Recipe1.Id, ingredient.RecipeId);
        }
    }
}
