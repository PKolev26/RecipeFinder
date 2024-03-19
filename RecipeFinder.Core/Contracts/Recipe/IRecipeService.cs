using RecipeFinder.Core.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeInfoViewModel>> AllRecipesAsync();
        Task<IEnumerable<RecipeInfoViewModel>> Top3RecipesAsync();
        Task<IEnumerable<RecipeInfoViewModel>> TheLastedRecipeAsync();
        Task<IEnumerable<RecipeInfoViewModel>> RecipesInMasterChefDifficultyAsync();
    }
}
