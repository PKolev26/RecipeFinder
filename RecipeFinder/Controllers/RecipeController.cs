using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Recipe;

namespace RecipeFinder.Controllers
{
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
        public async Task<IActionResult> All()
        {

            return View();
        }
    }
}
