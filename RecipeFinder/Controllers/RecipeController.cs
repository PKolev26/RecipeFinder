using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Extensions;
using RecipeFinder.Infrastructure.Data.Models;

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
            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
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
            var cookId = await _userManager.GetUserAsync(User);

            int newRecipeId = await recipeService.AddAsync(newRecipe, cookId);

            return RedirectToAction("AddIngredients", "Ingredient", new { id = newRecipeId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await recipeService.RecipeDetailsByIdAsync(id);
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await recipeService.GetRecipeFormViewModelByIdAsync(id);

            if (recipe.CookId != currentUser.Id)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RecipeFormViewModel model)
        {
            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if(recipe.CookId != currentUser.Id)
            {
                return BadRequest();
            }

            await recipeService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRecipeBook(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (currentUser.Id != recipe.CookId)
            {
                return BadRequest();
            }

            if (recipe.RecipeUser != null && recipe.RecipeUser.RecipeId == id && recipe.RecipeUser.UserId == currentUser.Id)
            {
                return RedirectToAction(nameof(RecipeBook));
            }
            else
            {
                await recipeService.AddToRecipeUsersAsync(id, currentUser);

                return RedirectToAction(nameof(RecipeBook));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromRecipeBook(int id)
        {
            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

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
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (currentUser.Id != recipe.CookId)
            {
                return BadRequest();
            }

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
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var recipe = await recipeService.RecipeDetailsByIdAsync(model.Id);

            if (currentUser.Id != recipe.CookId)
            {
                return BadRequest();
            }

            await recipeService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
