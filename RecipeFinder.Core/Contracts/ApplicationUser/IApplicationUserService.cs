using RecipeFinder.Core.Models.ApplicationUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Core.Contracts.User
{
    public interface IApplicationUserService
    {
        Task<IEnumerable<AllUsersSerivceModel>> AllUsersAsync();

        Task<ApplicationUserDetailsServiceModel> UserDetailsAsync(string id);

        Task PromoteUserAsync(string id);

        Task DemoteUserAsync(string id);

        Task DeleteAsync(string userId);

        Task<bool> ExistsAsync(string id);

        Task IsAdminAsync(string id);
    }
}
