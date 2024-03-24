using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Extensions;

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
            var newRecipe = new RecipeFormViewModel()
            {
                Categories = await recipeService.AllCategoriesAsync(),
                Difficulties = await recipeService.AllDifficultiesAsync(),
            };

            return View(newRecipe);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RecipeFormViewModel newRecipe)
        {

            if (!ModelState.IsValid)
            {
                return View(newRecipe);
            }
            var cookId = await _userManager.GetUserAsync(User);

            int newRecipeId = await recipeService.AddAsync(newRecipe, cookId);
            return RedirectToAction("AddIngredients", "Ingredient", new { id = newRecipeId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var model = await recipeService.GetRecipeFormViewModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RecipeFormViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                model.Categories = await recipeService.AllCategoriesAsync();
                model.Difficulties = await recipeService.AllDifficultiesAsync();
                return View(model);
            }

            await recipeService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRecipeBook(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            await recipeService.AddToRecipeUsersAsync(id, currentUser);

            return RedirectToAction(nameof(RecipeBook));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromRecipeBook(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            await recipeService.RemoveFromRecipeUsersAsync(id, currentUser);
            return RedirectToAction(nameof(RecipeBook));
        }

        [HttpGet]
        public async Task<IActionResult> RecipeBook()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var recipes = await recipeService.RecipeBookAsync(currentUser);

            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            var model = new RecipeDetailsViewModel()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Instructions = recipe.Instructions,
                CategoryName = recipe.CategoryName,
                DifficultyName = recipe.DifficultyName,
                PreparationTime = recipe.PreparationTime,
                ImageUrl = recipe.ImageUrl,
                PostedOn = recipe.PostedOn,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RecipeDetailsViewModel model)
        {
            await recipeService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
