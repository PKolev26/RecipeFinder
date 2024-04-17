using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Category;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public IRepository repository;

        public CategoryService(IRepository repository)
        {
            this.repository = repository;
        }

        // AllCategoriesAsync method is used to get all categories in the database. It returns a list of CategoryViewModel.

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .OrderBy(r => r.Name)
                .Select(r => new CategoryViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    RecipeCount = repository.AllReadOnly<Recipe>().Count(c => c.CategoryId == r.Id)
                })
                .ToListAsync();
        }

        // DeleteAsync method is used to delete a category from the database. It first gets all recipes that are in the category and deletes them, then deletes the category.

        public async Task DeleteAsync(int categoryId)
        {
            var categoryRecipes = await repository.AllReadOnly<Recipe>()
                .Where(r => r.CategoryId == categoryId)
                .ToListAsync();

            foreach (var item in categoryRecipes)
            {
                var commentsToRemove = await repository.AllReadOnly<Comment>()
                .Where(c => c.RecipeId == item.Id)
                .ToListAsync();
                foreach (var comment in commentsToRemove)
                {
                    await repository.DeleteAsync<Comment>(comment.Id);
                }

                var ingredientsToRemove = await repository.AllReadOnly<Ingredient>()
                .Where(c => c.RecipeId == item.Id)
                .ToListAsync();
                foreach (var ingredient in ingredientsToRemove)
                {
                    await repository.DeleteAsync<Ingredient>(ingredient.Id);
                }

                var recupeUsersToRemove = await repository.AllReadOnly<RecipeUser>()
                .Where(c => c.RecipeId == item.Id)
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
                
                await repository.DeleteAsync<Recipe>(item.Id);
            }

            await repository.DeleteAsync<Category>(categoryId);
            await repository.SaveChangesAsync();
        }

        // ExistsAsync method is used to check if a category exists in the database. It returns a true or false.

        public async Task<bool> ExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
               .AnyAsync(c => c.Id == categoryId);
        }

        // CategoryInformationByIdAsync method is used to get the information of a category by its id. It returns a CategoryViewModel.

        public async Task<CategoryViewModel> CategoryInformationByIdAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .Where(c => c.Id == categoryId)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstAsync();
        }
    }
}
