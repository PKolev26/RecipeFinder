using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Extensions;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Extensions;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Controllers
{
    [Authorize]
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
            return RedirectToAction("Details", "Recipe", new {id, name = recipe.GetName()});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var comment = await commentService.CommentInformationByIdAsync(id);

            if (currentUser.Id != comment.AuthorId && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new CommentsInfoViewModel()
            {
                Id = id,
                Title = comment.Title,
                Description = comment.Description,
                AuthorFirstName = comment.AuthorFirstName,
                AuthorLastName = comment.AuthorLastName,
                AuthorProfilePicture = comment.AuthorProfilePicture,
                PostedOn = comment.PostedOn,
                RecipeId = comment.RecipeId,
                RecipeName = comment.RecipeName,
                AuthorId = comment.AuthorId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommentsInfoViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await commentService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var comment = await commentService.CommentInformationByIdAsync(model.Id);

            if (currentUser.Id != comment.AuthorId && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var recipeToRedirect = await recipeService.RecipeDetailsByIdAsync(comment.RecipeId);

            await commentService.DeleteAsync(model.Id);

            if (User.IsAdmin())
            {
                return RedirectToAction("ManageComments", "Management", new { area = "Administrator" });
            }
            return RedirectToAction("Details", "Recipe", new { recipeToRedirect.Id, name = recipeToRedirect.GetName() });
        }
    }
}
