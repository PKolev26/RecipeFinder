using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.Recipe;
using RecipeFinder.Infrastructure.Common;
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

        public async Task<IEnumerable<AllRecipeViewModel>> AllRecipesAsync()
        {
            return await repository.AllAsReadOnly<Recipe>()
                .Select(e => new AllRecipeViewModel()
                {
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    PreparationTime = e.PreparationTime,
                    PostedOn = e.PostedOn,
                    CategoryName = e.Category.Name,
                    DifficultyName = e.Difficulty.Name,
                    Cook = e.Cook.UserName,
                    IngredientCount = e.Ingredients.Count(),
                    CommentCount = e.Comments.Count(),
                    MadeByCount = e.RecipesUsers.Count()
                })
                .ToListAsync();         
        }
    }
}
