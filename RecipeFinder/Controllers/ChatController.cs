using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Chat()
        {
            return View("Chat");
        }
    }
}
