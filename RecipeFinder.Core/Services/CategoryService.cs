using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Category;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.CommentModels;
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
    public class CategoryService : ICategoryService
    {
        public IRepository repository;

        public CategoryService(IRepository repository)
        {
            this.repository = repository;
        }

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

        public async Task<bool> ExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
               .AnyAsync(c => c.Id == categoryId);
        }

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
