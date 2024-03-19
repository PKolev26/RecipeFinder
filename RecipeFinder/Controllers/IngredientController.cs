using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
