﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Comment;
using RecipeFinder.Core.Contracts.Recipe;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Models.RecipeModels;

namespace RecipeFinder.Areas.Administrator.Controllers
{
    public class ManagementController : AdminBaseController
    {
        private readonly IRecipeService recipeService;
        private readonly ICommentService commentService;
        private readonly IApplicationUserService applicationUserService;

        public ManagementController(IRecipeService recipeService, ICommentService commentService, IApplicationUserService applicationUserService)
        {
            this.recipeService = recipeService;
            this.commentService = commentService;
            this.applicationUserService = applicationUserService;
        }

        public async Task<IActionResult> ManageUsers()
        {
            var model = await applicationUserService.AllUsersAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageRecipes([FromQuery] AllRecipesQueryModel model)
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

        public IActionResult ManageCategories()
        {
            return View();
        }

        public IActionResult ManageDifficulties()
        {
            return View();
        }
        public async Task<IActionResult> ManageComments()
        {
            var model = await commentService.AllCommentsAsync();
            return View(model);
        }
    }
}
