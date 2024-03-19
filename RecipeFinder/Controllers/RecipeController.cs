using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Recipe;

namespace RecipeFinder.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {

        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var recipes = await recipeService.AllRecipesAsync();
            return View(recipes);
        }
    }
}
