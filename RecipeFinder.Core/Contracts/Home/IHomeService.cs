using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Contracts.Home
{
    public interface IHomeService
    {
        Task<bool> UserHasUnfinishedRecipeAsync(ApplicationUser user);
    }
}
