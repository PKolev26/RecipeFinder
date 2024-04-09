using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Admin;
using RecipeFinder.Core.Contracts.Recipe;

namespace RecipeFinder.Areas.Administrator.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IAdminService adminService;

        public HomeController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public async Task<IActionResult> AdminPanel()
        {
            var model = await adminService.PanelInformation();
            return View(model);
        }

        public IActionResult ManageUsers()
        {
            return View();
        }

        public IActionResult ManageRecipes()
        {
            return View();
        }

        public IActionResult ManageCategories()
        {
            return View();
        }

        public IActionResult ManageDifficulties()
        {
            return View();
        }
        public IActionResult ManageComments()
        {
            return View();
        }
    }
}
