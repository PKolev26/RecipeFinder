using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Home;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(IRepository repository)
        {
            this.repository = repository;
        }

        // UserHasUnfinishedRecipeAsync method is used to check if a user has an unfinished recipe(recipes with no ingredients). It takes an ApplicationUser as a parameter and returns a boolean.

        public async Task<bool> UserHasUnfinishedRecipeAsync(ApplicationUser user)
        {
            var hasUnfinishedRecipeList = await repository.AllReadOnly<Recipe>()
                .Where(r => r.CookId == user.Id && r.Ingredients.Count() == 0)
                .ToListAsync();

            return hasUnfinishedRecipeList.Any();
        }
    }
}
