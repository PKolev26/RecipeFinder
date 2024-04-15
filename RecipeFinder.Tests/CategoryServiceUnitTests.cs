using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Category;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Services;
using RecipeFinder.Data;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Tests
{
    [TestFixture]   
    public class CategoryServiceUnitTests
    {
        private RecipeFinderDbContext dbContext;

        private IRepository repository;
        private ICategoryService categoryService;
        private IRecipeService recipeService;
        private UserManager<ApplicationUser> userManager;

        private Category Category0;
        private Category Category1;
        private Category Category2;
        private Category Category3;
        private Category Category4;
        private Category Category5;

        private Recipe Recipe1;
        private Recipe Recipe2;
        private Recipe Recipe3;
        private Recipe Recipe4;
        private Recipe Recipe5;
        private Recipe Recipe6;

        private Ingredient Ingredient1;

        private Comment Comment1;

        private RecipeUser RecipeUser1;
        private RecipeUser RecipeUser2;

        [SetUp]
        public async Task SetUp()
        {
            Category0 = new Category
            {
                Id = 10,
                Name = "Category0"
            };

            Category1 = new Category
            {
                Id = 1,
                Name = "Category1"
            };

            Category2 = new Category
            {
                Id = 2,
                Name = "Category2"
            };

            Category3 = new Category
            {
                Id = 3,
                Name = "Category3"
            };

            Category4 = new Category
            {
                Id = 4,
                Name = "Category4"
            };

            Category5 = new Category
            {
                Id = 5,
                Name = "Category5"
            };

            Recipe1 = new Recipe
            {
                Id = 1,
                Name = "Recipe1",
                Instructions = "Instructions",
                CategoryId = 1,
                CookId = "223d7aa9-7ca5-4ccf-bcd2-0c3bf45f3e5e",
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"

            };

            Recipe2 = new Recipe
            {
                Id = 2,
                Name = "Recipe2",
                Instructions = "Instructions",
                CategoryId = 1,
                CookId = "223d7aa9-7ca5-4ccf-bcd2-0c3bf45f3e5e",
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"

            };

            Recipe3 = new Recipe
            {
                Id = 3,
                Name = "Recipe3",
                Instructions = "Instructions",
                CategoryId = 2,
                CookId = "223d7aa9-7ca5-4ccf-bcd2-0c3bf45f3e5e",
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"

            };

            Recipe4 = new Recipe
            {
                Id = 4,
                Name = "Recipe4",
                Instructions = "Instructions",
                CategoryId = 3,
                CookId = "223d7aa9-7ca5-4ccf-bcd2-0c3bf45f3e5e",
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"

            };

            Recipe5 = new Recipe
            {
                Id = 5,
                Name = "Recipe5",
                Instructions = "Instructions",
                CategoryId = 4,
                CookId = "223d7aa9-7ca5-4ccf-bcd2-0c3bf45f3e5e",
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"

            };

            Recipe6 = new Recipe
            {
                Id = 6,
                Name = "Recipe6",
                Instructions = "Instructions",
                CategoryId = 5,
                CookId = "223d7aa9-7ca5-4ccf-bcd2-0c3bf45f3e5e",
                PostedOn = DateTime.Now,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"

            };

            Ingredient1 = new Ingredient
            {
                Id = 1,
                Name = "Ingredient1",
                RecipeId = 5,
                Quantity = 1,
                Unit = "kg"
            };

            Comment1 = new Comment
            {
                Id = 1,
                RecipeId = 4,
                Title = "Title",
                Description = "Comment1",
                PostedOn = DateTime.Now
            };

            RecipeUser1 = new RecipeUser
            {
                RecipeId = 6,
                UserId = "223d7aa9-7ca5-4ccf-bcd2-0c3bf45f3e5e"
            };

            RecipeUser2 = new RecipeUser
            {
                RecipeId = 6,
                UserId = "8b1348e7-1596-40f1-98ee-06a3ccf20feb"
            };
                   

            var options = new DbContextOptionsBuilder<RecipeFinderDbContext>()
                .UseInMemoryDatabase(databaseName: "RecipeFinderInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new RecipeFinderDbContext(options);

            await dbContext.AddAsync(Category0);
            await dbContext.AddAsync(Category1);
            await dbContext.AddAsync(Category2);
            await dbContext.AddAsync(Category3);
            await dbContext.AddAsync(Category4);

            await dbContext.AddAsync(Recipe1);
            await dbContext.AddAsync(Recipe2);
            await dbContext.AddAsync(Recipe3);
            await dbContext.AddAsync(Recipe4);
            await dbContext.AddAsync(Recipe5);

            await dbContext.AddAsync(Ingredient1);

            await dbContext.AddAsync(Comment1);

            await dbContext.AddAsync(RecipeUser1);
            await dbContext.AddAsync(RecipeUser2);

            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            categoryService = new CategoryService(repository);
            recipeService = new RecipeService(repository, userManager);
        }

        [TearDown]
        public async Task TearDown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }

        [Test]
        public async Task ServiceShouldReturnAllCategories()
        {
            // Act
            var result = await categoryService.AllCategoriesAsync();

            // Assert
            Assert.AreEqual(5, result.Count());
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task DeleteAsync_CategoryWithoutRecipes_ShouldDeleteCategory()
        {
            // Arrange
            var categoryId = 10;

            // Act
            await categoryService.DeleteAsync(categoryId);

            // Assert
            Assert.IsFalse(await categoryService.ExistsAsync(categoryId));
        }


        [Test]
        public async Task DeleteAsync_CategoryWithRecipes_ShouldDeleteCategoryAndRecipes()
        {
            // Arrange
            var categoryId = 2;

            // Act
            await categoryService.DeleteAsync(categoryId);

            // Assert
            Assert.IsFalse(await categoryService.ExistsAsync(categoryId));
            Assert.IsFalse(await recipeService.ExistsAsync(3));

        }

        [Test]
        public async Task DeleteAsync_CategoryWithRecipes_ShouldDeleteCategoryAndRecipesAndComments()
        {
            // Arrange
            var categoryId = 3;

            // Act
            await categoryService.DeleteAsync(categoryId);

            // Assert
            Assert.IsFalse(await categoryService.ExistsAsync(categoryId));
            Assert.IsFalse(await recipeService.ExistsAsync(4));
            Assert.IsFalse(await repository.AllReadOnly<Comment>().AnyAsync(c => c.RecipeId == 4));
        }

        [Test]
        public async Task DeleteAsync_CategoryWithRecipes_ShouldDeleteCategoryAndRecipesAndIngredients()
        {
            // Arrange
            var categoryId = 4;

            // Act
            await categoryService.DeleteAsync(categoryId);

            // Assert
            Assert.IsFalse(await categoryService.ExistsAsync(categoryId));
            Assert.IsFalse(await recipeService.ExistsAsync(5));
            Assert.IsFalse(await repository.AllReadOnly<Ingredient>().AnyAsync(i => i.RecipeId == 5));
        }

        [Test]
        public async Task DeleteAsync_CategoryWithRecipes_ShouldDeleteCategoryAndRecipesAndRecipeUsers()
        {
            // Arrange
            var categoryId = 5;

            // Act
            await categoryService.DeleteAsync(categoryId);

            // Assert
            Assert.IsFalse(await categoryService.ExistsAsync(categoryId));
            Assert.IsFalse(await recipeService.ExistsAsync(6));
            Assert.IsTrue(await repository.AllReadOnly<RecipeUser>().AnyAsync(ru => ru.RecipeId == 6));
        }

        [Test]
        public async Task ExistsAsync_CategoryExists_ShouldReturnTrue()
        {
            // Arrange
            var categoryId = 1;

            // Act
            var result = await categoryService.ExistsAsync(categoryId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsync_CategoryDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var categoryId = 5;

            // Act
            var result = await categoryService.ExistsAsync(categoryId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CategoryInformationByIdAsync_CategoryExists_ShouldReturnCategoryViewModel()
        {
            // Arrange
            var categoryId = 1;

            // Act
            var result = await categoryService.CategoryInformationByIdAsync(categoryId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Category1.Name, result.Name);
            Assert.AreEqual(Category1.Id, result.Id);
        }
    }
}
