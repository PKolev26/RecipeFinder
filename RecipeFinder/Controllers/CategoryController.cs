using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
