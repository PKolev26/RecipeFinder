using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
