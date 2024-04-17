using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Core.Constants;
using RecipeFinder.Core.Contracts.User;
using RecipeFinder.Core.Models.ApplicationUserModels;
using RecipeFinder.Extensions;
using RecipeFinder.Infrastructure.Data.Models;

namespace RecipeFinder.Controllers
{
    [Authorize(Roles = RoleConstants.AdminRole)]
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
        public async Task<IActionResult> All([FromQuery] AllUsersQueryModel model)
        {
            var users = await applicationUserService.AllUsersAsync(
                model.Id,
                model.FirstName,
                model.LastName,
                model.Sorting,
                model.CurrentPage,
                model.UsersPerPage);

            model.TotalUsersCount = users.TotalUsersCount;

            model.Users = users.Users;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var userToDelete = await applicationUserService.UserDetailsAsync(id);

            if (await applicationUserService.ExistsAsync(id) == false || User.Id() == userToDelete.Id)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new UsersDetailsServiceModel()
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
        public async Task<IActionResult> Delete(UsersDetailsServiceModel model)
        {
            if (await applicationUserService.ExistsAsync(model.Id) == false || User.Id() == model.Id)
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

            var model = new UsersDetailsServiceModel()
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
        public async Task<IActionResult> Promote(UsersDetailsServiceModel model)
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

            var model = new UsersDetailsServiceModel()
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
        public async Task<IActionResult> Demote(UsersDetailsServiceModel model)
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
