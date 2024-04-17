using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Enumerations;
using RecipeFinder.Core.Models.ApplicationUserModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
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
        
        // AllUsersAsync method is used to get all users in the database. It can filter users by id, firstname, and lastname. It can also sort users by email, firstname, lastname, and id. It returns a UserQueryServiceModel.

        public async Task<UserQueryServiceModel> AllUsersAsync(string? id = null, string? firstname = null, string? lastname = null, UserSorting sorting = UserSorting.EmailAscending, int currentPage = 1, int usersPerPage = 1)
        {
            var users = repository.AllReadOnly<ApplicationUser>();

            if (id != null)
            {
                users = users
                   .Where(u => u.Id == id);
            }

            if (firstname != null)
            {
                users = users
                   .Where(u => u.FirstName == firstname);
            }

            if (lastname != null)
            {
                users = users
                   .Where(u => u.LastName == lastname);
            }

            users = sorting switch
            {
                UserSorting.EmailAscending => users
                    .OrderBy(u => u.Email),
                UserSorting.EmailDescending => users
                .OrderByDescending(u => u.Email),
                UserSorting.FirstNameAscending => users
                    .OrderBy(u => u.FirstName),
                    UserSorting.FirstNameDescending => users
                    .OrderByDescending(u => u.FirstName),
                    UserSorting.LastNameAscending => users
                    .OrderBy(u => u.LastName),
                    UserSorting.LastNameDescending => users
                    .OrderByDescending(u => u.LastName),
                    UserSorting.IdAscending => users
                    .OrderBy(u => u.Id),
                    UserSorting.IdDescending => users
                    .OrderByDescending(u => u.Id),
                _ => users
                    .OrderByDescending(h => h.Id)
            };

            var AllUsers = await users
                .Skip((currentPage - 1) * usersPerPage)
                .Take(usersPerPage)
                .Select(e => new AllUsersSerivceModel()
                {
                    Id = e.Id,
                    Email = e.Email,
                    FirstName = e.FirstName,
                    LastName = e.LastName
                })
                .ToListAsync();

            int usersCount = await users.CountAsync();

            return new UserQueryServiceModel()
            {
                TotalUsersCount = usersCount,
                Users = AllUsers,
            };
        }

        // DeleteAsync method is used to delete a user from the database. It also deletes all recipes, comments, ingredients, and recipe users that are related to the user.

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

        // DemoteUserAsync method is used to remove the admin role from a user.

        public async Task DemoteUserAsync(string id)
        {
            var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, AdminRole);
            }
        }

        // PromoteUserAsync method is used to add the admin role to a user.
        
        public async Task PromoteUserAsync(string id)
        {
            var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, AdminRole);
            }
        }

        // ExistsAsync method is used to check if a user exists in the database.

        public async Task<bool> ExistsAsync(string id)
        {
            return await repository.AllReadOnly<ApplicationUser>()
               .AnyAsync(r => r.Id == id);
        }

        // UserDetailsAsync method is used to get the details of a user by id. It returns a UsersDetailsServiceModel.

        public async Task<UsersDetailsServiceModel> UserDetailsAsync(string id)
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Where(r => r.Id == id)
                .Select(r => new UsersDetailsServiceModel()
                {
                    Id = id,
                    Email = r.Email,
                    UserName = r.UserName,
                    FirstName = r.FirstName,
                    LastName = r.LastName
                })
                .FirstAsync();
        }

        // IsAdminAsync method is used to check if a user is an admin.

        public async Task<bool> IsAdminAsync(string id)
        {
            var user = repository.All<ApplicationUser>().FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                return await _userManager.IsInRoleAsync(user, AdminRole);
            }

            return false;
        }
    }
}
