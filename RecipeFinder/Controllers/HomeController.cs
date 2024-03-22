using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.Home;
using RecipeFinder.Core.Contracts.Ingredient;
using RecipeFinder.Core.Services;
using RecipeFinder.Models;
using System.Diagnostics;

namespace RecipeFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IHomeService homeService)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}
