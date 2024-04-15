using Microsoft.AspNetCore.Identity;
using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.DifficultyModels;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Recipe
{
    public interface IRecipeService
    {
        Task<RecipeQueryServiceModel> AllRecipesAsync(
            string? search = null,
            RecipeSorting sorting = RecipeSorting.Newest,
            int currentPage = 1,
            int recipesPerPage = 1,
            string? category = null,
            string? difficulty = null);
        Task<IEnumerable<RecipeInfoViewModel>> Top3RecipesAsync();
        Task<IEnumerable<RecipeInfoViewModel>> TheLastedRecipeAsync();
        Task<IEnumerable<RecipeInfoViewModel>> RecipesInMasterChefDifficultyAsync();
        Task<IEnumerable<RecipeInfoViewModel>> MineRecipesAsync(ApplicationUser currentUser);
        Task<IEnumerable<RecipeDetailsServiceModel>> DetailsAsync(int id);
        Task<RecipeDetailsServiceModel> RecipeDetailsByIdAsync(int id);
        Task<int> AddAsync(RecipeFormViewModel model, ApplicationUser cookId);
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task<IEnumerable<string>> AllCategoriesNamesAsync();
        Task<IEnumerable<DifficultyViewModel>> AllDifficultiesAsync();
        Task<IEnumerable<string>> AllDifficultiesNamesAsync();
        Task EditAsync(int recipeId, RecipeFormViewModel model);
        Task<RecipeFormViewModel?> GetRecipeFormViewModelByIdAsync(int id);
        Task AddToRecipeUsersAsync(int recipeId, ApplicationUser userId);
        Task<IEnumerable<RecipeInfoViewModel>> RecipeBookAsync(ApplicationUser currentUser);
        Task RemoveFromRecipeUsersAsync(int recipeId, ApplicationUser userId);
        Task DeleteAsync(int recipeId);
        Task<bool> ExistsAsync(int id);

    }
}
