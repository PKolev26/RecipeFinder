using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Models.ApplicationUserModels;
using RecipeFinder.Core.Models.RecipeModels;
using RecipeFinder.Core.Services;
using RecipeFinder.Extensions;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Controllers
{
    public class UserController : Controller
    {
        private IApplicationUserService applicationUserService;
        private UserManager<ApplicationUser> _userManager;
        public UserController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager) 
        {
            this.applicationUserService = applicationUserService;
            this._userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {

            if (await applicationUserService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var userToDelete = await applicationUserService.UserDetailsAsync(id);

            var model = new ApplicationUserDetailsServiceModel()
            {
                Id = userToDelete.Id,
                UserName = userToDelete.UserName,
                Email = userToDelete.Email,
                FirstName = userToDelete.FirstName,
                LastName = userToDelete.LastName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUserDetailsServiceModel model)
        {
            if (await applicationUserService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await applicationUserService.DeleteAsync(model.Id);

            return RedirectToAction("ManageUsers", "Management", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> Promote(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (await applicationUserService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false || id == currentUser.Id)
            {
                return Unauthorized();
            }

            var userToPromote = await applicationUserService.UserDetailsAsync(id);

            var model = new ApplicationUserDetailsServiceModel()
            {
                Id = userToPromote.Id,
                UserName = userToPromote.UserName,
                Email = userToPromote.Email,
                FirstName = userToPromote.FirstName,
                LastName = userToPromote.LastName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Promote(ApplicationUserDetailsServiceModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await applicationUserService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false || model.Id == currentUser.Id)
            {
                return Unauthorized();
            }

            await applicationUserService.PromoteUserAsync(model.Id);

            return RedirectToAction("ManageUsers", "Management", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> Demote(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (await applicationUserService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false || id == currentUser.Id)
            {
                return Unauthorized();
            }

            var userToDemote = await applicationUserService.UserDetailsAsync(id);

            var model = new ApplicationUserDetailsServiceModel()
            {
                Id = userToDemote.Id,
                UserName = userToDemote.UserName,
                Email = userToDemote.Email,
                FirstName = userToDemote.FirstName,
                LastName = userToDemote.LastName
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Demote(ApplicationUserDetailsServiceModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (await applicationUserService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false || model.Id == currentUser.Id)
            {
                return Unauthorized();
            }

            await applicationUserService.DemoteUserAsync(model.Id);

            return RedirectToAction("ManageUsers", "Management", new { area = "Administrator" });
        }
    }
}
