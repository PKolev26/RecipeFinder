using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
