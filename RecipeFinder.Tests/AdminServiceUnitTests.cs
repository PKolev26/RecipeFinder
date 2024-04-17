using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Admin;
using RecipeFinder.Core.Models.AdminModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Tests
{
    [TestFixture]
    public class AdminServiceUnitTests
    {
        // Fields

        private RecipeFinderDbContext dbContext;

        private IRepository repository;
        private IAdminService adminService;

        private ApplicationUser User1;
        private ApplicationUser User2;

        private Recipe Recipe1;
        private Recipe Recipe2;
        private Recipe Recipe3;

        private Comment Comment1;
        private Comment Comment2;
        private Comment Comment3;
        private Comment Comment4;

        // SetUp and TearDown

        [SetUp]
        public async Task Setup()
        {
            User1 = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                NormalizedUserName = "USER@GMAIL.COM",
                FirstName = "User",
                LastName = "User"
            };

            User2 = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user2@gmail.com",
                Email = "user2@gmail.com",
                NormalizedEmail = "USER2@GMAIL.COM",
                NormalizedUserName = "USER2@GMAIL.COM",
                FirstName = "User",
                LastName = "User"
            };

            Recipe1 = new Recipe
            {
                Id = 1,
                Name = "Recipe1",
                Instructions = "Instructions",
                CookId = User1.Id,
                CategoryId = 1,
                DifficultyId = 1,
                PostedOn = DateTime.Now,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Recipe2 = new Recipe
            {
                Id = 2,
                Name = "Recipe2",
                Instructions = "Instructions",
                CookId = User2.Id,
                CategoryId = 1,
                DifficultyId = 1,
                PostedOn = DateTime.Now,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Recipe3 = new Recipe
            {
                Id = 3,
                Name = "Recipe3",
                Instructions = "Instructions",
                CookId = User1.Id,
                CategoryId = 1,
                DifficultyId = 1,
                PostedOn = DateTime.Now,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Comment1 = new Comment
            {
                Id = 1,
                RecipeId = Recipe1.Id,
                AuthorId = User1.Id,
                Title = "Title",
                Description = "Comment1",
                PostedOn = DateTime.Now
            };

            Comment2 = new Comment
            {
                Id = 2,
                RecipeId = Recipe2.Id,
                AuthorId = User2.Id,
                Title = "Title",
                Description = "Comment1",
                PostedOn = DateTime.Now
            };

            Comment3 = new Comment
            {
                Id = 3,
                RecipeId = Recipe1.Id,
                AuthorId = User1.Id,
                Title = "Title",
                Description = "Comment1",
                PostedOn = DateTime.Now
            };

            Comment4 = new Comment
            {
                Id = 4,
                RecipeId = Recipe2.Id,
                AuthorId = User2.Id,
                Title = "Title",
                Description = "Comment1",
                PostedOn = DateTime.Now
            };

            var options = new DbContextOptionsBuilder<RecipeFinderDbContext>()
               .UseInMemoryDatabase(databaseName: "RecipeFinderInMemoryDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new RecipeFinderDbContext(options);

            await dbContext.AddAsync(User1);
            await dbContext.AddAsync(User2);

            await dbContext.AddAsync(Recipe1);
            await dbContext.AddAsync(Recipe2);
            await dbContext.AddAsync(Recipe3);

            await dbContext.AddAsync(Comment1);
            await dbContext.AddAsync(Comment2);
            await dbContext.AddAsync(Comment3);
            await dbContext.AddAsync(Comment4);

            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            adminService = new AdminService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }

        // Tests

        [Test]
        public async Task AdminServiceShouldReturnPanelInformation()
        {
            // Arrange
            var panelInformation = new AdminPanelServiceModel
            {
                TotalUsers = dbContext.Users.Count(),
                TotalComments = dbContext.Comments.Count(),
                TotalRecipes = dbContext.Recipes.Count(),
                Latest = await dbContext.Recipes
                    .OrderByDescending(x => x.PostedOn)
                    .Take(10)
                    .Select(x => new AdminLatest10ServiceModel
                    {
                        CookFirstName = x.Cook.FirstName,
                        CookLastName = x.Cook.LastName,
                        Recipe = x.Name,
                        PostedOn = x.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                        CategoryName = x.Category.Name,
                        DifficultyName = x.Difficulty.Name,
                        CommentsCount = x.Comments.Count,
                        IsFinished = x.Ingredients.Any()
                    })
                    .ToListAsync()
            };

            // Act
            var result = await adminService.PanelInformationAsync();

            // Assert
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.TotalComments);

            Assert.IsNotNull(result.TotalRecipes);

            Assert.IsNotNull(result.TotalUsers);

            Assert.IsNotNull(result.Latest);

            Assert.That(result.TotalUsers, Is.EqualTo(panelInformation.TotalUsers));

            Assert.That(result.TotalComments, Is.EqualTo(panelInformation.TotalComments));

            Assert.That(result.TotalRecipes, Is.EqualTo(panelInformation.TotalRecipes));

            Assert.That(result.Latest.Count, Is.EqualTo(panelInformation.Latest.Count));
        }
    }
}
