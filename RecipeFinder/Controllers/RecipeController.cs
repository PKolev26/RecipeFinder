using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;

namespace RecipeFinder.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {

        private readonly IRecipeService recipeService;
        private readonly UserManager<IdentityUser> _userManager;

        public RecipeController(IRecipeService recipeService, UserManager<IdentityUser> userManager)
        {
            this.recipeService = recipeService;
            this._userManager = userManager;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Top3Recipes()
        {
            var recipes = await recipeService.Top3RecipesAsync();
            return View(recipes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TheLatestRecipe()
        {
            var recipes = await recipeService.TheLastedRecipeAsync();
            return View(recipes);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> MasterChefDifficulty()
        {
            var recipes = await recipeService.RecipesInMasterChefDifficultyAsync();
            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var recipes = await recipeService.MineRecipesAsync(currentUser);

            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var recipe = await recipeService.DetailsAsync(id);
            return View(recipe);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var newRecipe = new RecipeAddViewModel()
            {
                Categories = await recipeService.AllCategoriesAsync(),
                Difficulties = await recipeService.AllDifficultiesAsync(),
            };

            return View(newRecipe);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RecipeAddViewModel newRecipe)
        {

            if (!ModelState.IsValid)
            {
                return View(newRecipe);
            }

            int newRecipeId = await recipeService.AddAsync(newRecipe);
            return RedirectToAction(nameof(IngredientController.IngredientsAdd));
        }
    }
}
