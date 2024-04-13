using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Home;
using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Services;
using RecipeFinder.Infrastructure.Data.Models;
using RecipeFinder.Models;
using System.Diagnostics;

namespace RecipeFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, IHomeService homeService)
        {
            _logger = logger;
            this._userManager = userManager;
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HasUnfinishedRecipe = await Notification();
            return View();
        }

        public async Task<bool> Notification()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (await homeService.UserHasUnfinishedRecipeAsync(currentUser))
                {
                    return true;
                }
            }
            return false;

        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            if (statusCode == 500)
            {
                return View("Error500");
            }

            return View();
        }
    }
}
