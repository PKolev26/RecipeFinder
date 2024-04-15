using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.RecipeModels;
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
    public class RecipeServiceUnitTests
    {
        private RecipeFinderDbContext dbContext;

        private IRepository repository;
        private IRecipeService recipeService;
        private UserManager<ApplicationUser> userManager;

        private ApplicationUser User1;

        private Recipe Recipe1;
        private Recipe Recipe2;
        private Recipe Recipe3;
        private Recipe Recipe4;

        private Category Category1;
        private Category Category2;

        private Difficulty Difficulty1;
        private Difficulty Difficulty2;
        private Difficulty Difficulty3;
        private Difficulty Difficulty4;
        private Difficulty Difficulty5;

        private Ingredient Ingredient1;
        private Ingredient Ingredient2;
        private Ingredient Ingredient3;
        private Ingredient Ingredient4;
        private Ingredient Ingredient5;

        private Comment Comment1;
        private Comment Comment2;

        private RecipeUser RecipeUser1;

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
                PreparationTime = 15,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Recipe2 = new Recipe
            {
                Id = 2,
                Name = "Recipe2",
                Instructions = "Instructions",
                CategoryId = 2,
                CookId = User1.Id,
                PostedOn = DateTime.Now.AddDays(1),
                PreparationTime = 10,
                DifficultyId = 2,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Recipe3 = new Recipe
            {
                Id = 3,
                Name = "Recipe3",
                Instructions = "Instructions",
                CategoryId = 1,
                CookId = User1.Id,
                PostedOn = DateTime.Now.AddDays(2),
                PreparationTime = 20,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            Recipe4 = new Recipe
            {
                Id = 4,
                Name = "Recipe4",
                Instructions = "Instructions",
                CategoryId = 2,
                CookId = User1.Id,
                PostedOn = DateTime.Now.AddDays(3),
                PreparationTime = 25,
                DifficultyId = 5,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
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

            Difficulty1 = new Difficulty
            {
                Id = 1,
                Name = "Difficulty1",
                SkillLevel = 1,
                Description = "Description",
                IngredientComplexity = "Complexity"
            };

            Difficulty2 = new Difficulty
            {
                Id = 2,
                Name = "Difficulty2",
                SkillLevel = 2,
                Description = "Description",
                IngredientComplexity = "Complexity"
            };

            Difficulty3 = new Difficulty
            {
                Id = 3,
                Name = "Difficulty3",
                SkillLevel = 3,
                Description = "Description",
                IngredientComplexity = "Complexity"
            };

            Difficulty4 = new Difficulty
            {
                Id = 4,
                Name = "Difficulty4",
                SkillLevel = 4,
                Description = "Description",
                IngredientComplexity = "Complexity"
            };

            Difficulty5 = new Difficulty
            {
                Id = 5,
                Name = "Difficulty5",
                SkillLevel = 5,
                Description = "Description",
                IngredientComplexity = "Complexity"
            };

            RecipeUser1 = new RecipeUser
            {
                RecipeId = Recipe3.Id,
                UserId = User1.Id
            };

            Ingredient1 = new Ingredient
            {
                Id = 1,
                Name = "Ingredient1",
                RecipeId = 1,
                Quantity = 1,
                Unit = "kg"
            };

            Ingredient2 = new Ingredient
            {
                Id = 2,
                Name = "Ingredient2",
                RecipeId = 2,
                Quantity = 1,
                Unit = "kg"
            };

            Ingredient3 = new Ingredient
            {
                Id = 3,
                Name = "Ingredient3",
                RecipeId = 1,
                Quantity = 1,
                Unit = "kg"
            };

            Ingredient4 = new Ingredient
            {
                Id = 4,
                Name = "Ingredient4",
                RecipeId = 3,
                Quantity = 1,
                Unit = "kg"
            };

            Ingredient5 = new Ingredient
            {
                Id = 5,
                Name = "Ingredient5",
                RecipeId = 4,
                Quantity = 1,
                Unit = "kg"
            };

            Comment1 = new Comment
            {
                Id = 1,
                Title = "Title",
                Description = "Comment1",
                RecipeId = 1,
                PostedOn = DateTime.Now,
                AuthorId = User1.Id
            };

            Comment2 = new Comment
            {
                Id = 2,
                Title = "Title",
                Description = "Comment2",
                RecipeId = 1,
                PostedOn = DateTime.Now,
                AuthorId = User1.Id
            };

            var options = new DbContextOptionsBuilder<RecipeFinderDbContext>()
                .UseInMemoryDatabase(databaseName: "RecipeFinderInMemoryDb" + Guid.NewGuid().ToString()).Options;

            dbContext = new RecipeFinderDbContext(options);


            await dbContext.AddAsync(User1);

            await dbContext.AddAsync(Recipe1);
            await dbContext.AddAsync(Recipe2);
            await dbContext.AddAsync(Recipe3);
            await dbContext.AddAsync(Recipe4);

            await dbContext.AddAsync(Category1);
            await dbContext.AddAsync(Category2);

            await dbContext.AddAsync(Difficulty1);
            await dbContext.AddAsync(Difficulty2);
            await dbContext.AddAsync(Difficulty3);
            await dbContext.AddAsync(Difficulty4);
            await dbContext.AddAsync(Difficulty5);

            await dbContext.AddAsync(RecipeUser1);

            await dbContext.AddAsync(Ingredient1);
            await dbContext.AddAsync(Ingredient2);
            await dbContext.AddAsync(Ingredient3);
            await dbContext.AddAsync(Ingredient4);
            await dbContext.AddAsync(Ingredient5);

            await dbContext.AddAsync(Comment1);
            await dbContext.AddAsync(Comment2);

            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            recipeService = new RecipeService(repository, userManager);
        }

        [TearDown]
        public async Task TearDown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }

        [Test]
        public async Task AddAsync_ShouldAddRecipe()
        {
            // Arrange
            var model = new RecipeFormViewModel
            {
                Name = "Recipe1",
                Instructions = "Instructions",
                CategoryId = 1,
                PreparationTime = 10,
                CookId = User1.Id,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            // Act
            await recipeService.AddAsync(model, User1);

            var recipe = await dbContext.Recipes.FirstOrDefaultAsync();

            // Assert

            Assert.AreEqual(1, recipe.Id);
            Assert.AreEqual("Recipe1", recipe.Name);
            Assert.AreEqual("Instructions", recipe.Instructions);
            Assert.AreEqual(1, recipe.CategoryId);
            Assert.AreEqual(User1.Id, recipe.CookId);
            Assert.AreEqual(1, recipe.DifficultyId);
            Assert.AreEqual("https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg", recipe.ImageUrl);
        }

        [Test]
        public async Task RecipeDetailsByIdAsync_ShouldReturnRecipe()
        {
            // Act
            var recipe = await recipeService.RecipeDetailsByIdAsync(Recipe1.Id);

            // Assert
            Assert.IsNotNull(recipe);
            Assert.AreEqual(1, recipe.Id);
            Assert.AreEqual("Recipe1", recipe.Name);
            Assert.AreEqual("Instructions", recipe.Instructions);
            Assert.AreEqual("Category1", recipe.CategoryName);
            Assert.AreEqual("Difficulty1", recipe.DifficultyName);
            Assert.AreEqual(15, recipe.PreparationTime);
            Assert.AreEqual(User1.Id, recipe.CookId);
            Assert.AreEqual("https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg", recipe.ImageUrl);
        }

        [Test]
        public async Task AddToRecipeUsersAsync_ShouldAddToRecipeUsers()
        {
            // Arrange
            var currentUser = User1;

            // Act
            await recipeService.AddToRecipeUsersAsync(Recipe1.Id, currentUser);

            var recipeUser = await repository.AllReadOnly<RecipeUser>()
                .FirstOrDefaultAsync(ru => ru.RecipeId == Recipe1.Id && ru.UserId == currentUser.Id);

            // Assert
            Assert.IsNotNull(recipeUser);
            Assert.AreEqual(Recipe1.Id, recipeUser.RecipeId);
            Assert.AreEqual(User1.Id, recipeUser.UserId);
        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategories()
        {
            // Act
            var categories = await recipeService.AllCategoriesAsync();

            // Assert
            Assert.IsNotNull(categories);
            Assert.AreEqual(2, categories.Count());
        }

        [Test]
        public async Task AllCategoriesNamesAsyncShouldReturnAllCategoriesNames()
        {
            // Act
            var categories = await recipeService.AllCategoriesNamesAsync();

            // Assert
            Assert.IsNotNull(categories);
            Assert.AreEqual(2, categories.Count());
            Assert.AreEqual("Category1", categories.First());
            Assert.AreEqual("Category2", categories.Last());
        }

        [Test]
        public async Task AllDifficultiesAsyncShouldReturnAllDifficulties()
        {
            // Act
            var difficulties = await recipeService.AllDifficultiesAsync();

            // Assert
            Assert.IsNotNull(difficulties);
            Assert.AreEqual(5, difficulties.Count());
        }

        [Test]
        public async Task AllDifficultiesNamesAsyncShouldReturnAllDifficultiesNames()
        {
            // Act
            var difficulties = await recipeService.AllDifficultiesNamesAsync();

            // Assert
            Assert.IsNotNull(difficulties);
            Assert.AreEqual(5, difficulties.Count());
            Assert.AreEqual("Difficulty1", difficulties.First());
            Assert.AreEqual("Difficulty5", difficulties.Last());
        }

        [Test]
        public async Task AllRecipesByCategory1ShouldReturnRecipesWithCategory1()
        {
            // Arrange
            var category = "Category1";

            // Act
            var recipes = await recipeService.AllRecipesAsync(category: category);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(2, recipes.TotalRecipesCount);
        }

        [Test]
        public async Task AllRecipesByDifficulty1ShouldReturnRecipesWithDifficulty1()
        {
            // Arrange
            var difficulty = "Difficulty1";

            // Act
            var recipes = await recipeService.AllRecipesAsync(difficulty: difficulty);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(2, recipes.TotalRecipesCount);
        }

        [Test]
        public async Task AllRecipesBySearchShouldReturnRecipesWithSearch()
        {
            // Arrange
            var search = "Recipe1";

            // Act
            var recipes = await recipeService.AllRecipesAsync(search: search);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(1, recipes.TotalRecipesCount);
            Assert.AreEqual("Recipe1", recipes.Recipes.First().Name);
        }

        [Test]
        public async Task AllRecipesBySortingShouldReturnRecipesWithSortingNewest()
        {
            // Arrange
            var sorting = RecipeSorting.Newest;

            // Act
            var recipes = await recipeService.AllRecipesAsync(sorting: sorting);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.TotalRecipesCount);
            Assert.AreEqual("Recipe4", recipes.Recipes.First().Name);
        }

        [Test]
        public async Task AllRecipesBySortingShouldReturnRecipesWithOldest()
        {
            // Arrange
            var sorting = RecipeSorting.Oldest;

            // Act
            var recipes = await recipeService.AllRecipesAsync(sorting: sorting);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.TotalRecipesCount);
            Assert.AreEqual("Recipe1", recipes.Recipes.First().Name);
        }

        [Test]
        public async Task AllRecipesBySortingShouldReturnRecipesByPopular()
        {
            // Arrange
            var sorting = RecipeSorting.Popular;

            // Act
            var recipes = await recipeService.AllRecipesAsync(null, sorting: sorting, 1, 3);

            var recipeSort = new List<int>
            {
                recipes.Recipes.First().MadeByCount,
                recipes.Recipes.Skip(1).First().MadeByCount,
                recipes.Recipes.Skip(2).First().MadeByCount,
                recipes.Recipes.Last().MadeByCount
            };

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.TotalRecipesCount);
            Assert.AreEqual(new List<int> { 1, 0, 0 , 0 }, recipeSort);
        }

        [Test]
        public async Task AllRecipesBySortingShouldReturnRecipesByPreparationTimeAscending()
        {
            // Arrange
            var sorting = RecipeSorting.ByPreparationTimeAscending;

            // Act
            var recipes = await recipeService.AllRecipesAsync(null, sorting: sorting, 1, 4);

            var recipeSort = new List<int>
            {
                recipes.Recipes.First().PreparationTime,
                recipes.Recipes.Skip(1).First().PreparationTime,
                recipes.Recipes.Skip(2).First().PreparationTime,
                recipes.Recipes.Last().PreparationTime
            };

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.TotalRecipesCount);
            Assert.AreEqual(new List<int> { 10, 15, 20, 25 }, recipeSort);
        }

        [Test]
        public async Task AllRecipesBySortingShouldReturnRecipesByPreparationTimeDescending()
        {
            // Arrange
            var sorting = RecipeSorting.ByPreparationTimeDescending;

            // Act
            var recipes = await recipeService.AllRecipesAsync(null, sorting: sorting, 1, 4);

            var recipeSort = new List<int>
            {
                recipes.Recipes.First().PreparationTime,
                recipes.Recipes.Skip(1).First().PreparationTime,
                recipes.Recipes.Skip(2).First().PreparationTime,
                recipes.Recipes.Last().PreparationTime
            };

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.TotalRecipesCount);
            Assert.AreEqual(new List<int> { 25, 20, 15, 10 }, recipeSort);
        }

        [Test]
        public async Task AllRecipesSortedByIngredientsCountAscending()
        {
            // Arrange
            var sorting = RecipeSorting.ByIngredientsCountAscending;

            // Act
            var recipes = await recipeService.AllRecipesAsync(null, sorting: sorting, 1, 43);
            var recipeSort = new List<int>()
            {
                recipes.Recipes.First().IngredientCount,
                recipes.Recipes.Skip(1).First().IngredientCount,
                recipes.Recipes.Skip(2).First().IngredientCount,
                recipes.Recipes.Last().IngredientCount,

            };

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.TotalRecipesCount);
            Assert.AreEqual(new List<int> { 1, 1, 1, 2 }, recipeSort);
        }

        [Test]
        public async Task AllRecipesSortedByIngredientsCountDescending()
        {
            // Arrange
            var sorting = RecipeSorting.ByIngredientsCountDescending;

            // Act
            var recipes = await recipeService.AllRecipesAsync(null, sorting: sorting, 1, 4);
            var recipeSort = new List<int>()
            {
                recipes.Recipes.First().IngredientCount,
                recipes.Recipes.Skip(1).First().IngredientCount,
                recipes.Recipes.Skip(2).First().IngredientCount,
                recipes.Recipes.Last().IngredientCount
            };

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.TotalRecipesCount);
            Assert.AreEqual(new List<int> { 2, 1, 1, 1 }, recipeSort);
        }

        [Test]
        public async Task DeleteAsyncShouldRemoveRecipes()
        {
            // Act
            await recipeService.DeleteAsync(Recipe1.Id);

            var recipe = await repository.AllReadOnly<Recipe>().FirstOrDefaultAsync(r => r.Id == Recipe1.Id);

            // Assert
            Assert.IsNull(recipe);
        }

        [Test]
        public async Task DeleteAsyncShouldRemoveIngredients()
        {
            // Act
            await recipeService.DeleteAsync(Recipe2.Id);

            var ingredients = await repository.AllReadOnly<Ingredient>().Where(i => i.RecipeId == Recipe2.Id).AnyAsync();

            // Assert
            Assert.IsFalse(ingredients);
        }

        [Test]
        public async Task DeleteAsyncShouldRemoveComments()
        {
            // Act
            await recipeService.DeleteAsync(Recipe1.Id);

            var comments = await repository.AllReadOnly<Comment>().Where(c => c.RecipeId == Recipe3.Id).AnyAsync();

            // Assert
            Assert.IsFalse(comments);
        }

        [Test]
        public async Task DetailsAsyncShouldReturnCorrectRecipe()
        {
            // Act
            var recipe = await recipeService.DetailsAsync(Recipe1.Id);

            // Assert
            Assert.IsNotNull(recipe);
            Assert.AreEqual(1, recipe.First().Id);
            Assert.AreEqual("Recipe1", recipe.First().Name);
            Assert.AreEqual("Instructions", recipe.First().Instructions);
            Assert.AreEqual("Category1", recipe.First().CategoryName);
            Assert.AreEqual("Difficulty1", recipe.First().DifficultyName);
            Assert.AreEqual(15, recipe.First().PreparationTime);
            Assert.AreEqual("User", recipe.First().CookFirstName);
            Assert.AreEqual("User", recipe.First().CookLastName);
            Assert.AreEqual(2, recipe.First().Ingredients.Count());
            Assert.AreEqual(0, recipe.First().MadeByCount);
        }

        [Test]
        public async Task ExistsAsyncShouldReturnTrueIfRecipeExists()
        {
            // Act
            var result = await recipeService.ExistsAsync(Recipe1.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsyncShouldReturnFalseIfRecipeDoesNotExist()
        {
            // Act
            var result = await recipeService.ExistsAsync(5);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task EditAsyncShouldReturnCorrectData()
        {
            // Arrange
            var model = new RecipeFormViewModel
            {
                Name = "Recipe1NewName",
                Instructions = "Instructions",
                CategoryId = 1,
                PreparationTime = 10,
                CookId = User1.Id,
                DifficultyId = 1,
                ImageUrl = "https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg"
            };

            // Act
            await recipeService.EditAsync(Recipe1.Id, model);

            var recipe = await repository.AllReadOnly<Recipe>().FirstOrDefaultAsync(r => r.Id == Recipe1.Id);

            // Assert
            Assert.IsNotNull(recipe);
            Assert.That(recipe.Name, Is.EqualTo("Recipe1NewName"));

        }

        [Test]
        public async Task RecipeBookAsyncShouldReturnCorrectData()
        {
            // Arrange
            var currentUser = User1;

            // Act
            var recipes = await recipeService.RecipeBookAsync(currentUser);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(1, recipes.Count());
            Assert.AreEqual(3, recipes.First().Id);
            Assert.AreEqual("Recipe3", recipes.First().Name);
            Assert.AreEqual("Category1", recipes.First().CategoryName);
            Assert.AreEqual("Difficulty1", recipes.First().DifficultyName);
            Assert.AreEqual(20, recipes.First().PreparationTime);
            Assert.AreEqual("User", recipes.First().CookFirstName);
            Assert.AreEqual("User", recipes.First().CookLastName);
            Assert.AreEqual(1, recipes.First().IngredientCount);
            Assert.AreEqual(1, recipes.First().MadeByCount);
        }

        [Test]
        public async Task RecipeBookAsyncShouldReturnEmptyListIfNoRecipes()
        {
            // Arrange
            var currentUser = (ApplicationUser)null;

            // Act
            var recipes = await recipeService.RecipeBookAsync(currentUser);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.IsEmpty(recipes);
        }

        [Test]
        public async Task MineRecipesShouldReturnCorrectData()
        {
            // Arrange
            var currentUser = User1;

            // Act
            var recipes = await recipeService.MineRecipesAsync(currentUser);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(4, recipes.Count());
        }

        [Test]
        public async Task MineRecipesShouldReturnEmptyListIfNoRecipes()
        {
            // Arrange
            var currentUser = (ApplicationUser)null;

            // Act
            var recipes = await recipeService.MineRecipesAsync(currentUser);

            // Assert
            Assert.IsNotNull(recipes);
            Assert.IsEmpty(recipes);
        }

        [Test]
        public async Task GetRecipeFormViewModelByIdShouldReturnCorrectData()
        {
            // Arrange
            var recipe = Recipe1;

            // Act
            var model = await recipeService.GetRecipeFormViewModelByIdAsync(recipe.Id);

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual("Recipe1", model.Name);
            Assert.AreEqual("Instructions", model.Instructions);
            Assert.AreEqual(1, model.CategoryId);
            Assert.AreEqual(15, model.PreparationTime);
            Assert.AreEqual(User1.Id, model.CookId);
            Assert.AreEqual(1, model.DifficultyId);
            Assert.AreEqual("https://www.allrecipes.com/thmb/xGrOGKAfjs7YhRUGXFi71ZMpoSc=/0x512/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/410873_Judys-Strawberry-Pretzel-Salad-4x3-758ada2d0d794541b04d4ff9bad788ee.jpg", model.ImageUrl);
        }

        [Test]
        public async Task GetRecipeFormViewModelByIdShouldReturnNullIfRecipeDoesNotExist()
        {
            // Arrange
            var recipe = Recipe1;

            // Act
            var model = await recipeService.GetRecipeFormViewModelByIdAsync(5);

            // Assert
            Assert.IsNull(model);
        }

        [Test]
        public async Task RecipesInMasterShouldReturnCorrectDataIfDifficultyIdIs5()
        {
            // Arrange

            // Act
            var recipes = await recipeService.RecipesInMasterChefDifficultyAsync();

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(1, recipes.Count());
            Assert.AreEqual("Difficulty5", recipes.First().DifficultyName);
        }

        [Test]
        public async Task TheLastestRecipeAsyncShouldReturnCorrectData()
        {
            // Arrange

            // Act
            var recipe = await recipeService.TheLastedRecipeAsync();

            // Assert
            Assert.IsNotNull(recipe);
            Assert.AreEqual(4, recipe.First().Id);
        }

        [Test]
        public async Task Top3RecipesAsyncShouldReturnCorrectData()
        {
            // Arrange

            // Act
            var recipes = await recipeService.Top3RecipesAsync();

            // Assert
            Assert.IsNotNull(recipes);
            Assert.AreEqual(3, recipes.Count());
            Assert.AreEqual(1, recipes.First().MadeByCount);
            Assert.AreEqual(0, recipes.Skip(1).First().MadeByCount);
            Assert.AreEqual(0, recipes.Last().MadeByCount);
            Assert.AreEqual("Recipe3", recipes.First().Name);
            Assert.AreEqual("Recipe1", recipes.Skip(1).First().Name);
            Assert.AreEqual("Recipe2", recipes.Last().Name);
        }
    }

}
