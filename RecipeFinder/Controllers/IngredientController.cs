using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.IngredientModels;

namespace RecipeFinder.Controllers
{
    public class IngredientController : Controller
    {

        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IngredientsAdd(IngredientsAddViewModel ingredient, int recipeId)
        {

            int newIngredientId = await ingredientService.AddAsync(ingredient, recipeId);
            return RedirectToAction(nameof(RecipeController.All));
        }
    }
}
