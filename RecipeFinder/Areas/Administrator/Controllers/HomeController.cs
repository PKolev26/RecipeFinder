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
            var model = await adminService.PanelInformationAsync();
            return View(model);
        }
    }
}
