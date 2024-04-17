using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.DifficultyModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipeService(IRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this._userManager = userManager;
        }

        // AddAsync method is used to add a recipe to the database. It takes a RecipeFormViewModel and ApplicationUser as parameters. It creates a new Recipe object and adds it to the database.

        public async Task<int> AddAsync(RecipeFormViewModel model, ApplicationUser cookId)
        {
            Recipe newRecipe = new Recipe
            {
                Name = model.Name,
                CookId = cookId.Id,
                ImageUrl = model.ImageUrl,
                Instructions = model.Instructions,
                PreparationTime = model.PreparationTime,
                CategoryId = model.CategoryId,
                DifficultyId = model.DifficultyId,
                PostedOn = DateTime.Now
            };

            await repository.AddAsync(newRecipe);
            await repository.SaveChangesAsync();

            return newRecipe.Id;
        }

        // AddToRecipeUsersAsync method is used to add a recipe to a user's recipe book. It takes a recipeId and ApplicationUser as parameters. It creates a new RecipeUser object and adds it to the database.
        public async Task AddToRecipeUsersAsync(int recipeId, ApplicationUser userId)
        {
            RecipeUser recipeUser = new RecipeUser
            {
                RecipeId = recipeId,
                UserId = userId.Id
            };
            await repository.AddAsync(recipeUser);
            await repository.SaveChangesAsync();

        }

        // AllCategoriesAsync method is used to get all categories in the database. It returns a list of CategoryViewModel.

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(ct => new CategoryViewModel()
                {
                    Id = ct.Id,
                    Name = ct.Name
                })
                .ToListAsync();
        }

        // AllCategoriesNamesAsync method is used to get all category names in the database. It returns a list of strings.

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(ct => ct.Name)
                .ToListAsync();
        }

        // AllDifficultiesAsync method is used to get all difficulties in the database. It returns a list of DifficultyViewModel.
        public async Task<IEnumerable<DifficultyViewModel>> AllDifficultiesAsync()
        {
            return await repository.AllReadOnly<Difficulty>()
                .Select(d => new DifficultyViewModel()
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        // AllDifficultiesNamesAsync method is used to get all difficulty names in the database. It returns a list of strings.
        public async Task<IEnumerable<string>> AllDifficultiesNamesAsync()
        {
            return await repository.AllReadOnly<Difficulty>()
               .Select(d => d.Name)
               .ToListAsync();
        }

        // AllRecipesAsync method is used to get all recipes in the database. It takes optional parameters for search, sorting, currentPage, recipesPerPage, category, and difficulty. It returns a RecipeQueryServiceModel.
        public async Task<RecipeQueryServiceModel> AllRecipesAsync(string? search = null, RecipeSorting sorting = RecipeSorting.Newest, int currentPage = 1, int recipesPerPage = 1, string? category = null, string? difficulty = null)
        {
            var recipes = repository.AllReadOnly<Recipe>().Where(r => r.Ingredients.Count > 0);

            if (category != null)
            {
                recipes = recipes
                   .Where(r => r.Category.Name == category);
            }

            if (difficulty != null)
            {   
                recipes = recipes
                   .Where(r => r.Difficulty.Name == difficulty);
            }

            if (search != null)
            {
                string searchToLower = search.ToLower();
                recipes = recipes
                    .Where(r => (r.Name.ToLower().Contains(searchToLower)));
            }

            recipes = sorting switch
            {
                RecipeSorting.ByIngredientsCountAscending => recipes
                    .OrderBy(r => r.Ingredients.Count),
                RecipeSorting.ByIngredientsCountDescending => recipes
                    .OrderByDescending(r => r.Ingredients.Count),
                RecipeSorting.Popular => recipes
                    .OrderByDescending(r => r.RecipesUsers.Count),
                RecipeSorting.Oldest => recipes
                   .OrderBy(h => h.Id),
                RecipeSorting.ByPreparationTimeAscending => recipes
                    .OrderBy(r => r.PreparationTime),
                RecipeSorting.ByPreparationTimeDescending => recipes
                .OrderByDescending(r => r.PreparationTime),
                _ => recipes
                    .OrderByDescending(h => h.Id)
            };

            var AllRecipes = await recipes
                .Skip((currentPage - 1) * recipesPerPage)
                .Take(recipesPerPage)
                .Select(e => new RecipeServiceModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    PreparationTime = e.PreparationTime,
                    PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                    CategoryId = e.CategoryId,
                    CategoryName = e.Category.Name,
                    DifficultyId = e.DifficultyId,
                    DifficultyName = e.Difficulty.Name,
                    CookUsername = e.Cook.UserName,
                    CookFirstName = e.Cook.FirstName,
                    CookLastName = e.Cook.LastName,
                    IngredientCount = e.Ingredients.Count(),
                    CommentCount = e.Comments.Count(),
                    MadeByCount = e.RecipesUsers.Count(),
                    RecipeUser = e.RecipesUsers.FirstOrDefault(),
                })
                .ToListAsync();

            int recipesCount = await recipes.CountAsync();

            return new RecipeQueryServiceModel()
            {
                Recipes = AllRecipes,
                TotalRecipesCount = recipesCount
            };
        }

        // DeleteAsync method is used to delete a recipe from the database. It first gets all ingredients, comments, and recipeUsers that are in the recipe and deletes them, then deletes the recipe.
        public async Task DeleteAsync(int recipeId)
        {
            var ingredientsToRemove = await repository.AllReadOnly<Ingredient>()
                .Where(i => i.RecipeId == recipeId)
                .ToListAsync();

            foreach (var ingredient in ingredientsToRemove)
            {
                await repository.DeleteAsync<Ingredient>(ingredient.RecipeId);
            }

            var commentsToRemove = await repository.AllReadOnly<Comment>()
                .Where(c => c.RecipeId == recipeId)
                .ToListAsync();

            foreach (var comment in commentsToRemove)
            {
                await repository.DeleteAsync<Comment>(comment.Id);
            }

            var recupeUsersToRemove = await repository.AllReadOnly<RecipeUser>()
                .Where(c => c.RecipeId == recipeId)
                .ToListAsync();

            foreach (var recipeUsers in recupeUsersToRemove)
            {
                RecipeUser recipeUserToRemove = new RecipeUser()
                {
                    RecipeId = recipeUsers.RecipeId,
                    UserId = recipeUsers.UserId
                };
                await repository.RemoveAsync(recipeUserToRemove);
            }
            await repository.DeleteAsync<Recipe>(recipeId);
            await repository.SaveChangesAsync();
        }

        // DetailsAsync method is used to get details about a recipe by its id. It takes a recipeId as a parameter and returns a RecipeDetailsServiceModel.
        public async Task<IEnumerable<RecipeDetailsServiceModel>> DetailsAsync(int id)
        {
            return await repository.AllReadOnly<Recipe>()
                .Where(e => e.Id == id)
                .Select(e => new RecipeDetailsServiceModel()
                {
                    Id = id,
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    PreparationTime = e.PreparationTime,
                    Instructions = e.Instructions,
                    PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                    CategoryName = e.Category.Name,
                    DifficultyName = e.Difficulty.Name,
                    CookFirstName = e.Cook.FirstName,
                    CookLastName = e.Cook.LastName,
                    Comments = (ICollection<CommentsInfoViewModel>)e.Comments.Select(c => new CommentsInfoViewModel
                    {
                        Title = c.Title,
                        Description = c.Description,
                        PostedOn = c.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                        AuthorFirstName = c.Author.FirstName,
                        AuthorLastName = c.Author.LastName,
                        AuthorProfilePicture = c.Author.ProfilePicture,
                        AuthorId = c.AuthorId,
                        RecipeId = c.RecipeId,
                        Id = c.Id,
                    }),
                    Ingredients = e.Ingredients,
                    MadeByCount = e.RecipesUsers.Count()
                })
                .ToListAsync();
        }

        // EditAsync method is used to edit a recipe in the database. It takes a recipeId and RecipeFormViewModel as parameters. It gets the recipe by its id and updates its properties.
        public async Task EditAsync(int recipeId, RecipeFormViewModel model)
        {
            var recipe = await repository.GetByIdAsync<Recipe>(recipeId);

            if (recipe != null)
            {
                recipe.Name = model.Name;
                recipe.Instructions = model.Instructions;
                recipe.ImageUrl = model.ImageUrl;
                recipe.PreparationTime = model.PreparationTime;
                recipe.CategoryId = model.CategoryId;
                recipe.DifficultyId = model.DifficultyId;

                await repository.SaveChangesAsync();
            }
        }

        // ExistsAsync method is used to check if a recipe exists in the database. It takes a recipeId as a parameter and returns a boolean.
        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Recipe>()
               .AnyAsync(r => r.Id == id);
        }

        // GetRecipeFormViewModelByIdAsync method is used to get a RecipeFormViewModel by its id. It takes a recipeId as a parameter and returns a RecipeFormViewModel.
        public async Task<RecipeFormViewModel?> GetRecipeFormViewModelByIdAsync(int id)
        {
            var recipe = await repository.AllReadOnly<Recipe>()
                .Where(r => r.Id == id)
                .Select(r => new RecipeFormViewModel()
                {
                    Name = r.Name,
                    Instructions = r.Instructions,
                    ImageUrl = r.ImageUrl,
                    PreparationTime = r.PreparationTime,
                    CategoryId = r.CategoryId,
                    DifficultyId = r.DifficultyId,
                    CookId = r.CookId
                })
                .FirstOrDefaultAsync();

            if (recipe != null)
            {
                recipe.Categories = await AllCategoriesAsync();
                recipe.Difficulties = await AllDifficultiesAsync();
            }

            return recipe;
        }

        // MineRecipesAsync method is used to get all recipes that belong to a user. It takes an ApplicationUser as a parameter and returns a list of RecipeInfoViewModel.
        public async Task<IEnumerable<RecipeInfoViewModel>> MineRecipesAsync(ApplicationUser currentUser)
        {
            if (currentUser == null)
            {
                return Enumerable.Empty<RecipeInfoViewModel>();
            }

            return await repository.AllReadOnly<Recipe>()
              .Where(e => e.CookId == currentUser.Id)
              .Select(e => new RecipeInfoViewModel()
              {
                  Id = e.Id,
                  Name = e.Name,
                  ImageUrl = e.ImageUrl,
                  PreparationTime = e.PreparationTime,
                  PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                  CategoryName = e.Category.Name,
                  DifficultyName = e.Difficulty.Name,
                  CookFirstName = e.Cook.FirstName,
                  CookLastName = e.Cook.LastName,
                  IngredientCount = e.Ingredients.Count(),
                  CommentCount = e.Comments.Count(),
                  MadeByCount = e.RecipesUsers.Count()
              })
              .ToListAsync();
        }

        // RecipeBookAsync method is used to get all recipes that belong to a user's recipe book. It takes an ApplicationUser as a parameter and returns a list of RecipeInfoViewModel.
        public async Task<IEnumerable<RecipeInfoViewModel>> RecipeBookAsync(ApplicationUser currentUser)
        {
            if (currentUser == null)
            {
                return Enumerable.Empty<RecipeInfoViewModel>();
            }

            return await repository.AllReadOnly<RecipeUser>()
              .Where(r => r.UserId == currentUser.Id)
              .AsNoTracking()
              .Select(e => new RecipeInfoViewModel()
              {
                  Id = e.Recipe.Id,
                  Name = e.Recipe.Name,
                  ImageUrl = e.Recipe.ImageUrl,
                  PreparationTime = e.Recipe.PreparationTime,
                  PostedOn = e.Recipe.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                  CategoryName = e.Recipe.Category.Name,
                  DifficultyName = e.Recipe.Difficulty.Name,
                  CookFirstName = e.Recipe.Cook.FirstName,
                  CookLastName = e.Recipe.Cook.LastName,
                  IngredientCount = e.Recipe.Ingredients.Count(),
                  CommentCount = e.Recipe.Comments.Count(),
                  MadeByCount = e.Recipe.RecipesUsers.Count()
              })
              .ToListAsync();
        }

        // RecipeDetailsByIdAsync method is used to get details about a recipe by its id. It takes a recipeId as a parameter and returns a RecipeDetailsServiceModel.
        public async Task<RecipeDetailsServiceModel> RecipeDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Recipe>()
                .Include(r => r.RecipesUsers)
                .Where(r => r.Id == id)
                .Select(r => new RecipeDetailsServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Instructions = r.Instructions,
                    CategoryName = r.Category.Name,
                    DifficultyName = r.Difficulty.Name,
                    ImageUrl = r.ImageUrl,
                    PreparationTime = r.PreparationTime,
                    PostedOn = r.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                    RecipeUser = r.RecipesUsers.FirstOrDefault(),
                    CookId = r.CookId
                })
                .FirstAsync();
        }

        // RecipesInMasterChefDifficultyAsync method is used to get all recipes that are in the Master Chef difficulty. It returns a list of RecipeInfoViewModel.
        public async Task<IEnumerable<RecipeInfoViewModel>> RecipesInMasterChefDifficultyAsync()
        {
            return await repository.AllReadOnly<Recipe>()
               .Where(e => e.Difficulty.Id == 5)
              .Select(e => new RecipeInfoViewModel()
              {   
                  Id = e.Id,
                  Name = e.Name,
                  ImageUrl = e.ImageUrl,
                  PreparationTime = e.PreparationTime,
                  PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                  CategoryName = e.Category.Name,
                  DifficultyName = e.Difficulty.Name,
                  CookUserName = e.Cook.UserName,
                  CookFirstName = e.Cook.FirstName,
                  CookLastName = e.Cook.LastName,
                  IngredientCount = e.Ingredients.Count(),
                  CommentCount = e.Comments.Count(),
                  MadeByCount = e.RecipesUsers.Count()
              })
              .ToListAsync();
        }

        // RemoveFromRecipeUsersAsync method is used to remove a recipe from a user's recipe book. It takes a recipeId and ApplicationUser as parameters. It creates a new RecipeUser object and removes it from the database.
        public async Task RemoveFromRecipeUsersAsync(int recipeId, ApplicationUser userId)
        {
            RecipeUser recipeUser = new RecipeUser
            {
                RecipeId = recipeId,
                UserId = userId.Id
            };
            await repository.RemoveAsync(recipeUser);

            await repository.SaveChangesAsync();

        }

        // TheLastedRecipeAsync method is used to get the last recipe posted. It returns a list of RecipeInfoViewModel.
        public async Task<IEnumerable<RecipeInfoViewModel>> TheLastedRecipeAsync()
        {
            return await repository.AllReadOnly<Recipe>()
               .OrderByDescending(e => e.PostedOn)
               .Select(e => new RecipeInfoViewModel()
               {
                   Id = e.Id,
                   Name = e.Name,
                   ImageUrl = e.ImageUrl,
                   PreparationTime = e.PreparationTime,
                   PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                   CategoryName = e.Category.Name,
                   DifficultyName = e.Difficulty.Name,
                   CookFirstName = e.Cook.FirstName,
                   CookLastName = e.Cook.LastName,
                   IngredientCount = e.Ingredients.Count(),
                   CommentCount = e.Comments.Count(),
                   MadeByCount = e.RecipesUsers.Count()
               })
               .Take(1)
               .ToListAsync();
        }

        // Top3RecipesAsync method is used to get the top 3 recipes that have been made by the most users. It returns a list of RecipeInfoViewModel.
        public async Task<IEnumerable<RecipeInfoViewModel>> Top3RecipesAsync()
        {
            return await repository.AllReadOnly<Recipe>()
               .Select(e => new RecipeInfoViewModel()
               {
                   Id = e.Id,
                   Name = e.Name,
                   ImageUrl = e.ImageUrl,
                   PreparationTime = e.PreparationTime,
                   PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                   CategoryName = e.Category.Name,
                   DifficultyName = e.Difficulty.Name,
                   CookFirstName = e.Cook.FirstName,
                   CookLastName = e.Cook.LastName,
                   IngredientCount = e.Ingredients.Count(),
                   CommentCount = e.Comments.Count(),
                   MadeByCount = e.RecipesUsers.Count()
               })
               .OrderByDescending(e => e.MadeByCount)
               .Take(3)
               .ToListAsync();
        }
    }
}
