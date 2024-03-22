using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;

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
        [HttpGet]
        public async Task<IActionResult> AddIngredients()
        {
            var ingredient = new IngredientsAddViewModel();

            return View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredients(IngredientsAddViewModel ingredient, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }

            int newIngredientId = await ingredientService.AddAsync(ingredient, id);
            return RedirectToAction(nameof(RecipeController.Details), new { id });
        }
    }
}
