using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {

        private readonly IIngredientService ingredientService;
        private readonly IRecipeService recipeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IngredientController(IIngredientService ingredientService, IRecipeService recipeService, UserManager<ApplicationUser> userManager)
        {
            this.ingredientService = ingredientService;
            this.recipeService = recipeService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddIngredients(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var currentRecipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (currentUser.Id != currentRecipe.CookId)
            {
                return BadRequest();
            }

            var ingredient = new IngredientsAddViewModel()
            {
                RecipeId = id
            };

            return View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredients(IngredientsAddViewModel model, int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var currentRecipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (currentUser.Id != currentRecipe.CookId)
            {
                return BadRequest();
            }
            await ingredientService.AddAsync(model, id);
            return RedirectToAction(nameof(AddIngredients), new { id });
        }
    }
}
