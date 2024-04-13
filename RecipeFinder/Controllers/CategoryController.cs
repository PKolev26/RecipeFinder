using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Category;
using RecipeFinder.Core.Models.CategoryModels;
using RecipeFinder.Core.Models.CommentModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Extensions;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Controllers
{
    [Authorize (Roles = "Administrator")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var category = await categoryService.CategoryInformationByIdAsync(id);

            var model = new CategoryViewModel()
            {
                Id = id,
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete (CategoryViewModel model)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            await categoryService.DeleteAsync(model.Id);

            return RedirectToAction("ManageCategories", "Management", new { area = "Administrator" });
        }
    }
}
