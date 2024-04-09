using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Home;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> UserHasUnfinishedRecipeAsync(ApplicationUser user)
        {
            var hasUnfinishedRecipeList = await repository.AllReadOnly<Recipe>()
                .Where(r => r.CookId == user.Id && r.Ingredients.Count() == 0)
                .ToListAsync();

            return hasUnfinishedRecipeList.Any();
        }
    }
}
