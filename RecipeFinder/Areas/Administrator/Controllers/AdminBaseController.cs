using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RecipeFinder.Core.Constants.RoleConstants;

namespace RecipeFinder.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
