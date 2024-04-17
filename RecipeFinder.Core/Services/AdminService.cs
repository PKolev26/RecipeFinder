using Microsoft.EntityFrameworkCore;
using RecipeFinder.Core.Contracts.Admin;
using RecipeFinder.Core.Models.AdminModels;
using RecipeFinder.Infrastructure.Common;
using RecipeFinder.Infrastructure.Constants;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repository;

        public AdminService(IRepository repository)
        {
            this.repository = repository;
        }

        // PanelInformationAsync method is used to get the total number of users, recipes, and comments in the database. It also gets the latest 10 recipes posted.

        public async Task<AdminPanelServiceModel> PanelInformationAsync()
        {
            var usersCount = await repository.All<ApplicationUser>().CountAsync();
            var recipesCount = await repository.All<Recipe>().CountAsync();
            var commentsCount = await repository.All<Comment>().CountAsync();

            var panelInformation = new AdminPanelServiceModel
            {
                TotalUsers = usersCount,
                TotalComments = commentsCount,
                TotalRecipes = recipesCount,
                Latest = await repository.All<Recipe>()
                    .OrderByDescending(x => x.PostedOn)
                    .Take(10)
                    .Select(x => new AdminLatest10ServiceModel
                    {
                        CookFirstName = x.Cook.FirstName,
                        CookLastName = x.Cook.LastName,
                        Recipe = x.Name,
                        PostedOn = x.PostedOn.ToString(RecipeDataConstants.DateAndTimeFormat),
                        CategoryName = x.Category.Name,
                        DifficultyName = x.Difficulty.Name,
                        CommentsCount = x.Comments.Count,
                        IsFinished = x.Ingredients.Any()
                    })
                    .ToListAsync()
            };

            return panelInformation;
        }
    }
}
