using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Home;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Tests
{
    [TestFixture]
    public class HomeServiceUnitTests
    {
        private RecipeFinderDbContext dbContext;

        private IRepository repository;
        private IHomeService homeService;

        private ApplicationUser UserWithRecipeWithNoIngredients;
        private ApplicationUser UserWithRecipeWithIngredients;

        private Recipe RecipeWithNoIngredients;
        private Recipe RecipeWithIngredients;

        private Ingredient Ingredient;

        private Category Category;

        private Difficulty Difficulty;

        [SetUp]
        public async Task Setup()
        {
            Category = new Category
            {
                Id = 1,
                Name = "Category"
            };

            Difficulty = new Difficulty
            {
                Id = 1,
                Name = "Difficulty",
                SkillLevel = 1,
                Description = "Description",
                IngredientComplexity = "IngredientComplexity"
            };

            UserWithRecipeWithNoIngredients = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                NormalizedUserName = "USER@GMAIL.COM",
                FirstName = "User",
                LastName = "User"
            };

            UserWithRecipeWithIngredients = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user2@gmail.com",
                Email = "user2@gmail.com",
                NormalizedEmail = "USER2@GMAIL.COM",
                NormalizedUserName = "USER2@GMAIL.COM",
                FirstName = "User",
                LastName = "User"
            };

            RecipeWithNoIngredients = new Recipe
            {
                Id = 1,
                CookId = UserWithRecipeWithNoIngredients.Id,
                Name = "Recipe with no ingredients",
                Instructions = "Recipe with no ingredients",
                PreparationTime = 10,
                CategoryId = Category.Id,
                DifficultyId = Difficulty.Id,
                PostedOn = DateTime.Now,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            RecipeWithIngredients = new Recipe
            {
                Id = 2,
                CookId = UserWithRecipeWithIngredients.Id,
                Name = "Recipe with ingredients",
                Instructions = "Recipe with ingredients",
                PreparationTime = 10,
                CategoryId = Category.Id,
                DifficultyId = Difficulty.Id,
                PostedOn = DateTime.Now,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Ingredient = new Ingredient
            {
                Id = 1,
                Name = "Ingredient",
                Quantity = 1,
                Unit = "kg",
                RecipeId = RecipeWithIngredients.Id
            };

            var options = new DbContextOptionsBuilder<RecipeFinderDbContext>()
               .UseInMemoryDatabase(databaseName: "RecipeFinderInMemoryDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new RecipeFinderDbContext(options);

            await dbContext.AddAsync(UserWithRecipeWithIngredients);

            await dbContext.AddAsync(UserWithRecipeWithNoIngredients);

            await dbContext.AddAsync(RecipeWithNoIngredients);

            await dbContext.AddAsync(RecipeWithIngredients);

            await dbContext.AddAsync(Ingredient);

            await dbContext.AddAsync(Category);

            await dbContext.AddAsync(Difficulty);

            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            homeService = new HomeService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }

        [Test]
        public async Task UserHasUnfinishedRecipeAsync_UserWithRecipeWithNoIngredient_ShouldReturnTrue()
        {
            // Arrange
            var user = UserWithRecipeWithNoIngredients;

            // Act
            var result = await homeService.UserHasUnfinishedRecipeAsync(user);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserHasUnfinishedRecipeAsync_UserWithRecipeWithIngredient_ShouldReturnFalse()
        {
            // Arrange
            var user = UserWithRecipeWithIngredients;

            // Act
            var result = await homeService.UserHasUnfinishedRecipeAsync(user);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
