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
        Task<RecipeDetailsViewModel> RecipeDetailsByIdAsync(int id);
        Task<int> AddAsync(RecipeFormViewModel model, IdentityUser cookId);
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task<IEnumerable<string>> AllCategoriesNamesAsync();
        Task<IEnumerable<DifficultyViewModel>> AllDifficultiesAsync();
        Task<IEnumerable<string>> AllDifficultiesNamesAsync();
        Task<string?> GetCookIdAsync(string cookId);
        Task EditAsync(int recipeId, RecipeFormViewModel model);
        Task<RecipeFormViewModel?> GetRecipeFormViewModelByIdAsync(int id);
        Task AddToRecipeUsersAsync(int recipeId, IdentityUser userId);
        Task<IEnumerable<RecipeInfoViewModel>> RecipeBookAsync(IdentityUser currentUser);
        Task RemoveFromRecipeUsersAsync(int recipeId, IdentityUser userId);
        Task DeleteAsync(int recipeId);
        Task<bool> ExistsAsync(int id);

    }
}
