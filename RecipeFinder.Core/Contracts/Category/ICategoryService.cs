using RecipeFinder.Core.Models.CategoryModels;

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
