using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeFinder.Core.Contracts.Recipe;
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

        public async Task<int> AddAsync(RecipeAddViewModel model, IdentityUser cookId)
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

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            return await repository.AllAsReadOnly<Category>()
                .Select(ct => new CategoryViewModel()
                {
                    Id = ct.Id,
                    Name = ct.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllAsReadOnly<Category>()
                .Select(ct => ct.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<DifficultyViewModel>> AllDifficultiesAsync()
        {
            return await repository.AllAsReadOnly<Difficulty>()
                .Select(ct => new DifficultyViewModel()
                {
                    Id = ct.Id,
                    Name = ct.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllDifficultiesNamesAsync()
        {
            return await repository.AllAsReadOnly<Difficulty>()
               .Select(ct => ct.Name)
               .ToListAsync();
        }

        public async Task<IEnumerable<RecipeInfoViewModel>> AllRecipesAsync()
        {
            return await repository.AllAsReadOnly<Recipe>()
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

        public async Task<IEnumerable<RecipeDetailsViewModel>> DetailsAsync(int id)
        {
            return await repository.AllAsReadOnly<Recipe>()
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

        public async Task<string?> GetCookIdAsync(string cookId)
        {
            return (await repository
                .AllAsReadOnly<IdentityUser>()
                .FirstOrDefaultAsync(iu => iu.Id == cookId))?.Id;
        }

        public async Task<IEnumerable<RecipeInfoViewModel>> MineRecipesAsync(IdentityUser currentUser)
        {
            if (currentUser == null)
            {
                return Enumerable.Empty<RecipeInfoViewModel>();
            }

            return await repository.AllAsReadOnly<Recipe>()
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

        public async Task<IEnumerable<RecipeInfoViewModel>> RecipesInMasterChefDifficultyAsync()
        {
            return await repository.AllAsReadOnly<Recipe>()
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

        public async Task<IEnumerable<RecipeInfoViewModel>> TheLastedRecipeAsync()
        {
            return await repository.AllAsReadOnly<Recipe>()
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
            return await repository.AllAsReadOnly<Recipe>()
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
