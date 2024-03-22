using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;

namespace RecipeFinder.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<IdentityUser> userManager)
        {
            this.commentService = commentService;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddComment(int id)
        {
            var newComment = new CommentAddViewModel()
            {
                RecipeId = id,
            };

            return View(newComment);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var authorId = await _userManager.GetUserAsync(User);
            await commentService.AddAsync(model, authorId, id);
            return RedirectToAction("Details", "Recipe", new { id}, $"#{model.Id}");
        }
    }
}
