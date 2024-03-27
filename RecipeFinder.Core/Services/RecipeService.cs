using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.DifficultyModels;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RecipeFinder.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository repository;
        private readonly UserManager<IdentityUser> _userManager;

        public RecipeService(IRepository repository, UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this._userManager = userManager;
        }

        public async Task<int> AddAsync(RecipeFormViewModel model, IdentityUser cookId)
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

        public async Task AddToRecipeUsersAsync(int recipeId, IdentityUser userId)
        {
            RecipeUser recipeUser = new RecipeUser
            {
                RecipeId = recipeId,
                UserId = userId.Id
            };
            await repository.AddAsync(recipeUser);
            await repository.SaveChangesAsync();

        }

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

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(ct => ct.Name)
                .ToListAsync();
        }

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

        public async Task<IEnumerable<string>> AllDifficultiesNamesAsync()
        {
            return await repository.AllReadOnly<Difficulty>()
               .Select(d => d.Name)
               .ToListAsync();
        }

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
                RecipeSorting.ByIngredientsCount => recipes
                    .OrderByDescending(r => r.Ingredients.Count),
                RecipeSorting.Popular => recipes
                    .OrderByDescending(r => r.RecipesUsers.Count),
                RecipeSorting.ByPreparationTime => recipes
                    .OrderBy(r => r.PreparationTime),
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
                    Cook = e.Cook.UserName,
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

        public async Task<IEnumerable<RecipeDetailsViewModel>> DetailsAsync(int id)
        {
            return await repository.AllReadOnly<Recipe>()
                .Where(e => e.Id == id)
                .Select(e => new RecipeDetailsViewModel()
                {
                    Id = id,
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    PreparationTime = e.PreparationTime,
                    Instructions = e.Instructions,
                    PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                    CategoryName = e.Category.Name,
                    DifficultyName = e.Difficulty.Name,
                    Cook = e.Cook.UserName,
                    Comments = (ICollection<CommentsInfoViewModel>)e.Comments.Select(c => new CommentsInfoViewModel
                    {
                        Title = c.Title,
                        Description = c.Description,
                        PostedOn = c.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                        AuthorName = c.Author.UserName
                    }),
                    Ingredients = e.Ingredients,
                    MadeByCount = e.RecipesUsers.Count()
                })
                .ToListAsync();
        }

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

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Recipe>()
               .AnyAsync(r => r.Id == id);
        }

        public async Task<string?> GetCookIdAsync(string cookId)
        {
            return (await repository
                .AllReadOnly<IdentityUser>()
                .FirstOrDefaultAsync(iu => iu.Id == cookId))?.Id;
        }

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

        public async Task<IEnumerable<RecipeInfoViewModel>> MineRecipesAsync(IdentityUser currentUser)
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
                  Cook = e.Cook.UserName,
                  IngredientCount = e.Ingredients.Count(),
                  CommentCount = e.Comments.Count(),
                  MadeByCount = e.RecipesUsers.Count()
              })
              .ToListAsync();
        }

        public async Task<IEnumerable<RecipeInfoViewModel>> RecipeBookAsync(IdentityUser currentUser)
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
                  Cook = e.Recipe.Cook.UserName,
                  IngredientCount = e.Recipe.Ingredients.Count(),
                  CommentCount = e.Recipe.Comments.Count(),
                  MadeByCount = e.Recipe.RecipesUsers.Count()
              })
              .ToListAsync();
        }

        public async Task<RecipeDetailsViewModel> RecipeDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Recipe>()
                .Include(r => r.RecipesUsers)
                .Where(r => r.Id == id)
                .Select(r => new RecipeDetailsViewModel()
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


        public async Task<IEnumerable<RecipeInfoViewModel>> RecipesInMasterChefDifficultyAsync()
        {
            return await repository.AllReadOnly<Recipe>()
               .Where(e => e.Difficulty.Id == 5)
              .Select(e => new RecipeInfoViewModel()
              {
                  Name = e.Name,
                  ImageUrl = e.ImageUrl,
                  PreparationTime = e.PreparationTime,
                  PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                  CategoryName = e.Category.Name,
                  DifficultyName = e.Difficulty.Name,
                  Cook = e.Cook.UserName,
                  IngredientCount = e.Ingredients.Count(),
                  CommentCount = e.Comments.Count(),
                  MadeByCount = e.RecipesUsers.Count()
              })
              .ToListAsync();
        }

        public async Task RemoveFromRecipeUsersAsync(int recipeId, IdentityUser userId)
        {
            RecipeUser recipeUser = new RecipeUser
            {
                RecipeId = recipeId,
                UserId = userId.Id
            };
            await repository.RemoveAsync(recipeUser);

            await repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<RecipeInfoViewModel>> TheLastedRecipeAsync()
        {
            return await repository.AllReadOnly<Recipe>()
               .OrderByDescending(e => e.PostedOn)
               .Select(e => new RecipeInfoViewModel()
               {
                   Name = e.Name,
                   ImageUrl = e.ImageUrl,
                   PreparationTime = e.PreparationTime,
                   PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                   CategoryName = e.Category.Name,
                   DifficultyName = e.Difficulty.Name,
                   Cook = e.Cook.UserName,
                   IngredientCount = e.Ingredients.Count(),
                   CommentCount = e.Comments.Count(),
                   MadeByCount = e.RecipesUsers.Count()
               })
               .Take(1)
               .ToListAsync();
        }

        public async Task<IEnumerable<RecipeInfoViewModel>> Top3RecipesAsync()
        {
            return await repository.AllReadOnly<Recipe>()
               .Select(e => new RecipeInfoViewModel()
               {
                   Name = e.Name,
                   ImageUrl = e.ImageUrl,
                   PreparationTime = e.PreparationTime,
                   PostedOn = e.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                   CategoryName = e.Category.Name,
                   DifficultyName = e.Difficulty.Name,
                   Cook = e.Cook.UserName,
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
