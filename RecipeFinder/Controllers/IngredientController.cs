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
        public async Task<IActionResult> AddIngredients(int id)
        {
            var ingredient = new IngredientsAddViewModel()
            {
                
                RecipeId = id
            };

            return View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredients(IngredientsAddViewModel model, int id)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await ingredientService.AddAsync(model, id);
            return RedirectToAction("Details", "Recipe",  new { id });
        }
    }
}
