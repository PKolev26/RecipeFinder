using Microsoft.AspNetCore.Identity;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Models.ApplicationUserModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeFinder.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Infrastructure.Constants;
using System.Runtime.CompilerServices;
using System.Data;
using static RecipeFinder.Core.Constants.RoleConstants;

namespace RecipeFinder.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(IRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this._userManager = userManager;
        }
        public async Task<IEnumerable<AllUsersSerivceModel>> AllUsersAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Select(u => new AllUsersSerivceModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();
        }


        public async Task DeleteAsync(string userId)
        {
            var userRecipes = await repository.AllReadOnly<Recipe>()
                .Where(r => r.CookId == userId)
                .ToListAsync();

            foreach (var item in userRecipes)
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

            await repository.DeleteAsync<ApplicationUser>(userId);
            await repository.SaveChangesAsync();
        }

        public async Task DemoteUserAsync(string id)
        {
            var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, AdminRole);
            }
        }

        public async Task PromoteUserAsync(string id)
        {
            var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, AdminRole);
            }
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await repository.AllReadOnly<ApplicationUser>()
               .AnyAsync(r => r.Id == id);
        }

        public async Task<ApplicationUserDetailsServiceModel> UserDetailsAsync(string id)
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Where(r => r.Id == id)
                .Select(r => new ApplicationUserDetailsServiceModel()
                {
                    Id = id,
                    Email = r.Email,
                    UserName = r.UserName,
                    FirstName = r.FirstName,
                    LastName = r.LastName
                })
                .FirstAsync();
        }

        public Task IsAdminAsync(string id)
        {
            return Task.Run(() =>
            {
                var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

                if (user != null)
                {
                    return _userManager.IsInRoleAsync(user, AdminRole).Result;
                }

                return false;
            });
        }
    }
}
