using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();

        Task<bool> ExistsAsync(int categoryId);

        Task DeleteAsync(int categoryId);

        Task<CategoryViewModel> CategoryInformationByIdAsync(int categoryId);
    }
}
