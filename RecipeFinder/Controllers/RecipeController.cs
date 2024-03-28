using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Models.IngredientModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Extensions;
using RecipeFinder.Infrastructure.Data.Models;
using RecipeFinder.Core.Extensions;

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
        public async Task<IActionResult> All([FromQuery] AllRecipesQueryModel model)
        {
            var recipe = await recipeService.AllRecipesAsync(
                model.Search,
                model.Sorting,
                model.CurrentPage,
                model.RecipesPerPage,
                model.Category,
                model.Difficulty);

            model.TotalRecipesCount = recipe.TotalRecipesCount;
            model.Categories = await recipeService.AllCategoriesNamesAsync();
            model.Difficulties = await recipeService.AllDifficultiesNamesAsync();
            
            model.Recipes = recipe.Recipes;

            return View(model);
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
        public async Task<IActionResult> Details(int id, string name)
        {
            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await recipeService.DetailsAsync(id);
            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (name != recipe.GetName())
            {
                return BadRequest();
            }
            return View(model);
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
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (recipe.CookId != currentUser.Id)
            {
                return Unauthorized();
            }

            var model = await recipeService.GetRecipeFormViewModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RecipeFormViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            if (recipe.CookId != currentUser.Id)
            {
                return Unauthorized();
            }

            await recipeService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id, name = model.GetName()});
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
                return Unauthorized();
            }

            var model = new RecipeDetailsServiceModel()
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
        public async Task<IActionResult> Delete(RecipeDetailsServiceModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await recipeService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var recipe = await recipeService.RecipeDetailsByIdAsync(model.Id);

            if (currentUser.Id != recipe.CookId)
            {
                return Unauthorized();
            }

            await recipeService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
