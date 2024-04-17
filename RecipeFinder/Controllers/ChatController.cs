using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RecipeFinder.Controllers
{
    [Authorize]
    public class ChatController : Controller
	{
		public IActionResult ChatWithOthers()
		{
			return View("Chat");
		}
	}
}