using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Category;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Models.ApplicationUserModels;
using RecipeFinder.Core.Models.RecipeModels;

namespace RecipeFinder.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class ManagementController : AdminBaseController
    {
        private readonly IRecipeService recipeService;
        private readonly IApplicationUserService applicationUserService;
        private readonly ICommentService commentService;
        private readonly ICategoryService categoryService;

        public ManagementController(IRecipeService recipeService, ICommentService commentService, IApplicationUserService applicationUserService, ICategoryService categoryService)
        {
            this.recipeService = recipeService;
            this.commentService = commentService;
            this.applicationUserService = applicationUserService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUsers([FromQuery] AllUsersQueryModel model)
        {
            var user = await applicationUserService.AllUsersAsync(
                model.Id,
                model.FirstName,
                model.LastName,
                model.Sorting,
                model.CurrentPage,
                model.UsersPerPage);

            model.TotalUsersCount = user.TotalUsersCount;

            model.Users = user.Users;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageRecipes([FromQuery] AllRecipesQueryModel model)
        {
            var recipe = await recipeService.AllRecipesAsync(
                model.Search,
                model.Sorting,
                model.CurrentPage,
                model.RecipesPerPage,
                model.Category,
                model.Difficulty);

            model.TotalRecipesCount = recipe.TotalRecipesCount;
            model.Categories = await recipeService.AllCategoriesNamesAsync();
            model.Difficulties = await recipeService.AllDifficultiesNamesAsync();

            model.Recipes = recipe.Recipes;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageCategories()
        {
            var model = await categoryService.AllCategoriesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageComments()
        {
            var model = await commentService.AllCommentsAsync();
            return View(model);
        }
    }
}
