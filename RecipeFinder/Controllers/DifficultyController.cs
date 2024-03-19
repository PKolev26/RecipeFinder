using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Controllers
{
    public class DifficultyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
