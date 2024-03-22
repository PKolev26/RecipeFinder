using Microsoft.AspNetCore.Identity;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.DifficultyModels;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
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
        Task<IEnumerable<RecipeInfoViewModel>> MineRecipesAsync(IdentityUser currentUser);
        Task<IEnumerable<RecipeDetailsViewModel>> DetailsAsync(int id);
        Task<int> AddAsync(RecipeAddViewModel model, IdentityUser cookId);
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task<IEnumerable<string>> AllCategoriesNamesAsync();
        Task<IEnumerable<DifficultyViewModel>> AllDifficultiesAsync();
        Task<IEnumerable<string>> AllDifficultiesNamesAsync();
        Task<string?> GetCookIdAsync(string cookId);
    }
}
