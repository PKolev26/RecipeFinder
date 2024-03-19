using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.Recipe;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository repository;

        public RecipeService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<RecipeInfoViewModel>> AllRecipesAsync()
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
