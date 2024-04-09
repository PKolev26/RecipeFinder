using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Extensions;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRecipeService recipeService;

        public CommentController(ICommentService commentService, UserManager<ApplicationUser> userManager, IRecipeService recipeService)
        {
            this.commentService = commentService;
            this._userManager = userManager;
            this.recipeService = recipeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddComment(int id)
        {

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = new CommentAddViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddViewModel model, int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var recipe = await recipeService.RecipeDetailsByIdAsync(id);
            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            await commentService.AddAsync(model, currentUser, id);
            return RedirectToAction("Details", "Recipe", new {id, name = recipe.Name});
        }
    }
}
